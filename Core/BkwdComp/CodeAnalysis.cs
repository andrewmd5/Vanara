﻿namespace System.Diagnostics.CodeAnalysis;

#if NET40_OR_GREATER || NETSTANDARD && !NET5_0_OR_GREATER
/// <summary>Specifies that null is allowed as an input even if the corresponding type disallows it.</summary>
/// <remarks>
/// To override a method that has a parameter annotated with this attribute, use the <c>?</c> operator. For example: <c>override
/// ISet&lt;Enum&gt; ReadJson(JsonReader reader, Type objectType, ISet&lt;Enum&gt;? existingValue, bool hasExistingValue, JsonSerializer
/// serializer)</c>. For more information, see Nullable static analysis in the C# guide.
/// </remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
public sealed class AllowNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="AllowNullAttribute"/> class.</summary>
	public AllowNullAttribute() { }
}

/// <summary>Specifies that null is disallowed as an input even if the corresponding type allows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
public sealed class DisallowNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="DisallowNullAttribute"/> class.</summary>
	public DisallowNullAttribute() { }
}

/// <summary>Specifies that an output may be <see langword="null"/> even if the corresponding type disallows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
public sealed class MaybeNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="MaybeNullAttribute" /> class.</summary>
	public MaybeNullAttribute() { }
}

/// <summary>Specifies that when a method returns ReturnValue, the parameter may be null even if the corresponding type disallows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class MaybeNullWhenAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="MaybeNullWhenAttribute"/> class.</summary>
	/// <param name="returnValue">
	/// The return value condition. If the method returns this value, the associated parameter may be <see langword="null"/>.
	/// </param>
	public MaybeNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

	/// <summary>Gets the return value condition.</summary>
	/// <value>The return value condition. If the method returns this value, the associated parameter may be <see langword="null"/>.</value>
	public bool ReturnValue { get; }
}

/// <summary>
/// Specifies that an output may be null even if the corresponding type disallows it. Specifies that an input argument was not null when the
/// call returns.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
public sealed class NotNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="NotNullAttribute" /> class.</summary>
	public NotNullAttribute() { }
}

/// <summary>Specifies that when a method returns ReturnValue, the parameter will not be null even if the corresponding type allows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class NotNullWhenAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="NotNullWhenAttribute"/> class.</summary>
	/// <param name="returnValue">
	/// The return value condition. If the method returns this value, the associated parameter will not be <see langword="null"/>.
	/// </param>
	public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

	/// <summary>Gets the return value condition.</summary>
	/// <value>The return value condition. If the method returns this value, the associated parameter will not be <see langword="null"/>.</value>
	public bool ReturnValue { get; }
}
#endif

#if NET40_OR_GREATER || NETSTANDARD || NETCOREAPP3_1_OR_GREATER && !NET5_0_OR_GREATER
/// <summary>
/// Specifies that the method or property will ensure that the listed field and property members have values that aren't <see langword="null"/>.
/// </summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
public sealed class MemberNotNullAttribute : Attribute
{
	/// <summary>Initializes the attribute with a field or property member.</summary>
	/// <param name="member">The field or property member that is promised to be not-null.</param>
	public MemberNotNullAttribute(string member) => Members = new[] { member };

	/// <summary>Initializes the attribute with the list of field and property members.</summary>
	/// <param name="members">The list of field and property members that are promised to be not-null.</param>
	public MemberNotNullAttribute(params string[] members) => Members = members;

	/// <summary>Gets field or property member names.</summary>
	public string[] Members { get; }
}
#endif