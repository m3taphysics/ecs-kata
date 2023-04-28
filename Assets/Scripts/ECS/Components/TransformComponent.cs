using UnityEngine;

namespace ECS.Components
{
    public struct TransformComponent
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }
}