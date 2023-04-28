using System.Collections;
using System.Collections.Generic;
using Arch.Core;
using Arch.Core.Utils;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;
using ECS.Systems;
using Implementations;
using UnityEngine;
using UnityEngine.Pool;

public class GameController : MonoBehaviour
{
    private Arch.System.Group<float> _systems;

    private World _world;

    private IVisibilityListener _visibilityListener;

    // Start is called before the first frame update
    void Start()
    {
        _visibilityListener = new VisibilityHandler();
        
        // Create a world and a group of systems which will be controlled 
        _world = World.Create();
        _systems = new Arch.System.Group<float>(
        new VisibilitySystem(_world, _visibilityListener),
        new LiveAndDieSystem(_world)
        );
        _systems.Initialize();                  // Inits all registered systems

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