using UnityEngine;

namespace TileMap
{
    [CreateAssetMenu(menuName = CoreConstants.ParametersFolder + nameof(TileMapConfiguration), fileName = nameof(TileMapConfiguration))]
    public class TileMapConfiguration : ScriptableObject
    {
        //public int mapSize = 100;
        public float tileScale = 5f;
        public int radius = 10;
        public float noiseScale = 0.5f;
    }
}
