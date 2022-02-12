using System;
using BootstrapIcons.Net;
using BootstrapIcons.Net.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace BootstrapIcons.AspNetCore.Tests;

public class IconGlyphTests
{
    [Test]
    public void Test_AllGlyphsHavePaths()
    {
        // Arrange
        foreach (BootstrapIconGlyph glyph in Enum.GetValues<BootstrapIconGlyph>())
        {
            if (glyph == BootstrapIconGlyph.None) continue;

            // Act
            bool hasSvg = glyph.GetSvg(out string? path, out int width, out int height);

            // Assert
            hasSvg.Should().BeTrue($"the GetSvg method should always return true for {nameof(BootstrapIconGlyph)}.{glyph}");
            path.Should().NotBeNullOrWhiteSpace("the BootstrapIconGlyph.{0} path must have some text", glyph);
            width.Should().BePositive("the BootstrapIconGlyph.{0} must have a positive width", glyph);
            height.Should().BePositive("the BootstrapIconGlyph.{0} must have a positive width", glyph);
        }
    }

    [Test]
    public void Test_NoneHasNoPath()
    {
        // Arrange
        const BootstrapIconGlyph glyph = BootstrapIconGlyph.None;

        // Act
        bool hasSvg = glyph.GetSvg(out _, out _, out _);

        // Assert
        hasSvg.Should().BeFalse($"the GetSvg method should always return false for {nameof(BootstrapIconGlyph)}.{nameof(BootstrapIconGlyph.None)}");
    }
}
