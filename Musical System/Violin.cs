using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

public class Violin : MusicInstruments {

	public Transform point;

	void Awake() {
		MI_Type = (byte)SystemValue.M_Type._String;
		MI_Tone = (byte)SystemValue.M_Tone.Warm;
		MI_basicHurt = 10;
	}

	void Update () {
		switch(_switchKeycode()) {
			case 0:
			//notes [0].transform.position = point.position;
			InitializationNote (PlayerCollection.PlayerNoteCollection["one"], point);
			break;
		case 1:
			//notes [1].transform.position = point.position;
			InitializationNote (PlayerCollection.PlayerNoteCollection["two"], point);
			break;
		case 2:
			//notes [2].transform.position = point.position;
			InitializationNote (PlayerCollection.PlayerNoteCollection["tree"], point);
			break;
		case 3:
			//notes [3].transform.position = point.position;
			InitializationNote (PlayerCollection.PlayerNoteCollection["four"], point);
			break;
		}

	}

}
