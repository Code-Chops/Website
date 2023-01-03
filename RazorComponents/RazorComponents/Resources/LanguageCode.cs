namespace CodeChops.Website.RazorComponents.Resources;

[GenerateStringValueObject(minimumLength: 2, maximumLength: 5, 
 	stringComparison: StringComparison.Ordinal, valueIsNullable: false, 
 	stringFormat: StringFormat.Default, stringCaseConversion: StringCaseConversion.NoConversion, 
    propertyIsPublic: true, useRegex: false, useValidationExceptions: false)]
public partial record struct LanguageCode
{
	public string GetCountryCode()			=> this.Value.Split('-').Last();
	public string GetSimpleLanguageCode()	=> this.Value.Split('-').First();
}
