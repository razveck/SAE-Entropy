using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Base;
using Entropy.Assets.Code.Managers;
using Entropy.Assets.Code.Player;
using UnityEngine;

namespace Entropy.Assets.Code.Enemies {
	class EnemyAttack : AttackBase {
		[SerializeField]
		private GameObject _bulletPrefab;

		private void Start() {

		}

		protected override void Aim() {

			//Vector3 playerPos = GameObject.Find("Player").transform.position; //SLOOOOOOOOOW
			Vector3 playerPos = GameManager.Instance.Player.transform.position;

			Vector3 direction = playerPos - transform.position;

			//trigonometry
			float angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);

			//moving with trigonometry
			_weapon.transform.position = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
		}

		protected override void Shoot() {
			_weapon.Reload();
			_weapon.Attack();
		}
	}
}
