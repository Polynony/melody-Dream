using UnityEngine;
using System.Collections;

public class unit : MonoBehaviour {

	public int health = 100;
	public GameObject deadeffect;

	public void applydamage(int damage){
		if (health > damage) {
			health -= damage;
		} else {
			destruct ();
		}
	}
	public void destruct(){
		if (deadeffect != null) {
			Instantiate (deadeffect, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
