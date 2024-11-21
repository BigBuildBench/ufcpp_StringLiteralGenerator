﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace StringLiteralGenerator;

public partial class Utf8StringLiteralGenerator
{
    private const string attributesText = @"// <auto-generated />
using System;
namespace StringLiteral
{
    [System.Diagnostics.Conditional(""COMPILE_TIME_ONLY"")]
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class Utf8Attribute : Attribute
    {
        public Utf8Attribute(string s) { }
    }

    [System.Diagnostics.Conditional(""COMPILE_TIME_ONLY"")]
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class HexAttribute : Attribute
    {
        public HexAttribute(string s) { }
    }

    [System.Diagnostics.Conditional(""COMPILE_TIME_ONLY"")]
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    sealed class Base64Attribute : Attribute
    {
        public Base64Attribute(string s) { }
    }
}
";

    private static void AddAttribute(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource("StringLiteralAttributes", SourceText.From(attributesText, Encoding.UTF8));
    }
}