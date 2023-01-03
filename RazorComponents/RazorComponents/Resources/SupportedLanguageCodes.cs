using CodeChops.MagicEnums;

namespace CodeChops.Website.RazorComponents.Resources;

public record SupportedLanguageCodes : MagicCustomEnum<SupportedLanguageCodes, LanguageCode>
{
 	public static SupportedLanguageCodes CreateMember(LanguageCode languageCode) 
		=> CreateMember(value: languageCode, name: languageCode.Value);
}
