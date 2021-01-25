using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using UnityEngine;

namespace Entropy.Assets.Code.Player {
	class PlayerAttack : AttackBase {

		[SerializeField]
		private Camera _sceneCamera;

		[SerializeField]
		private GameObject _bulletPrefab;

		public Vector3 MousePos;
		public Vector3 MouseWorld;

		private void Start() {

		}

		protected override void Update() {
			base.Update();

			MousePos = Input.mousePosition;

		}

		protected override void Aim() {
			Vector3 mouseWorldSpace = _sceneCamera.ScreenToWorldPoint(Input.mousePosition);
			MouseWorld = mouseWorldSpace;

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
			if(Input.GetMouseButtonDown(0)){
				Instantiate(_bulletPrefab, _weapon.transform.position, _weapon.transform.rotation);
			}
		}

	}
}
