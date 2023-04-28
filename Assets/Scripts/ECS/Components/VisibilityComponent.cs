﻿namespace ECS.Components
{
    public enum VisibilityState
    {
        Invisible,
        BecomingVisible,
        Visible,
        BecomingInvisible
    }

    public struct VisibilityComponent
    {
        public VisibilityState State;
        public readonly int Identity;

        private static int _identityCount;

        public VisibilityComponent(VisibilityState state)
        {
            State = state;
            Identity = _identityCount++;
        }

        public void BecomeVisible()
        {
            State = VisibilityState.BecomingVisible;
        }

        public void BecomeInvisible()
        {
            State = VisibilityState.BecomingInvisible;
        }
    }
}