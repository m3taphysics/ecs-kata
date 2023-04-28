using UnityEngine;

namespace ECS.Interfaces
{
    public interface IGameObjectHandler
    {
        GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation);
    }
}