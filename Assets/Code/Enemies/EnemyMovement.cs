using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Enemies {
	class EnemyMovement : MovementBase {

		private Vector3 _direction;
		private float _timer;
		[SerializeField]
		private float _changeCooldown;

		private void Start() {
			_direction = new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f));
		}

		private void Update() {
			_timer += Time.deltaTime;

			if(_timer >= _changeCooldown){
				_direction = new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f));
				_timer -= _changeCooldown;
			}

			Move(_direction);
		}
	}
}
