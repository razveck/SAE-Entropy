using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Player {
	class PlayerMovement : MovementBase {
		private void Start() {

		}

		private void Update() {
			HandleInput();
		}

		private void HandleInput(){
			Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			
			Move(input);
		}

	}
}
