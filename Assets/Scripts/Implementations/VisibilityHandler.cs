using System.Collections.Generic;
using System.Collections.ObjectModel;
using ECS.Components;
using ECS.Interfaces;
using UnityEngine;
using UnityEngine.Pool;

namespace Implementations
{
    /// <summary>
    /// Handles the Creation/Deletion of the GameObject representing the ECS view transform
    /// </summary>
    public class VisibilityHandler : IVisibilityListener
    {
        private Dictionary<int, GameObject> _entityDictionary;
        private ObjectPool<GameObject> _entityPool;
        private GameObject _poolParent;

        public VisibilityHandler()
        {
            _poolParent = new GameObject("PooledGO");
            _entityDictionary = new Dictionary<int, GameObject>();
            _entityPool = new ObjectPool<GameObject>(() =>
                {
                    var go =  new GameObject
                    {
                        transform =
                        {
                            parent = _poolParent!.transform
                        }
                    };
                    return go;
                },
                (GameObject obj) =>
                {
                    obj.SetActive(true);
                }, (GameObject obj) =>
                {
                    obj.SetActive(false);
                });
        }

        public void OnChange(VisibilityComponent visibility)
        {
            if (visibility.State == VisibilityState.Visible)
            {
                _entityDictionary[visibility.Identity] = _entityPool.Get();
            }

            if (visibility.State == VisibilityState.Invisible)
            {
                _entityPool.Release(_entityDictionary[visibility.Identity]);
            }
        }
    }
}
