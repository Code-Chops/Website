using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CodeChops.Website.RazorComponents.Resources;

 // [GenerateStringValueObject(minimumLength: 2, maximumLength: 4, 
 // 	stringComparison: StringComparison.Ordinal, valueIsNullable: false, 
 // 	stringFormat: StringFormat.Default, stringCaseConversion: StringCaseConversion.NoConversion, 
 //    propertyIsPublic: true, useRegex: false, useValidationExceptions: false)]
public partial record struct LanguageCode
{
	public string GetCountryCode()			=> this.Value.Split('-').Last();
	public string GetSimpleLanguageCode()	=> this.Value.Split('-').First();
}

/// <summary>
/// An immutable value type with a Default-Formatted string as underlying value.
/// Extends: <see cref="global::CodeChops.Website.RazorComponents.Resources.LanguageCode"/>.
/// </summary>
[StructLayout(LayoutKind.Auto)]
public readonly partial record struct LanguageCode : IValueObject, ICreatable<LanguageCode, String>, IEquatable<LanguageCode>, IComparable<LanguageCode>, IEnumerable<Char>
{
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string ToString() => this.ToDisplayString(new { this.Value });

	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int Length => this.Value.Length;

	#region ValueProperty
	/// <summary>
	/// Get the underlying structural value.
	/// </summary>
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public String Value => this._value3747 ?? String.Empty;

	/// <summary>
	/// Backing field for <see cref='Value'/>.  Don't use this field, use the Value property instead.
	/// </summary>
	[Obsolete("Don't use this field, use the Value property instead.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private readonly String _value3747 = String.Empty;
	#endregion

	#region Equals
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode() => String.GetHashCode(this.Value, StringComparison.Ordinal); 

	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool Equals(LanguageCode other) => String.Equals(this.Value, other.Value, StringComparison.Ordinal);
	#endregion

	#region Comparison
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int CompareTo(LanguageCode other) => String.Compare(this.Value, other.Value, StringComparison.Ordinal);

	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool operator <	(LanguageCode left, LanguageCode right)	=> left.CompareTo(right) <	0;
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool operator <=	(LanguageCode left, LanguageCode right)	=> left.CompareTo(right) <= 0;
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool operator >	(LanguageCode left, LanguageCode right)	=> left.CompareTo(right) >	0;
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static bool operator >=	(LanguageCode left, LanguageCode right)	=> left.CompareTo(right) >= 0;
	#endregion

	#region Casts
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static implicit operator String(LanguageCode value) => value.Value;

	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static explicit operator LanguageCode(String value) => new(value);
	#endregion


	#region Enumerator
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IEnumerator<Char> GetEnumerator() => this.Value.GetEnumerator();
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
	#endregion

	#region Constructors
	[DebuggerHidden] 
	public LanguageCode(String value, Validator? validator = null)
	{	
		validator ??= Validator.Get<LanguageCode>.Default;

		validator.GuardNotNull(value, errorCode: null);
		//validator.GuardLengthInRange(value, 2, 5, errorCode: null);

		this._value3747 = value;
	}

	#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor
	[Obsolete("Don't use this empty constructor. A String should be provided when initializing LanguageCode.", true)]
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public LanguageCode() => throw new InvalidOperationException($"Don't use this empty constructor. A String should be provided when initializing LanguageCode.");
	#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor
	#endregion

	#region Factories
	// [DebuggerHidden] 
	// [EditorBrowsable(EditorBrowsableState.Never)]
	// public static bool TryCreate(String value, out LanguageCode createdObject)
	// 	=> ICreatable<LanguageCode, String>.TryCreate(value, out createdObject, out _);
	//
	// [DebuggerHidden] 
	// [EditorBrowsable(EditorBrowsableState.Never)]
	// public static bool TryCreate(String value, out LanguageCode createdObject, out Validator validator)
	// 	=> ICreatable<LanguageCode, String>.TryCreate(value, out createdObject, out validator);

	[DebuggerHidden] 
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static LanguageCode Create(String value, Validator? validator = null) 
		=> new(value, validator);
	#endregion

	#region TypeSpecific
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Char? this[int index] 
		=> Validator.Get<LanguageCode>.Default.GuardInRange(this.Value, index, errorCode: null)!;
	#endregion
}

#pragma warning restore CS0618 // Member is obsolete (level 2)
#pragma warning restore CS0612 // Is deprecated (level 1)
#nullable restore
