using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;
using UnityEngine;

namespace ECS.Systems
{
    public class CollectibleCreationSystem : BaseSystem<World, float>
    {
        private readonly struct CreateGameObject : IForEachWithEntity<TransformComponent, CollectibleComponent>
        {
            private readonly IGameObjectHandler gameObjectHandler;
            private readonly GameObject prefab;
            public CreateGameObject(IGameObjectHandler gameObjectHandler, GameObject prefab)
            {
                this.gameObjectHandler = gameObjectHandler;
                this.prefab = prefab;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(in Entity entity, ref TransformComponent transform, ref CollectibleComponent collectible)
            {
                gameObjectHandler.Instantiate(prefab, transform.position, transform.rotation);
            }
        }

        private readonly QueryDescription query = new QueryDescription().WithAll<TransformComponent>().WithNone<GameObjectComponent>();
        private CreateGameObject _createGameObject;

        public CollectibleCreationSystem(World world, IGameObjectHandler gameObjectHandler) : base(world)
        {
            _createGameObject = new CreateGameObject(gameObjectHandler, GetPrefab());
        }

        public override void Update(in float t)
        {
            World.InlineQuery<CreateGameObject, TransformComponent, CollectibleComponent>(in query, ref _createGameObject);   
        }

        protected GameObject GetPrefab()
        {
            return null;
        }
    }
}