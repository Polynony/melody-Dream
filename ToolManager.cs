using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个管理乐器的类
public class ToolManager : MusicTool {

	static List<MusicTool> toollist = new List<MusicTool> ();

	public void Addmanager(){
		//这是一个添加乐器的方法，当玩家获得乐器时调用这个方法
	      toollist.Add (new MusicTool { });

	}

	public void SwitchTool(){
	//这是一个更换乐器的方法

	}

}
