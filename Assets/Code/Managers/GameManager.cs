using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Player;
using UnityEngine;

namespace Entropy.Assets.Code.Managers {
	class GameManager : MonoBehaviour {

		public static GameManager Instance;

		public PlayerMarker Player;

		private void Awake() {
			if(Instance == null){
				Instance = this;
			}
			else{
				Destroy(gameObject);
			}
		}

		private void Start() {

		}

		private void Update() {

		}

	}
}
