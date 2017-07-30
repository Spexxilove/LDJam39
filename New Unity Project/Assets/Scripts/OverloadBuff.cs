using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadBuff : BuffEffectBase {

	static private float firerateDown = 0.15f;
	static private float energyCostDown = 0.1f;
	private PlayerShooting shooting;

	void Awake(){
		buffTime = 5.0f;
	}

	protected override void  startEffect(){
		

			shooting = GetComponent<PlayerShooting> ();
			shooting.shotEnergyCost -= energyCostDown;
			shooting.fireDelay -= firerateDown;

	}

	protected override void updateEffect (){
	}
	protected override void endEffect (){
		shooting.shotEnergyCost += energyCostDown;
		shooting.fireDelay += firerateDown;
	}

	public void renewTimer(){
		buffTime+=5.0f;
	}
}
