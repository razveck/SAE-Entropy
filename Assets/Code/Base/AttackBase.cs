using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Items;
using UnityEngine;

namespace Entropy.Assets.Code.Base {
	abstract class AttackBase : MonoBehaviour {

		[SerializeField]
		protected Weapon _weapon;

		//public Weapon Weapon
		//{
		//	get
		//	{
		//		return _weapon;
		//	}
		//}

		//same as the above property
		public Weapon Weapon => _weapon;

		public event Action<Weapon> WeaponChanged;

		private void Start() {
			WeaponChanged?.Invoke(_weapon);
		}

		protected virtual void Update() {
			Aim();
			Shoot();
		}

		protected virtual void ChangeWeapon(int newWeapon) {
			WeaponChanged?.Invoke(_weapon);
		}


		protected abstract void Aim();
		protected abstract void Shoot();

	}
}
