using Arch.Core;
using ECS.Components;
using ECS.Interfaces;
using ECS.Systems;
using Implementations;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Arch.System.Group<float> _systems;
    
    // ECS
    private World _world;

    // Interfaces
    private IVisibilityListener _visibilityListener;

    // Start is called before the first frame update
    void Start()
    {
        _visibilityListener = new VisibilityHandler();
        
        // Create a world and a group of systems which will be controlled 
        _world = World.Create();
        _systems = new Arch.System.Group<float>(
        new VisibilitySystem(_world, _visibilityListener)
        );
        _systems.Initialize();                  // Inits all registered systems

        // Create 1000 entities with the VisibilityComponent and LifeSpanComponent
        for (int i = 0; i < 1000; i++)
            _world.Create(new VisibilityComponent(VisibilityState.BecomingVisible), new LifeSpanComponent());
    }
    
    void Update()
    {
        _systems.BeforeUpdate(Time.deltaTime);    // Calls .BeforeUpdate on all systems ( can be overriden )
        _systems.Update(Time.deltaTime);          // Calls .Update on all systems ( can be overriden )
        _systems.AfterUpdate(Time.deltaTime);     // Calls .AfterUpdate on all System ( can be overriden )
        _systems.Dispose();                     // Calls .Dispose on all systems ( can be overriden )
    }
}
