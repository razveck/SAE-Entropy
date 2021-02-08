using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Assets.Code.Levels {
	class EnemySpawner : MonoBehaviour {

		[SerializeField]
		private List<Transform> _spawnPoints;

		[SerializeField]
		private GameObject _enemyPrefab;

		[SerializeField]
		private float _delay = 2f;

		private IEnumerator Start() {
			while(true) {
				Vector3 spawnPos = _spawnPoints[ Random.Range(0, _spawnPoints.Count) ].position;

				var obj = ObjectPool.Instance.Request(_enemyPrefab);
				obj.transform.position = spawnPos;
				obj.transform.rotation = Quaternion.identity;

				yield return new WaitForSeconds(_delay);
			}
		}
	}
}
