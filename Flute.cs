using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flute : MusicInstruments {
	public GameObject notes;
	public Transform point;
	void Start() {
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.J)){
			notes.transform.position = point.position;
			InitializationNote (notes);
		}

	}
}
