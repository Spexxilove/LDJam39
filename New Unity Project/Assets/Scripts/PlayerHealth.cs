using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

	public override void takeDamage(float amount){
		CoreHealth.Instance.takeDamage (amount);
	}
}
