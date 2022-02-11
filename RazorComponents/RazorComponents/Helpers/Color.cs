using ColorHelper;

namespace CodeChops.Website.RazorComponents.Helpers;

public record struct Color
{
	/// <summary>
	/// HEX representation.
	/// </summary>
	public override string ToString() => this.Hex;

	public string Hex { get; }
	
	/// <summary>
	/// Format: "{r}, {g}, {b}"
	/// </summary>
	public string Rgb { get; }

	public Color(byte r, byte g, byte b)
		: this(new RGB(r, g, b))
	{
	}

	public Color(RGB rgbColor)
		: this(ColorConverter.RgbToHex(rgbColor), rgbColor)
	{
	}

	public Color(string hexColor)
		: this(new HEX(hexColor))
	{
	}

	public Color(HEX hexColor) 
		: this(hexColor, ColorConverter.HexToRgb(hexColor))
	{
	}

	public Color(ColorName colorName)
		: this(colorName.ToHex(), colorName.ToRgb())
	{
	}

	private Color(HEX hexColor, RGB rgbColor)
	{
		this.Hex = $"#{hexColor}";
		this.Rgb = $"{rgbColor.R}, {rgbColor.G}, {rgbColor.B}";
	}
}