using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Projectiles {
	class Projectile : MonoBehaviour {

		[SerializeField]
		private int _damage = 30;

		private void Start() {

		}

		private void OnTriggerEnter2D(Collider2D collision) {
			//look for a health component

			if(collision.TryGetComponent(out HealthBase health)){
				//if there is one, call DealDamage
				health.DealDamage(_damage);
			}

			//destroy the bullet
			ObjectPool.Instance.Return(gameObject);
		}

	}
}
