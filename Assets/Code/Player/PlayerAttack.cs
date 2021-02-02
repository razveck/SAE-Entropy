using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using Entropy.Assets.Code.Items;
using UnityEngine;

namespace Entropy.Assets.Code.Player {
	class PlayerAttack : AttackBase {

		[SerializeField]
		private Camera _sceneCamera = default;

		[SerializeField]
		private List<Weapon> _weaponsList;

		protected override void Update() {
			base.Update();

			if(Input.GetKeyDown(KeyCode.R)) {
				_weapon.Reload();
			}

			//if(Input.GetKeyDown(KeyCode.Alpha1)) {
			//	ChangeWeapon(0);
			//}
			//if(Input.GetKeyDown(KeyCode.Alpha2)) {
			//	ChangeWeapon(1);
			//}
			//if(Input.GetKeyDown(KeyCode.Alpha3)) {
			//	ChangeWeapon(2);
			//}

			for(int i = 0; i < _weaponsList.Count; i++) {
				if(Input.GetKeyDown((KeyCode)49 + i)) {
					ChangeWeapon(i);
				}
			}

		}

		protected override void ChangeWeapon(int newWeapon) {
			if(_weaponsList.Count <= newWeapon)
				return;

			for(int i = 0; i < _weaponsList.Count; i++) {
				_weaponsList[i].gameObject.SetActive(false);
			}

			//change the current weapon
			_weapon = _weaponsList[newWeapon];

			//enable the current weapon
			_weapon.gameObject.SetActive(true);

			base.ChangeWeapon(newWeapon);
		}

		protected override void Aim() {
			Vector3 mouseWorldSpace = _sceneCamera.ScreenToWorldPoint(Input.mousePosition);

			Vector3 direction = mouseWorldSpace - transform.position;

			//trigonometry
			float angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

			//moving just using the direction we already have
			//direction.z = 0;
			//_weapon.transform.position = transform.position + direction.normalized;

			//moving with trigonometry
			_weapon.transform.position = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
		}

		protected override void Shoot() {
			if(Input.GetMouseButtonDown(0)) {
				_weapon.Attack();
			}
		}

	}
}
