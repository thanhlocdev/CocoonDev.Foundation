using UnityEngine;
using UnityEngine.UI;

namespace CocoonDev.Foundation.Unity.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Set color alpha
        /// </summary>
        public static Color WithAlpha(this Color color, byte aValue)
        {
            color.a = aValue;

            return color;
        }

        /// <summary>
        /// Set color alpha
        /// </summary>
        public static Color WithAlpha(this Color color, float aValue)
        {
            color.a = aValue;

            return color;
        }

        /// <summary>
        /// Set color alpha (0-255)
        /// </summary>
        public static Color WithAlpha(this Color color, int aValue)
        {
            color.a = (float)aValue / 255;

            return color;
        }

        /// <summary>
        /// Convert to HEX
        /// </summary>
        public static string ToHex(this Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", (byte)(Mathf.Clamp01(color.r) * 255), (byte)(Mathf.Clamp01(color.g) * 255), (byte)(Mathf.Clamp01(color.b) * 255));
        }

        /// <summary>
        /// Set color alpha
        /// </summary>
        public static Graphic WithAlpha(this Graphic graphic, float a)
        {
            graphic.color = graphic.color.WithAlpha(a);

            return graphic;
        }

        // <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code with a preceeding #.</returns>
        public static string ToHexWithHashRGB(this Color color) =>
            "#" + color.ToHexRGB();

        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code.</returns>
        public static string ToHexRGB(this Color color) =>
            ColorUtility.ToHtmlStringRGB(color);

        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code with a preceeding #.</returns>
        public static string ToHexWithHashRGBA(this Color color) =>
            "#" + color.ToHexRGBA();

        /// <summary>
        /// Converts a color to hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code.</returns>
        public static string ToHexRGBA(this Color color) =>
            ColorUtility.ToHtmlStringRGBA(color);

        /// <summary>
        /// Sets any value of the color to a given value.
        /// </summary>
        /// <param name="color">Original Color.</param>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        /// <param name="a">Alpha.</param>
        /// <returns>Original Color with altered components.</returns>
        public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null) =>
            new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
    }
}
