using Arch.Core;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;
using ECS.Systems;
using Implementations;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Group<float> _systems;

    // ECS
    private World _world;

    // Interfaces
    private GameObjectHandler _gameObjectHandler;

    // Start is called before the first frame update
    private void Start()
    {
        _gameObjectHandler = new GameObjectHandler();

        // Create a world and a group of systems which will be controlled 
        _world = World.Create();
        _systems = new Group<float>(
                        new CollectibleSpawnerSystem(_world),
                        new GameObjectCreationSystem(_world, _gameObjectHandler),
                        new GameObjectDestructionSystem(_world, _gameObjectHandler),
                        new DeleteEntitySystem(_world)
        );
        _systems.Initialize(); // Inits all registered systems

        _world.Create(new CollectibleSpawnerComponent(){ area = new Rect(-10,-10,20,20), maxAmount = 50});
    }

    private void Update()
    {
        _systems.BeforeUpdate(Time.deltaTime); // Calls .BeforeUpdate on all systems ( can be overriden )
        _systems.Update(Time.deltaTime); // Calls .Update on all systems ( can be overriden )
        _systems.AfterUpdate(Time.deltaTime); // Calls .AfterUpdate on all System ( can be overriden )
        _systems.Dispose(); // Calls .Dispose on all systems ( can be overriden )
    }
}