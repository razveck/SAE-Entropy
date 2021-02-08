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
			var obj = ObjectPool.Instance.Request(_loot);
			obj.transform.position = transform.position;
			obj.transform.rotation = Quaternion.identity;

			ObjectPool.Instance.Return(gameObject);
		}

	}
}
