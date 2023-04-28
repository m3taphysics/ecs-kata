using System.Runtime.CompilerServices;
using Arch.Core;
using Arch.System;
using ECS.Components;
using ECS.Interfaces;

namespace ECS.Systems
{
    public partial class VisibilitySystem : BaseSystem<World, float>
    {
        private readonly IVisibilityListener _listener;
        public VisibilitySystem(World world, IVisibilityListener listener) : base(world)
        {
            _listener = listener;
        }
        
        // Generates a query and calls that one automatically on BaseSystem.Update
        [Query]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Query([Data] in float t, ref VisibilityComponent visibility)
        {
            switch (visibility.State)
            {
                case VisibilityState.BecomingInvisible:
                    visibility.State = VisibilityState.Invisible;
                    _listener.OnChange(visibility);
                    break;
                
                case VisibilityState.BecomingVisible:
                    visibility.State = VisibilityState.Visible;
                    _listener.OnChange(visibility);
                    break;
            }
        }
    }
}
