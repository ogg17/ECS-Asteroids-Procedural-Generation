using Leopotam.EcsLite;
using UnityEngine;

namespace TileMap
{
    public class TileMapSystem: IEcsInitSystem
    {
        private EcsWorld _world;
        public void Init(IEcsSystems systems)
        {
            SharedStorages storages = systems.GetShared<SharedStorages>();
            _world = systems.GetWorld();
            EcsPool<TileComponent> tilePool = _world.GetPool<TileComponent>();

            var size = storages.CoreStorage.tileMapConfiguration.mapSize;
            var scale = storages.CoreStorage.tileMapConfiguration.tileScale;
            var scene = storages.CoreStorage.integrationStorage.sceneBuilder;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var tileEntity = _world.NewEntity();
                    ref TileComponent tileComponent = ref tilePool.Add(tileEntity);
                    tileComponent.Id = 1;
                    tileComponent.x = i / scale;
                    tileComponent.y = j / scale;

                    var tileObj = GameObject.Instantiate(
                        storages.CoreStorage.tileMapStorage.tilePrefab,
                        new Vector3(tileComponent.x, tileComponent.y),
                        scene.transform.rotation,
                        scene.transform);
                    tileObj.GetComponent<TileView>().Entity = tileEntity;
                }
            }
        }
    }
}