using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Assets.Code.Items {
	class Weapon : MonoBehaviour {

		//ammo
		[SerializeField]
		private int _currentMagazine = 10;
		[SerializeField]
		private int _maxMagazine = 10;
		[SerializeField]
		private int _ammo = 100;

		public int Ammo
		{
			get { return _ammo; }
			set { 
				_ammo = value; 
				AmmoChanged?.Invoke(value);
			}
		}

		public event Action<int> AmmoChanged;


		//fire rate
		[SerializeField]
		private float _attackCooldown = 0.5f;
		private float _attackTimer = 0;

		//projectile
		[SerializeField]
		private GameObject _projectilePrefab = default;

		//projectile spawn point
		[SerializeField]
		private Transform _spawnPoint = default;

		//projectile amount
		[SerializeField]
		private int _projectileAmount = 1;
		//spread angle
		[SerializeField]
		private float _spreadAngle = 5;

		//range


		private void Start() {

		}

		private void Update() {
			if(_attackTimer < _attackCooldown)
				_attackTimer += Time.deltaTime;
		}

		public void Attack() {
			if(_attackTimer < _attackCooldown)
				return;

			if(_currentMagazine <= 0){
				Reload();
			}

			//if ammo was 0, the magazine is still empty
			if(_currentMagazine <= 0){
				return; 
			}

			for(int i = 0; i < _projectileAmount; i++) {
				float angle = UnityEngine.Random.Range(-_spreadAngle, _spreadAngle);

				Instantiate(_projectilePrefab, _spawnPoint.position, transform.rotation * Quaternion.Euler(0, 0, angle));
			}


			_attackTimer -= _attackCooldown;

			_currentMagazine--;
		}

		public void Reload() {
			if(Ammo > 0) {
				_currentMagazine = Mathf.Clamp(_maxMagazine, 0, Ammo);
				Ammo -= _currentMagazine;
			}
		}

	}
}
