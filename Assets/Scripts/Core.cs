using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite;
using TileMap;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private CoreStorage coreStorage;
    private SharedStorages _storages;
    
    private EcsWorld _world;
    private EcsSystems _systems;
    
    // Start is called before the first frame update
    void Start()
    {
        _storages = new(coreStorage);
        _world = new();
        _systems = new(_world, _storages);
        _systems
            .Add(new TileMapInitSystem())
            .Add(new TileClickSystem())
            .Add(new TileClickedSystem())
            .Init();
    }

    // Update is called once per frame
    void Update()
    {
        _systems?.Run();
    }
    
    // OnDestroy is called before the GameObject is destroyed
    void OnDestroy () {
        // Destroy systems
        if (_systems != null) {
            _systems.Destroy ();
            _systems = null;
        }
        // Clear world
        if (_world != null) {
            _world.Destroy ();
            _world = null;
        }
    }
    
}
