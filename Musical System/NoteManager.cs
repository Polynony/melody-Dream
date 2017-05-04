using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour {
	public GameObject musicNote;
	
	public static Dictionary<int, GameObject> noteCollection = new Dictionary<int, GameObject> ();

	public void N_Addmanager(){
		//这是一个添加音符的方法，当玩家获得音符时调用这个方法
		noteCollection.Add(0, musicNote);

	}


}
