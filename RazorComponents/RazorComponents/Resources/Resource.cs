using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums;
using CodeChops.MagicEnums.Core;

namespace CodeChops.Website.RazorComponents.Resources;

public abstract record Resource<TSelf, TResourceEnum> : MagicStringEnum<TSelf>, IResource
	where TSelf : MagicStringEnum<TSelf>, IResource
	where TResourceEnum : MagicEnumCore<ResourceEnum, DiscoveredObject<IResource>>, IMagicEnumCore<ResourceEnum, DiscoveredObject<IResource>>, IImplementationsEnum<IResource>, IInitializable
{
	private static string DefaultResourceName { get; }
	private static string ThisResourceName { get; }
	private static string ThisLanguageCode { get; }

	static Resource()
	{
		ThisResourceName = typeof(TSelf).Name;

		var languageCode = ThisResourceName[^2..];
		if (Char.IsUpper(languageCode[0]) && Char.IsUpper(languageCode[1]))
		{
			ThisLanguageCode = languageCode;
			DefaultResourceName = ThisResourceName[..^2];
		}
		else
		{
			ThisLanguageCode = LanguageCodeCache.DefaultLanguageCode;
			DefaultResourceName = ThisResourceName;
		}

		foreach (var member in TResourceEnum.GetMembers())
			foreach (var property in member.Value.Type.GetProperties(BindingFlags.Public | BindingFlags.Static))
				property.GetGetMethod()!.Invoke(obj: null, parameters: null);
	}

	protected static new string CreateMember(string value, Func<TSelf>? memberCreator = null, [CallerMemberName] string name = null!)
		=> GetOrCreateMember(value: value, name: name, memberCreator);

	protected static new string CreateMember<TMember>(Func<TMember>? memberCreator = null, string? value = null, [CallerMemberName] string name = null!)
		where TMember : TSelf
		=> GetOrCreateMember<TMember>(name: name, value: value, memberCreator);

	protected static new string GetOrCreateMember(string name)
		=> GetOrCreateMember(name: name, value: name);

	/// <summary>
	/// Gets or creates a resource.
	/// </summary>
	/// <exception cref="ArgumentNullException">When name or value is null.</exception>
	// ReSharper disable once MethodOverloadWithOptionalParameter
	protected static new string GetOrCreateMember(string value, [CallerMemberName] string name = null!, Func<TSelf>? memberCreator = null)
	{
		if (name is null || value is null)
			throw new ArgumentNullException($"Empty name: Unable to retrieve resource {ThisResourceName} for country code {LanguageCodeCache.CurrentSimpleLanguageCode}.");

		// If this is the default resource (e.g. GeneralResource.Warning), the resource in the currently configured country code should be used.
		// Therefore, check if the the current configured country code differs from the default country code.
		// It is possible that the ResourceEnum is not initialized completely (because of static build-up).
		if (ThisResourceName == DefaultResourceName && ThisLanguageCode != LanguageCodeCache.CurrentSimpleLanguageCode && TResourceEnum.IsInitialized)
		{
			// It is possible that the non-default resource does not contain a member with that name, if so, don't look it up.
			// The resource in the default language will be picked up at the end of this method.
			if (TryGetSingleMember(name, out var member))
				return member.Value;
		}
		
		return GetOrCreateMember(
			name: name,
			valueCreator: value.Trim,
			memberCreator: memberCreator).Value;
	}

	/// <summary>
	/// Gets the single resource. 
	/// </summary>
	/// <exception cref="InvalidOperationException">If the resource has not been found.</exception>
	public static new string GetSingleMember([CallerMemberName] string? name = null)
	{
		if (TryGetSingleMember(name!, out var member)) 
			return member.Value;

		throw new InvalidOperationException($"Unable to retrieve resource {name} for {ThisResourceName} (or {DefaultResourceName + LanguageCodeCache.CurrentSimpleLanguageCode}).");
	}
	
	/// <summary>
	/// Tries to get the member based on the currently configured country code. It uses <typeparamref name="TResourceEnum"/> to get the resource enum in the current language.
	/// </summary>
	public static new bool TryGetSingleMember(string name, [NotNullWhen(true)] out IMagicEnum<string>? member)
	{
		var newResourceName = DefaultResourceName + LanguageCodeCache.CurrentSimpleLanguageCode;

		if (!TResourceEnum.TryGetSingleMember(newResourceName, out var specificResource) && !TResourceEnum.TryGetSingleMember(DefaultResourceName, out specificResource))
		{
			member = null;
			return false;
		}

		var foreignResource = (IMagicEnum<string>)specificResource.Instance;
		
		return foreignResource.TryGetSingleMember(name, out member);
	}
	
	public static new int GetMemberCount() => MagicStringEnum<TSelf>.GetMemberCount();
	public static new int GetUniqueValueCount() => MagicStringEnum<TSelf>.GetUniqueValueCount();
	public static new IEnumerable<TSelf> GetMembers() => MagicStringEnum<TSelf>.GetMembers();
	public static new IEnumerable<string> GetValues() => MagicStringEnum<TSelf>.GetValues();
	public static new IEnumerable<TSelf> GetMembers(string memberValue) => MagicStringEnum<TSelf>.GetMembers(memberValue);
}

[DiscoverImplementations(generateProxies: true)]
public partial interface IResource
{
}
