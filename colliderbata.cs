using UnityEngine;
using System.Collections;

public class colliderbata : MonoBehaviour {

	public GameObject jiao;

	void Update () {

		shoot ();



	}

	void shoot(){
		if (Input.GetKeyDown(KeyCode.J)) {
			GameObject clone = Instantiate(jiao, transform.position, transform.rotation)as GameObject;
			Rigidbody r = clone.GetComponent<Rigidbody> ();
		

		}


	}
}