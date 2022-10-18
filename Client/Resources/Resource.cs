using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Resources;

public abstract record Resource<TSelf> : MagicStringEnum<TSelf>, IResource
	where TSelf : Resource<TSelf>
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
			ThisLanguageCode = LanguageCache.DefaultLanguageCode;
			DefaultResourceName = ThisResourceName;
		}
		
		foreach (var property in typeof(TSelf).GetProperties(BindingFlags.Public | BindingFlags.Static))
			property.GetGetMethod()!.Invoke(obj: null, parameters: null);
	}

	protected new static string CreateMember(string? value = null, Func<TSelf>? memberCreator = null, [CallerMemberName] string? name = null)
		=> GetOrCreateMember(name: name, value: value, memberCreator);

	protected new static string CreateMember<TMember>(Func<TMember>? memberCreator = null, string? value = null, [CallerMemberName] string? name = null)
		where TMember : TSelf
		=> GetOrCreateMember<TMember>(name: name!, value: value, memberCreator);

	protected new static string GetOrCreateMember(string name)
		=> GetOrCreateMember(name: name, value: name);

	// ReSharper disable once MethodOverloadWithOptionalParameter
	protected new static string GetOrCreateMember([CallerMemberName] string? name = null, string? value = null, Func<TSelf>? memberCreator = null)
	{
		if (name is null)
			throw new InvalidOperationException($"Empty name: Unable to retrieve resource {ThisResourceName} for language {LanguageCache.CurrentLanguageCode}.");

		if (ThisResourceName != DefaultResourceName || ThisLanguageCode == LanguageCache.CurrentLanguageCode || !ResourceEnum.IsInitialized)
			return GetOrCreateMember(
				name: name,
				valueCreator: () => value ?? throw new InvalidOperationException($"Value unknown for resource {ThisResourceName}.{name}."),
				memberCreator: memberCreator).Value;

		return GetSingleMember(name);
	}

	public new static string GetSingleMember(string name)
	{
		return TryGetSingleMember(name, out var resource)
			? resource.Value
			: throw new InvalidOperationException($"Unable to retrieve resource {name}.");
	}

	public new static bool TryGetSingleMember(string name, [NotNullWhen(true)] out IMagicEnum<string>? member)
	{
		var newResourceName = DefaultResourceName + LanguageCache.CurrentLanguageCode;

		if (!ResourceEnum.TryGetSingleMember(newResourceName, out var specificResource))
			if (!ResourceEnum.TryGetSingleMember(DefaultResourceName, out specificResource))
				throw new InvalidOperationException($"Unable to retrieve resource {newResourceName} or {DefaultResourceName}.");

		var foreignResource = (IMagicEnum<string>)specificResource.UninitializedInstance;

		return foreignResource.TryGetSingleMember(name, out member);
	}
}

[DiscoverImplementations(enumName: "ResourceEnum")]
public partial interface IResource
{
}

public partial record ResourceEnum
{
	public static bool IsInitialized { get; }

	static ResourceEnum()
	{
		IsInitialized = true;
	}
}
