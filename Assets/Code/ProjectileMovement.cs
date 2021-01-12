using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Assets.Code {
	class ProjectileMovement : MovementBase {
		private void Start() {

		}

		private void Update() {
			Move(transform.right);
		}

	}
}
