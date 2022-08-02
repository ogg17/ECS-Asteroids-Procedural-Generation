using UnityEngine;

namespace TileMap
{
    [CreateAssetMenu(menuName = CoreConstants.StoragesFolder + nameof(TileMapStorage), fileName = nameof(TileMapStorage))]
    public class TileMapStorage: ScriptableObject
    {
        public GameObject tilePrefab;
    }
}