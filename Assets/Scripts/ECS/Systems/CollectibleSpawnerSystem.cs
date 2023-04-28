using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.System;
using ECS.Components;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.Systems
{
    public partial class CollectibleSpawnerSystem : BaseSystem<World, float>
    {
        public CollectibleSpawnerSystem(World world) : base(world)
        {
        }

        // Generates a query and calls that one automatically on BaseSystem.Update
        [Query]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Query([Data] in float t, ref CollectibleSpawnerComponent spawner)
        {
            var query = new QueryDescription().WithAll<CollectibleComponent>();
            var currentCollectibles = World.CountEntities(query);

            int amountToSpawn = Math.Max(0, spawner .maxAmount - currentCollectibles);

            for (int i = 0; i < amountToSpawn; i++)
            {
                var collectible = new CollectibleComponent();
                var transform = new TransformComponent();

                transform.position.x = Random.Range(spawner.area.xMin, spawner.area.xMax);
                transform.position.z = Random.Range(spawner.area.yMin, spawner.area.yMax);
                transform.rotation = Quaternion.identity;
                transform.scale = Vector3.one;

                World.Create(collectible, transform);
            }
        }
    }
}