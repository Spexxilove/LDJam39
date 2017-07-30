using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRegenBuff : BuffEffectBase {

	static private float regenUpAmount = 0.5f;

	void Awake(){
		buffTime = 3.0f;
	}

	protected override void  startEffect(){

		CoreHealth.Instance.energyRegenRate += regenUpAmount;
	}

	protected override void updateEffect (){
	}
	protected override void endEffect (){
		CoreHealth.Instance.energyRegenRate -= regenUpAmount;
	}
}
