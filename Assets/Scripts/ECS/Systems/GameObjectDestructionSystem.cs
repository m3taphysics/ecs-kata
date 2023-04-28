using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;

namespace ECS.Systems
{
    public class GameObjectDestructionSystem : BaseSystem<World, float>
    {
        private readonly struct DeleteGameObject : IForEachWithEntity<GameObjectComponent, DeleteEntityIntention>
        {
            private readonly IGameObjectHandler gameObjectHandler;

            public DeleteGameObject(IGameObjectHandler gameObjectHandler)
            {
                this.gameObjectHandler = gameObjectHandler;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(in Entity entity, ref GameObjectComponent gameObjectComponent,
                ref DeleteEntityIntention deleteEntityIntention)
            {
                gameObjectHandler.Destroy(gameObjectComponent.reference);
                entity.Remove<GameObjectComponent>();
            }
        }

        private readonly QueryDescription query =
            new QueryDescription().WithAll<GameObjectComponent, DeleteEntityIntention>();

        private DeleteGameObject _deleteGameObject;

        public GameObjectDestructionSystem(World world, IGameObjectHandler gameObjectHandler) : base(world)
        {
            _deleteGameObject = new DeleteGameObject(gameObjectHandler);
        }

        public override void Update(in float t)
        {
            World.InlineEntityQuery<DeleteGameObject, GameObjectComponent, DeleteEntityIntention>(in query,
                ref _deleteGameObject);
        }
    }
}