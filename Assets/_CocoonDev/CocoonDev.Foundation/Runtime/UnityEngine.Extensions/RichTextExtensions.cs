using UnityEngine;

namespace CocoonDev.Foundation.Unity.Extensions
{
    public static class RichTextExtensions
    {
        public static string Bold(this string text) => $"<b>{text}</b>";
        public static string Italic(this string text) => $"<i>{text}</i>";
        public static string Color(this string text, Color color) => $"<color={color.ToHexWithHashRGB()}>{text}</color>";
        public static string Size(this string text, int size) => $"<size={size}>{text}</size>";
    }
}
