using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	[SerializeField]
	public static float Health;
	public float Speed;

	protected delegate void M_Damage(float hurt, Animator o);
	protected delegate void P_Damage(float hurt, Animator o);


	public void Damage(float hurt){
		if (hurt >= Health) {
			//objects.SetBool("player_die", true);
			Health = 0;
			//Destroy (gameObject);
		} else {
			Health -= hurt;
		}
	}
}
