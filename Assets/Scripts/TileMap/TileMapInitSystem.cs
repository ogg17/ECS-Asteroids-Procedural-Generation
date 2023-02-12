using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace TileMap
{
    public class TileMapInitSystem: IEcsInitSystem
    {
        private EcsWorld _world;
        public void Init(IEcsSystems systems)
        {
            SharedStorages storages = systems.GetShared<SharedStorages>();
            _world = systems.GetWorld();
            EcsPool<TileComponent> tilePool = _world.GetPool<TileComponent>();
            EcsPool<ViewComponent> viewPool = _world.GetPool<ViewComponent>();
            EcsPool<TileIsClickComponent> tileClickPool = _world.GetPool<TileIsClickComponent>();

            var radius = storages.CoreStorage.tileMapConfiguration.radius;
            var scale = storages.CoreStorage.tileMapConfiguration.tileScale;
            var noiseScale = storages.CoreStorage.tileMapConfiguration.noiseScale;
            var scene = storages.CoreStorage.integrationStorage.sceneBuilder;

            var PNoiseFloat2 = new float2(0, 0);
            var size = radius;
            
            for (int i = -size; i < size; i++)
            {
                for (int j = -size; j < size; j++)
                {
                    var x = PNoiseFloat2.x = i / scale;
                    var y = PNoiseFloat2.y = j / scale;

                    var noiseRadius = radius + (noise.cnoise(PNoiseFloat2) - 1) * noiseScale;

                    if (IsCircleCoordinates(i, j, noiseRadius))
                    {
                        var tileEntity = _world.NewEntity();
                        ref TileComponent tileComponent = ref tilePool.Add(tileEntity);
                        ref ViewComponent viewComponent = ref viewPool.Add(tileEntity);
                        ref TileIsClickComponent clickComponent = ref tileClickPool.Add(tileEntity);
                        
                        tileComponent.Id = 1;
                        tileComponent.x = x;
                        tileComponent.y = y;
                        clickComponent.IsClick = false;

                        var tileObj = GameObject.Instantiate(
                            storages.CoreStorage.tileMapStorage.tilePrefab,
                            new Vector3(tileComponent.x, tileComponent.y),
                            scene.transform.rotation,
                            scene.transform);

                        viewComponent.View = tileObj.GetComponent<TileView>();
                    }
                }
            }
        }

        private bool IsCircleCoordinates(float x, float y, float r)
        {
            return x * x + y * y <= r * r;
        }
    }
}