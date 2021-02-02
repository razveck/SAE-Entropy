using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Entropy.Assets.Code.UI {
	class HealthDisplay : MonoBehaviour {

		[SerializeField]
		private Image _healthbar;

		[SerializeField]
		private HealthBase _health;

		private void Start() {
			_health.HealthChanged += OnHealthChanged;
		}

		private void OnHealthChanged(int health){
			_healthbar.fillAmount = (float)health / _health.MaxHealth;
		}


	}
}
