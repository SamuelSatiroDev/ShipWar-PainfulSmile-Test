using System.Collections.Generic;
using UnityEngine;

namespace ExtensionMethods
{
    public static class PoolingExtension
    {
        public static void Pooling(this List<GameObject> PoolingList, GameObject Prefab, Transform Parent, Vector3 SpawnPosition, Quaternion ObjectRotation, bool StartInstantiated, int Limited)
        {
            if (Prefab == null || Parent == null)
                return;

            if (StartInstantiated && PoolingList.Count < Limited)
            {
                for (int i = 0; i < Limited; i++)
                {
                    PoolingList.Add(InstatiateMethod(Prefab, Parent, SpawnPosition, ObjectRotation));
                    PoolingList[i].SetActive(false);
                }
            }

            bool _isDisable = false;
            for (byte i = 0; i < PoolingList.Count; i++)
            {
                if (!PoolingList[i].activeInHierarchy)
                {
                    _isDisable = true;
                    PoolingList[i].SetActive(true);
                    SetTransform(PoolingList[i].transform, SpawnPosition, ObjectRotation);
                    break;
                }
            }

            if (_isDisable || Parent.childCount >= Limited)
                return;

            PoolingList.Add(InstatiateMethod(Prefab, Parent, SpawnPosition, ObjectRotation));
        }

        private static GameObject InstatiateMethod(GameObject prefab, Transform parent, Vector3 position, Quaternion rotation)
        {
            GameObject _newObj = MonoBehaviour.Instantiate(prefab, parent);
            SetTransform(_newObj.transform, position, rotation);
            return _newObj;
        }

        private static void SetTransform(Transform transformPrefab, Vector3 position, Quaternion rotation)
        {
            transformPrefab.gameObject.SetActive(true);
            transformPrefab.position = position;
            transformPrefab.rotation = rotation;
        }
    }
}