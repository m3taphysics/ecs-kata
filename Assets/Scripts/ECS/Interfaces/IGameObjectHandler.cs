using UnityEngine;

namespace ECS.Interfaces
{
    public interface IGameObjectHandler
    {
        GameObject Instantiate(string prefabReference, Vector3 position, Quaternion rotation);

        void Destroy(GameObject gameObject);
    }
}