using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteOne : MusicNote {

	void Start () {
		
	}

	void FixedUpdate() {
		flyToTarget (40);
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Target"){
			Destroy (gameObject);
		}
	}
}
