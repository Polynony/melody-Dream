using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个管理乐器的类
public class ToolManager : MusicInstruments {

	public GameObject musicalInstruments;

	public Dictionary<int, GameObject> InstrumentsCollection = new Dictionary<int, GameObject>();

	public void T_Addmanager(){
		//这是一个添加乐器的方法，当玩家获得乐器时调用这个方法
		InstrumentsCollection.Add(0, musicalInstruments);

	}

	public void SwitchTool(){
	//这是一个更换乐器的方法

	}

}
