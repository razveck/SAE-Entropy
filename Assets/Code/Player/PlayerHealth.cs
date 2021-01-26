using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entropy.Assets.Code.Player {
	class PlayerHealth : HealthBase {

		protected override void Die() {
			Destroy(gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
