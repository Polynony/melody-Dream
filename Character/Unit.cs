using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public float Health;
	public float Speed;

	public void Damage(float hurt){
		if (hurt >= Health) {
			Destroy (gameObject);
			//SendMessage ("GameOver");
		} else {
			Health -= hurt;
		}
	}
}
