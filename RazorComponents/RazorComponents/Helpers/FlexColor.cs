using ColorHelper;

namespace CodeChops.Website.RazorComponents.Helpers;

public readonly record struct FlexColor
{
	/// <summary>
	/// HEX representation.
	/// </summary>
	public override string ToString() => this.Hex;

	public static FlexColor White { get; } = new(255, 255, 255);

	public string Hex { get; }
	
	/// <summary>
	/// Format: "{r}, {g}, {b}"
	/// </summary>
	public string Rgb { get; }

	private RGB Value { get; }

	public FlexColor(byte r, byte g, byte b)
		: this(new RGB(r, g, b))
	{
	}

	public FlexColor(RGB rgbColor)
		: this(ColorConverter.RgbToHex(rgbColor), rgbColor)
	{
	}

	public FlexColor(string hexColor)
		: this(new HEX(hexColor))
	{
	}

	public FlexColor(HEX hexColor) 
		: this(hexColor, ColorConverter.HexToRgb(hexColor))
	{
	}

	public FlexColor(ColorName colorName)
		: this(colorName.ToHex(), colorName.ToRgb())
	{
	}

	private FlexColor(HEX hexColor, RGB rgbColor)
	{
		this.Hex = $"#{hexColor}";
		this.Rgb = $"{rgbColor.R}, {rgbColor.G}, {rgbColor.B}";
		this.Value = rgbColor;
	}

	public readonly FlexColor ChangeBrightness(int delta = 40)
	{
		var r = ChangeBrightnessOfPrimaryColor(this.Value.R);
		var g = ChangeBrightnessOfPrimaryColor(this.Value.G);
		var b = ChangeBrightnessOfPrimaryColor(this.Value.B);
		var color = new FlexColor(r, g, b);

		return color;


		byte ChangeBrightnessOfPrimaryColor(byte primaryColor)
		{
			var newColor = primaryColor + delta;
			if (newColor > 255) return 255;
			if (newColor < 0) return 0;

			return (byte)newColor;
		}
	}
}