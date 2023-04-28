using UnityEngine;

namespace ECS.Interfaces
{
    public interface IGameObjectHandler
    {
        GameObject Instantiate(Vector3 position, Quaternion rotation);
        GameObject Destroy(GameObject gameObject);
    }
}