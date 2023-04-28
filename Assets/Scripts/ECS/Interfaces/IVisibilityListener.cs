using ECS.Components;
using UnityEngine.UIElements;

namespace ECS.Interfaces
{
    public interface IVisibilityListener
    {
        public void OnChange(VisibilityComponent visibility);
    }
}
