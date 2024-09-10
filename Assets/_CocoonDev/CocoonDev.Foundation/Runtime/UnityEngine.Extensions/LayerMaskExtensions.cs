using UnityEngine;

namespace CocoonDev.Foundation.Unity.Extensions
{
    /// <summary>
    /// Extension Methods used on LayerMasks.
    /// </summary>
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Checks if an objects layer matches any layer in a layer mask
        /// </summary>
        public static bool ContainsLayer(this LayerMask layerMask, int layer) => (layerMask & (1 << layer)) > 0;
    }
}
