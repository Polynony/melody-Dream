using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Violin : MusicInstruments {
	public Transform point;
	public GameObject[] notes = new GameObject[5];

	void Awake() {
		m_Type = (byte)SystemNumerical.M_Type._String;
		m_Tone = (byte)SystemNumerical.M_Tone.Warm;
	}

	void Start() {
	}

	void Update () {
		switch(GetKeycode()) {
		case 0:
			//notes [0].transform.position = point.position;
			InitializationNote (notes[0], point);
			break;
		case 1:
			//notes [1].transform.position = point.position;
			InitializationNote (notes[1], point);
			break;
		case 2:
			//notes [2].transform.position = point.position;
			InitializationNote (notes[2], point);
			break;
		case 3:
			//notes [3].transform.position = point.position;
			InitializationNote (notes[3], point);
			break;
		}

	}
		
	public byte GetKeycode(){
		byte i = 99;
		if(Input.GetKeyDown(KeyCode.Y)){
			i = 0;
		}
		if(Input.GetKeyDown(KeyCode.U)){
			i = 1;
		}
		if(Input.GetKeyDown(KeyCode.I)){
			i = 2;
		}
		if(Input.GetKeyDown(KeyCode.O)){
			i = 3;
		}
		return i;
	}
}
