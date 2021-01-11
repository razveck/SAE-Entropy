using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Assets.Code {
	abstract class MovementBase : MonoBehaviour {

		[SerializeField]
		private float _speed = 1;

		private void Start() {
			
		}

		protected void Move(Vector3 direction){
			transform.Translate(direction.normalized * _speed * Time.deltaTime);
		}

	}
}
