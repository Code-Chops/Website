using Microsoft.Extensions.Caching.Memory;
using CodeChops.ImplementationDiscovery;
using CodeChops.ImplementationDiscovery.UninitializedObjects;
using CodeChops.MagicEnums.Core;
using CodeChops.Website.Client.Layout;

namespace CodeChops.Website.Client;

public interface IResource<TSelf, TImplementationEnum>
	where TSelf : class, IResource<TSelf, TImplementationEnum>
	where TImplementationEnum : MagicDiscoveredImplementationsEnum<TImplementationEnum, NewableUninitializedObject<TSelf>, TSelf>, IMagicEnumCore<TImplementationEnum, NewableUninitializedObject<TSelf>>, new()
{
	private static MemoryCache MemoryCache { get; } = new(new MemoryCacheOptions());
	
	public static TSelf Get()
	{
		var resourceName = $"{typeof(TSelf).Name[1..]}{LanguageSelector.CurrentLanguageCode.ToUpperInvariant()}";
		if (!TImplementationEnum.TryGetSingleMember(resourceName, out var resource))
			throw new InvalidOperationException($"{resourceName} not implemented.");
		
		return MemoryCache.GetOrCreate(resourceName, _ => resource.Value.CreateNewInstance());
	}
}