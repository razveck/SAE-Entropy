using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Enemies {
	class EnemyHealth : HealthBase {

		[SerializeField]
		private GameObject _loot;

		protected override void Die() {
			Instantiate(_loot, transform.position, Quaternion.identity);

			Destroy(gameObject);
		}

	}
}
