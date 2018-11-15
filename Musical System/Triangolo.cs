using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathologicalGames;

public class Triangolo : MusicInstruments {
	public Transform point;
	void Awake() {
		MI_Type = (byte)SystemValue.M_Type.Percussion;
		MI_Tone = (byte)SystemValue.M_Tone.Cold;
		MI_basicHurt = 10;
	}

	void Update () {
		
		switch (_switchKeycode())
		{
			case 1:
				InitializationNote(PlayerCollection.PlayerNoteCollection["singleOne"], point);
				PlayerAction.player_animator.SetBool("player_attack", true);
				break;
			case 12:
				PoolManager.Pools["MusicNote"].Despawn(lastNote);
				InitializationNote(PlayerCollection.PlayerNoteCollection["beamOne_1"], lastNote.transform);
				break;
			case 2:
				InitializationNote(PlayerCollection.PlayerNoteCollection["singleTwo"], point);
				PlayerAction.player_animator.SetBool("player_attack", true);
				break;
			case 22:
                PoolManager.Pools["MusicNote"].Despawn(lastNote);
                InitializationNote(PlayerCollection.PlayerNoteCollection["beamTwo_1"], lastNote.transform);
				break;
			case 3:
				InitializationNote(PlayerCollection.PlayerNoteCollection["singleThree"], point);
				PlayerAction.player_animator.SetBool("player_attack", true);
				break;
			case 32:
				PoolManager.Pools["MusicNote"].Despawn(lastNote);
                InitializationNote(PlayerCollection.PlayerNoteCollection["beamThree_1"], point);
				break;
			case 4:
				InitializationNote(PlayerCollection.PlayerNoteCollection["singleFour"], point);
				PlayerAction.player_animator.SetBool("player_attack", true);
				break;
			case 42:
				PoolManager.Pools["MusicNote"].Despawn(lastNote);
                InitializationNote(PlayerCollection.PlayerNoteCollection["beamFour_1"], point);
				break;
		}

		/*if(Input.GetKeyUp(KeyCode.Y)||Input.GetKeyUp(KeyCode.U)||Input.GetKeyUp(KeyCode.I)||Input.GetKeyUp(KeyCode.O)){
			PlayerAction.player_animator.SetBool("player_attack", false);
		}*/
	}

}
