﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

public class Violin : MusicInstruments {

	public Transform point;

	void Awake() {
		m_Type = (byte)SystemValue.M_Type._String;
		m_Tone = (byte)SystemValue.M_Tone.Warm;
		m_basicHurt = 10;
	}

	void Start() {
	}

	void Update () {
		switch(GetKeycode()) {
		case 0:
			//notes [0].transform.position = point.position;
			InitializationNote (PlayerCollection.noteCollection["one"], point);
			break;
		case 1:
			//notes [1].transform.position = point.position;
			InitializationNote (PlayerCollection.noteCollection["two"], point);
			break;
		case 2:
			//notes [2].transform.position = point.position;
			InitializationNote (PlayerCollection.noteCollection["tree"], point);
			break;
		case 3:
			//notes [3].transform.position = point.position;
			InitializationNote (PlayerCollection.noteCollection["four"], point);
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
