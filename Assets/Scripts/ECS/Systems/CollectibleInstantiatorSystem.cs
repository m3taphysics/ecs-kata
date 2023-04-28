using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;
using Implementations;
using UnityEngine;

namespace ECS.Systems
{
    public partial class CollectibleInstantiatorSystem : BaseSystem<World, float>
    {
        private readonly IGameObjectHandler gameObjectHandler;
        public CollectibleInstantiatorSystem(World world, IGameObjectHandler gameObjectHandler) : base(world)
        {
            this.gameObjectHandler = gameObjectHandler;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Update([Data] in float t)
        {
            var query = new QueryDescription().WithAll<TransformComponent, CollectibleComponent>().WithNone<GameObjectComponent>();

            List<Entity> entities = new List<Entity>();
            World.GetEntities(query, entities);
            
            foreach (var entity in entities)
            {
                ref var transform = ref entity.Get<TransformComponent>();
                GameObjectComponent gameObjectComponent = new ()
                {
                    reference = gameObjectHandler.Instantiate(transform.position, transform.rotation)
                };
                World.Add(entity, gameObjectComponent);
            }
        }
    }
}