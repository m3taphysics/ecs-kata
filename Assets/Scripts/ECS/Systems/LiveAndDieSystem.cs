using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;
using UnityEngine;

namespace ECS.Systems
{
    public partial class LiveAndDieSystem : BaseSystem<World, float>
    {
        public LiveAndDieSystem(World world) : base(world)
        {
        }
        
        // Generates a query and calls that one automatically on BaseSystem.Update
        [Query]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Query([Data] in float t, ref LifeSpanComponent lifespan, ref VisibilityComponent visibility)
        {
            lifespan.LifeSpan += t;
            if (lifespan.LifeSpan < 5.0f) return; // only swap state every 5 seconds
            switch (visibility.State)
            {
                case VisibilityState.Visible:
                    lifespan.LifeSpan = 0;
                    visibility.BecomeInvisible();
                    break;
                
                case VisibilityState.Invisible:
                    lifespan.LifeSpan = 0;
                    visibility.BecomeVisible();
                    break;
            }
        }
    }
}
