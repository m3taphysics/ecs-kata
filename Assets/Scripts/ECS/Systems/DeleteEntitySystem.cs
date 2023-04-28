using Arch.Core;
using Arch.System;
using ECS.Components;

namespace ECS.Systems
{
    public class DeleteEntitySystem : BaseSystem<World, float>
    {
        public DeleteEntitySystem(World world) : base(world)
        {
        }

        public override void AfterUpdate(in float t)
        {
            World.Destroy(new QueryDescription().WithAll<DeleteEntityIntention>());
        }
    }
}