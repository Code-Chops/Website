using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums;
using CodeChops.MagicEnums.Core;
using CodeChops.Website.Client.Layout;
using Microsoft.Extensions.Caching.Memory;

namespace CodeChops.Website.Client.Resources;

public interface IResourceManager<TSelf, TImplementationEnum>
	where TSelf : IResourceManager<TSelf, TImplementationEnum>
	where TImplementationEnum : ImplementationsEnum<TImplementationEnum, TSelf>, IMagicEnumCore<TImplementationEnum, DiscoveredObject<TSelf>>, new()
{
	private static MemoryCache MemoryCache { get; } = new(new MemoryCacheOptions());
	
	public static TSelf GetResource()
	{
		var resourceName = $"{typeof(TSelf).Name.TrimStart('I')}{LanguageSelector.CurrentLanguageCode.ToUpperInvariant()}";
		if (!TImplementationEnum.TryGetSingleMember(resourceName, out var resource))
			throw new InvalidOperationException($"{resourceName} not implemented.");
		
		return MemoryCache.GetOrCreate(resourceName, _ => resource.Value.UninitializedInstance);
	}

	public static string? GetString(string key) 
		=> ((IMagicEnum<string>)GetResource()).TryGetSingleMember(key, out var member) ? member.Value : null;
}

public abstract record Resource<TBase> : MagicStringEnum<TBase> 
	where TBase :	Resource<TBase>
{
}

[DiscoverImplementations] 
public partial interface IResource
{
}