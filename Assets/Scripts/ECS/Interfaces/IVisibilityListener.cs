using ECS.Components;

namespace ECS.Interfaces
{
    public interface IVisibilityListener
    {
        public void OnChange(VisibilityComponent visibility);
    }
}
