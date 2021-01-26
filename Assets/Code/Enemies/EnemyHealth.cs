using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Enemies {
	class EnemyHealth : HealthBase {
		protected override void Die() {
			Destroy(gameObject);
		}

	}
}
