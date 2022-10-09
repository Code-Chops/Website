using System.Runtime.CompilerServices;
using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums;

namespace CodeChops.Website.Client.Resources;


public abstract record Resource<TSelf> : MagicStringEnum<TSelf>, IResource
	where TSelf : Resource<TSelf>, new()
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
	}

	protected new static string CreateMember(string? value = null, Func<TSelf>? memberCreator = null, [CallerMemberName] string? name = null)
		=> GetOrCreateMember(name: name, value: value, memberCreator);
	
	protected new static string CreateMember<TMember>(Func<TMember>? memberCreator = null, string? value = null, [CallerMemberName] string? name = null)
		where TMember : TSelf
		=> GetOrCreateMember<TMember>(name: name!, value: value, memberCreator);
	
	protected new static string GetOrCreateMember(string name) 
		=> GetOrCreateMember<TSelf>(name: name, value: name);

	protected new static string GetOrCreateMember([CallerMemberName] string? name = null, string? value = null, Func<TSelf>? memberCreator = null)
	{
		if (name is null) 
			throw new InvalidOperationException($"Empty name: Unable to retrieve resource {ThisResourceName} for language {LanguageCache.CurrentLanguageCode}.");

		if (ThisResourceName != DefaultResourceName || ThisLanguageCode == LanguageCache.CurrentLanguageCode)
			return GetOrCreateMember<TSelf>(name, valueCreator: () => value ?? throw new InvalidOperationException($"Value unknown for resource {ThisResourceName}.{name}."));

		var newResourceName = DefaultResourceName + LanguageCache.CurrentLanguageCode;

		if (!IResourceEnum.TryGetSingleMember(newResourceName, out var specificResource))
		{
			if (!IResourceEnum.TryGetSingleMember(DefaultResourceName, out specificResource))
				return null!; //throw new InvalidOperationException($"Unable to retrieve resource {newResourceName} or {DefaultResourceName}.");
		}

		var foreignResource = (IMagicEnum<string>)specificResource.Value.UninitializedInstance;
		
		return foreignResource.TryGetSingleMember(name, out var resource)
			? resource.Value
			: throw new InvalidOperationException($"Unable to retrieve resource {specificResource}.{name}.");
	}
	
	public new static string GetSingleMember(string memberName)
		=> GetOrCreateMember(memberName);
}

[DiscoverImplementations]
public partial interface IResource
{
}