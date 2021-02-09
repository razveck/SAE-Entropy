using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entropy.Assets.Code {

	class ObjectPool : MonoBehaviour{
		//dictionary serialization in unity
		
		//hashmap, hashtable, map
		/// <summary>
		/// Key: prefab,
		/// Value: list of instances of that prefab
		/// </summary>
		private Dictionary<GameObject, List<GameObject>> _objects;
		
		//[Serializable]
		//class PoolList{
		//	public GameObject Prefab;
		//	public List<GameObject> Pool;
		//}
		//[SerializeField]
		//private List<PoolList> _poolList;

		[Serializable]
		class PrefabCount{
			public GameObject Prefab;
			public int Count;
		}


		[SerializeField]
		private List<PrefabCount> _prefabs;

		private static ObjectPool _instance;
		public static ObjectPool Instance => _instance;

		private void Awake() {
			if(_instance == null) {
				_instance = this;
				DontDestroyOnLoad(gameObject);
			} else {
				Destroy(this);
			}
		}


		private void Start() {
			/*
			_objects = new Dictionary<string, int>();

			_objects.Add("cat", 2);
			_objects.Add("dog", 190);

			if(_objects.ContainsKey("dog")){
				Debug.Log("Dictionary already has that key");
				Debug.Log(_objects["dog"]);
			}
			else
				_objects.Add("dog", 20);

			_objects["dog"] = 2000;

			//more performant: only looks up the dictionary ONCE
			if(_objects.TryGetValue("cat", out int catValue)){
				Debug.Log($"The cat value was {catValue}");
			}
			*/

			_objects = new Dictionary<GameObject, List<GameObject>>();

			foreach(var prefab in _prefabs) {
				var list = new List<GameObject>();

				for(int i = 0; i < prefab.Count; i++) {
					var obj = Instantiate(prefab.Prefab);
					list.Add(obj);
					obj.SetActive(false);
					obj.AddComponent<PooledObject>().Prefab = prefab.Prefab;
				}

				_objects.Add(prefab.Prefab, list);
			}
		}

		public GameObject Request(GameObject prefab) {
			if(_objects.TryGetValue(prefab, out var list)) {
				if(list.Count > 0) {
					var instance = list[list.Count - 1];
					list.Remove(instance);
					instance.SetActive(true);

					return instance;
				}else{
					var instance = Instantiate(prefab);
					list.Add(instance);
					instance.SetActive(false);
					instance.AddComponent<PooledObject>().Prefab = prefab;
					return instance;
				}
			}else{
				throw new KeyNotFoundException($"Key: {prefab.name}");
			}
		}

		public void Return(GameObject instance) {
			if(instance.TryGetComponent(out PooledObject pooled)) {

				if(_objects.TryGetValue(pooled.Prefab, out var list)) {
					list.Add(instance);
					instance.SetActive(false);
				}
			}
		}

	}
}
