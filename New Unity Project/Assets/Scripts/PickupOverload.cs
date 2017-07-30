using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupOverload : PickupBase {

	public override void applyPickupEffect(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		OverloadBuff buff = player.GetComponent<OverloadBuff> ();
		if (buff != null) {
			buff.renewTimer ();
			Destroy (this);
		} else {
			player.AddComponent<OverloadBuff> ();
		}
	}

}
