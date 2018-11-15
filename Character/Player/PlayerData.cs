using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PlayerData {
	public int Currentlevel;
	public Vector3 _Position;
	public float Health;
}
[System.Serializable]
public class PlayerCollection {

	public static Dictionary<string, GameObject> PlayerNoteCollection = new Dictionary<string, GameObject> ();
	public static Dictionary<string, GameObject> PlayerInstrumentsCollection = new Dictionary<string, GameObject>();

	public string[] KeysArray(Dictionary<string, GameObject> dic){
		string[] keys = dic.Keys.ToArray();
		return keys;

	}
	public GameObject[] ValuesArray(Dictionary<string, GameObject> dic){
		GameObject[] values = dic.Values.ToArray ();
		return values;
	}
	
}
