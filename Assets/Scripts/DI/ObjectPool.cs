using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ObjectPool
{
    private Dictionary<string, Pool> _pools = new();

    public ObjectPool()
    {
        Debug.Log("ObjectPool initialized");
    }

    public void Preload(GameObject prefab, Transform container, int count)
    {
        InitPool(prefab, container);
        GameObject[] objs = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            objs[i] = Spawn(prefab, Vector3.zero, Quaternion.identity, container);
        }

        for (int i = 0; i < count; i++)
        {
            Despawn(objs[i]);
        }
    }

    private void InitPool(GameObject prefab, Transform container)
    {
        if (prefab != null && !_pools.ContainsKey(prefab.name))
        {
            _pools[prefab.name] = new Pool(prefab, container);
        }
    }

    public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform container)
    {
        InitPool(prefab, container);
        return _pools[prefab.name].Spawn(pos, rot, container);
    }

    public void Despawn(GameObject obj)
    {
        if (_pools.ContainsKey(obj.name))
        {
            _pools[obj.name].Despawn(obj);
        }
        else
        {
            Object.Destroy(obj);
        }
    }

    class Pool
    {
        private List<GameObject> _inactive = new List<GameObject>();
        private GameObject _prefab;
        private Transform _container;

        public Pool(GameObject prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
        }

        public GameObject Spawn(Vector3 pos, Quaternion rot, Transform container)
        {
            GameObject obj;
            if (_inactive.Count == 0)
            {
                obj = Object.Instantiate(_prefab, pos, rot, container);
                obj.name = _prefab.name;
            }
            else
            {
                obj = _inactive[_inactive.Count - 1];
                _inactive.RemoveAt(_inactive.Count - 1);
            }

            obj.transform.position = pos;
            obj.transform.rotation = rot;
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Despawn(GameObject obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_container);
            _inactive.Add(obj);
        }
    }
}