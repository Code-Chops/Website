using CodeChops.ImplementationDiscovery;
using CodeChops.MagicEnums.Core;
using CodeChops.Website.Client.Layout;
using Microsoft.Extensions.Caching.Memory;

namespace CodeChops.Website.Client.Resources;

public interface IResource<TSelf, TImplementationEnum>
	where TSelf : class, IResource<TSelf, TImplementationEnum>
	where TImplementationEnum : IImplementationsEnum<TSelf>, IMagicEnumCore<TImplementationEnum, DiscoveredObject<TSelf>>
{
	private static MemoryCache MemoryCache { get; } = new(new MemoryCacheOptions());
	
	public static TSelf Get()
	{
		var resourceName = $"{typeof(TSelf).Name[1..]}{LanguageSelector.CurrentLanguageCode.ToUpperInvariant()}";
		if (!TImplementationEnum.TryGetSingleMember(resourceName, out var resource))
			throw new InvalidOperationException($"{resourceName} not implemented.");
		
		return MemoryCache.GetOrCreate(resourceName, _ => resource.Value);
	}
}