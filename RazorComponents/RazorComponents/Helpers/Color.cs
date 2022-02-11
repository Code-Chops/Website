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

	private RGB Value { get; }

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
		this.Value = rgbColor;
	}

	public Color GetWhiterColor(byte delta = 40)
	{
		var r = GetWhiterPrimaryColor(this.Value.R);
		var g = GetWhiterPrimaryColor(this.Value.G);
		var b = GetWhiterPrimaryColor(this.Value.B);
		var color = new Color(r, g, b);

		return color;


		byte GetWhiterPrimaryColor(byte primaryColor)
		{
			var addition = primaryColor + delta;
			return addition > 255 ? (byte)255 : (byte)addition;
		}
	}
}