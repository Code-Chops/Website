using System.Collections.Immutable;
using System.Text;
using CodeChops.Website.RazorComponents.Navigation.Menu;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace CodeChops.Website.Client.Layout;

public partial class LanguageSelector
{
	[Inject] private NavigationManager UriHelper { get; init; } = null!;
	[Inject] private IJSRuntime JsRuntime { get; init; } = null!;

	public string CurrentCountryFlag { get; set; } = null!;

	private MenuButtonData MenuButtonData { get; set; }

	/// <summary>
	/// The Unicode scalar offset between the ascii letter and the region code.
	/// </summary>
	private static int UnicodeScalarValueOffset { get; } // 127397
	private static ImmutableList<LanguageCode> LanguageCodeList { get; }
	private bool TriggerLanguageChangedEvents { get; set; }

	static LanguageSelector()
	{
		if (!Rune.TryGetRuneAt("🇦", 0, out var rune))
			throw new InvalidOperationException($"Could not determine {nameof(UnicodeScalarValueOffset)}.");

		UnicodeScalarValueOffset = rune.Value - new Rune('A').Value;

		LanguageCodeList = SupportedLanguageCodes.GetValues().ToImmutableList();
	}

	protected override void OnComponentInitialized()
	{
		this.MenuButtonData = new() { OnClick = (e, _) => this.ChangeLanguage(e) };
		this.SetCountryFlag();
	}

	private void ChangeLanguage(EventArgs? e)
	{
		if (e is KeyboardEventArgs { Code: not "Enter" and not "NumpadEnter" })
			return;

		this.TriggerLanguageChangedEvents = true;
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (!this.TriggerLanguageChangedEvents)
			return;

		this.TriggerLanguageChangedEvents = false;

		var index = LanguageCodeList.IndexOf(LanguageCodeCache.CurrentLanguageCode);
		var newIndex = (index + 1) % LanguageCodeList.Count;
		var newLanguageCode = LanguageCodeList[newIndex];

		LanguageCodeCache.SetCurrentLanguage(newLanguageCode);
		this.SetCountryFlag();
		await this.JsRuntime.InvokeVoidAsync("blazorCulture.set", newLanguageCode.Value);

		this.TriggerLanguageChangedEvent();
	}

	private void SetCountryFlag()
	{
		var flag = GetFlagFromCountryCode(LanguageCodeCache.CurrentLanguageCode.GetCountryCode());

		this.CurrentCountryFlag = flag;
		this.StateHasChanged();
	}

	private static string GetFlagFromCountryCode(string countryCode)
	{
		return countryCode
			.EnumerateRunes()
			.Aggregate(new StringBuilder(), (sb, rune) => sb.Append(new Rune(rune.Value + UnicodeScalarValueOffset)))
			.ToString();
	}
}
