using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangolo : MusicInstruments {
	public Transform point;
	void Awake() {
		m_Type = (byte)SystemValue.M_Type.Percussion;
		m_Tone = (byte)SystemValue.M_Tone.Cold;
		m_basicHurt = 10;
	}

	void Start() {
	}

	void Update () {

		switch(GetKeycode()) {
		case 0:
			InitializationNote (PlayerCollection.noteCollection ["one"], point);
			GameManager.player_animator.SetBool ("attack", true);
			break;
		case 1:
			InitializationNote (PlayerCollection.noteCollection["two"], point);
			GameManager.player_animator.SetBool ("attack", true);
			break;
		case 2:
			InitializationNote (PlayerCollection.noteCollection["tree"], point);
			GameManager.player_animator.SetBool ("attack", true);
			break;
		case 3:
			InitializationNote (PlayerCollection.noteCollection["four"], point);
			GameManager.player_animator.SetBool ("attack", true);
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
