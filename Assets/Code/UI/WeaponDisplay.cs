using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using Entropy.Assets.Code.Items;
using TMPro;
using UnityEngine;

namespace Entropy.Assets.Code.UI {
	class WeaponDisplay : MonoBehaviour {

		[SerializeField]
		private TextMeshProUGUI _weaponName;
		[SerializeField]
		private TextMeshProUGUI _ammoCount;

		[SerializeField]
		private AttackBase _attack;

		private void Start() {
			_attack.WeaponChanged += OnWeaponChanged;
		}

		private void Update() {

		}

		private void OnDestroy() {
			_attack.WeaponChanged -= OnWeaponChanged;
		}

		private void OnWeaponChanged(Weapon newWeapon){
			_weaponName.text = newWeapon.gameObject.name;
			OnAmmoChanged(newWeapon.Ammo);
			newWeapon.AmmoChanged -= OnAmmoChanged;
			newWeapon.AmmoChanged += OnAmmoChanged;
		}

		private void OnAmmoChanged(int ammo){
			_ammoCount.text = ammo.ToString();
		}

	}
}
