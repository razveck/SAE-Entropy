using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Projectiles {
	class ProjectileMovement : MovementBase {
		private void Start() {

		}

		private void Update() {
			Move(transform.right);
		}

	}
}
