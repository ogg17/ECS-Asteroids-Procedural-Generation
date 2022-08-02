using TileMap;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(CoreStorage), fileName = nameof(CoreStorage))]
public class CoreStorage: ScriptableObject
{
    public IntegrationStorage integrationStorage;
    
    public TileMapStorage tileMapStorage;
    public TileMapConfiguration tileMapConfiguration;
    
}