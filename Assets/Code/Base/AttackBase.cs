﻿using System;
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

		private void Start() {

		}

		protected virtual void Update() {
			Aim();
			Shoot();
		}

		protected abstract void Aim();
		protected abstract void Shoot();

	}
}
