using CodeChops.ImplementationDiscovery.Attributes;
using CodeChops.MagicEnums;
using CodeChops.Website.Client.Pages.About;

namespace CodeChops.Website.Client.Resources;

[DiscoverImplementations]
public partial interface IGeneralResource : IResource<IGeneralResource, IGeneralResourceEnum>
{
	string PageNotFound { get; }
}

public record GeneralResourceEN : MagicStringEnum<AboutResourceEN>, IGeneralResource
{
	public string PageNotFound { get; } = GetOrCreateMember<AboutResourceEN>(@"Sorry, this page doest not exist.");
}

public record GeneralResourceNL : MagicStringEnum<AboutResourceNL>, IGeneralResource
{
	public string PageNotFound { get; } = CreateMember(@"KvK-nummer: 86790390 - btw-nummer: NL004317143B09");
}