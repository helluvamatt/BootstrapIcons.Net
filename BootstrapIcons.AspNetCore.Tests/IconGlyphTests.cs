using System;
using BootstrapIcons.Net;
using BootstrapIcons.Net.Extensions;
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
            Assert.Multiple(() =>
            {
                Assert.That(hasSvg, Is.True, $"the GetSvg method should always return true for {nameof(BootstrapIconGlyph)}.{glyph}");
                Assert.That(path, Is.Not.Null.Or.Not.Empty, $"the BootstrapIconGlyph.{glyph} path must have some text");
                Assert.That(width, Is.GreaterThan(0), $"the BootstrapIconGlyph.{glyph} must have a positive width");
                Assert.That(height, Is.GreaterThan(0), $"the BootstrapIconGlyph.{glyph} must have a positive width");
            });
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
        Assert.That(hasSvg, Is.False, $"the GetSvg method should always return false for {nameof(BootstrapIconGlyph)}.{nameof(BootstrapIconGlyph.None)}");
    }
}
