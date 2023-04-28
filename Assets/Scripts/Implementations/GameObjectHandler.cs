using ECS.Interfaces;
using UnityEngine;

namespace Implementations
{
    public class GameObjectHandler : IGameObjectHandler
    {
        private readonly GameObject collectiblePrefab;

        public GameObject Instantiate(string prefabReferece, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(Resources.Load<GameObject>(prefabReferece), position, rotation);
        }

        public void Destroy(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}