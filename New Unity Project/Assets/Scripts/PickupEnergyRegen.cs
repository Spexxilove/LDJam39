using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEnergyRegen : PickupBase {

	public override void applyPickupEffect(){
		GameObject core =  GameObject.FindGameObjectWithTag ("Core");
		core.AddComponent<EnergyRegenBuff> ();
	}
}
