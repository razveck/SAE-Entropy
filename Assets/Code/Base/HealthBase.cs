using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Assets.Code.Base {
	abstract class HealthBase : MonoBehaviour {

		[SerializeField]
		protected int _currentHealth = 100;
		[SerializeField]
		protected int _maxHealth = 100;

		public int MaxHealth => _maxHealth;

		public event Action<int> HealthChanged;

		private void Start() {
			_currentHealth = _maxHealth;
		}

		public virtual void DealDamage(int damage){
			_currentHealth -= damage;

			HealthChanged?.Invoke(_currentHealth);

			if(_currentHealth <= 0)
				Die();
		}

		protected abstract void Die();

	}
}
