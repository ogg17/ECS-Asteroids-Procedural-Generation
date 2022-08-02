using UnityEngine;

namespace TileMap
{
    [CreateAssetMenu(menuName = CoreConstants.ParametersFolder + nameof(TileMapConfiguration), fileName = nameof(TileMapConfiguration))]
    public class TileMapConfiguration : ScriptableObject
    {
        public int mapSize = 100;
        public float tileScale = 5f;
    }
}
