using System;
using System.Collections;
using System.Collections.Generic;
using Entropy.Assets.Code.Player;
using UnityEngine;

namespace Entropy.Assets.Code.Items {
	class Pickup : MonoBehaviour {
		
		//this method could be overriden in a subclass to implement specific pickups
		//as an example, this is an ammo pickup
		protected virtual void Pick(PlayerMarker player){
			Debug.Log("Picked up");
			player.GetComponent<PlayerAttack>().Weapon.Ammo += 10;
		}

		private void OnTriggerEnter2D(Collider2D collision) {
			//check if it's the player
			if(collision.TryGetComponent(out PlayerMarker player)){
				Pick(player);

				Destroy(gameObject);
			}
		}

	}
}
