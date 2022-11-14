using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums;
using CodeChops.MagicEnums.Core;

namespace CodeChops.Website.RazorComponents.Resources;

public abstract record Resource<TSelf, TResourceEnum> : MagicStringEnum<TSelf>, IResource
	where TSelf : Resource<TSelf, TResourceEnum>
	where TResourceEnum : MagicEnumCore<ResourceEnum, DiscoveredObject<IResource>>, IMagicEnumCore<ResourceEnum, DiscoveredObject<IResource>>, IImplementationsEnum<IResource>, IDiscoverable
{
	private static string DefaultResourceName { get; }
	private static string ThisResourceName { get; }
	private static string ThisCountryCode { get; }

	static Resource()
	{
		ThisResourceName = typeof(TSelf).Name;

		var countryCode = ThisResourceName[^2..];
		if (Char.IsUpper(countryCode[0]) && Char.IsUpper(countryCode[1]))
		{
			ThisCountryCode = countryCode;
			DefaultResourceName = ThisResourceName[..^2];
		}
		else
		{
			ThisCountryCode = CountryCodeCache.DefaultCountryCode;
			DefaultResourceName = ThisResourceName;
		}

		foreach (var property in typeof(TSelf).GetProperties(BindingFlags.Public | BindingFlags.Static))
			property.GetGetMethod()!.Invoke(obj: null, parameters: null);
	}

	protected static new string CreateMember(string? value = null, Func<TSelf>? memberCreator = null, [CallerMemberName] string? name = null)
		=> GetOrCreateMember(name: name, value: value, memberCreator);

	protected static new string CreateMember<TMember>(Func<TMember>? memberCreator = null, string? value = null, [CallerMemberName] string? name = null)
		where TMember : TSelf
		=> GetOrCreateMember<TMember>(name: name!, value: value, memberCreator);

	protected static new string GetOrCreateMember(string name)
		=> GetOrCreateMember(name: name, value: name);

	// ReSharper disable once MethodOverloadWithOptionalParameter
	protected static new string GetOrCreateMember([CallerMemberName] string? name = null, string? value = null, Func<TSelf>? memberCreator = null)
	{
		if (name is null)
			throw new InvalidOperationException($"Empty name: Unable to retrieve resource {ThisResourceName} for country code {CountryCodeCache.CurrentCountryCode}.");

		if (ThisResourceName != DefaultResourceName || ThisCountryCode == CountryCodeCache.CurrentCountryCode || !TResourceEnum.IsInitialized)
		{
			return GetOrCreateMember(
				name: name,
				valueCreator: () => value?.Trim() ?? throw new InvalidOperationException($"Value unknown for resource {ThisResourceName}.{name}."),
				memberCreator: memberCreator).Value;
		}

		return GetSingleMember(name);
	}

	public static new string GetSingleMember([CallerMemberName] string? name = null)
	{
		return TryGetSingleMember(name!, out var member) 
			? member.Value 
			: throw new InvalidOperationException($"Unable to retrieve resource {ThisResourceName} or {DefaultResourceName}.");
	}
	
	public static new bool TryGetSingleMember(string name, [NotNullWhen(true)] out IMagicEnum<string>? member)
	{
		var newResourceName = DefaultResourceName + CountryCodeCache.CurrentCountryCode;

		if (!TResourceEnum.TryGetSingleMember(newResourceName, out var specificResource) && !TResourceEnum.TryGetSingleMember(DefaultResourceName, out specificResource))
		{
			member = null;
			return false;
		}

		var foreignResource = (IMagicEnum<string>)specificResource.UninitializedInstance;
		
		return foreignResource.TryGetSingleMember(name, out member);
	}
}

[DiscoverImplementations]
public partial interface IResource
{
}
