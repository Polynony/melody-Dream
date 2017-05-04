using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager {
	public GameObject musicNote;
	
	public static Dictionary<int, GameObject> noteCollection = new Dictionary<int, GameObject> ();

	//这是一个添加音符的方法，当玩家获得音符时调用这个方法
	public void N_Addmanager(GameObject Notes){
		int i = Notes.GetComponent<MusicNote> ().ID;
		if(noteCollection.ContainsValue(Notes) = true){
			noteCollection.Add(i, Notes);
		}
	}


}
