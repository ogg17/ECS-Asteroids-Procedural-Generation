using Leopotam.EcsLite;

namespace TileMap
{
    public class TileClickedSystem: IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            var filter = world.Filter<TileComponent>().Inc<ViewComponent>().Inc<TileIsClickComponent>().End();
            var views = world.GetPool<ViewComponent>(); 
            var tilesIsClick = world.GetPool<TileIsClickComponent>();

            foreach (var entity in filter)
            {
                ref TileIsClickComponent tileIsClick = ref tilesIsClick.Get(entity);
                ref ViewComponent view = ref views.Get(entity);
                if (tileIsClick.IsClick)
                {
                    view.View.gameObject.SetActive(false);
                }
            }
        }
    }
}