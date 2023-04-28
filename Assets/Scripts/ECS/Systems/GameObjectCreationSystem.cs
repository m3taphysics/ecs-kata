using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;

namespace ECS.Systems
{
    public class GameObjectCreationSystem : BaseSystem<World, float>
    {
        private readonly struct CreateGameObject : IForEachWithEntity<TransformComponent, PrefabReferenceComponent>
        {
            private readonly IGameObjectHandler gameObjectHandler;

            public CreateGameObject(IGameObjectHandler gameObjectHandler)
            {
                this.gameObjectHandler = gameObjectHandler;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(in Entity entity, ref TransformComponent transform,
                ref PrefabReferenceComponent prefabReferenceComponent)
            {
                var component = new GameObjectComponent();
                component.reference = gameObjectHandler.Instantiate(prefabReferenceComponent.gameObjectReference, transform.position,
                    transform.rotation);
                entity.Add(component);
            }
        }

        private readonly QueryDescription query = new QueryDescription()
            .WithAll<TransformComponent, PrefabReferenceComponent>().WithNone<GameObjectComponent>();

        private CreateGameObject _createGameObject;

        public GameObjectCreationSystem(World world, IGameObjectHandler gameObjectHandler) : base(world)
        {
            _createGameObject = new CreateGameObject(gameObjectHandler);
        }

        public override void Update(in float t)
        {
            World.InlineEntityQuery<CreateGameObject, TransformComponent, PrefabReferenceComponent>(in query,
                ref _createGameObject);
        }
    }
}