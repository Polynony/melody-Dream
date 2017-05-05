using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个管理乐器的类
public class ToolManager {

	public GameObject musicalInstruments;

	public static Dictionary<string, GameObject> InstrumentsCollection = new Dictionary<string, GameObject>();

	//这是一个添加乐器的方法，当玩家获得乐器时调用这个方法
	public void T_Addmanager(GameObject tools){
		string i = tools.GetComponent<MusicInstruments> ().Name;
		if(InstrumentsCollection.ContainsValue(tools) == true){
			InstrumentsCollection.Add(i, tools);
		}

	}

	public void SwitchTool(){
	//这是一个更换乐器的方法

	}

}
