using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个继承命令基类的关于动作的命令类

//以下几个对应不同乐器的演奏动作，可能有更多
public class PlayMusic : InputCommand {

	public void execute(GameObject note){
		//note.GetComponent<> (). 这里调用相应的函数，触发动画;
	}
}
public class PlayMusic1 : InputCommand{
	
	public void execute(GameObject note){
		//note.GetComponent<> (). 这里调用相应的函数，触发动画;
	}
}
public class PlayMusic2 : InputCommand{
	
	public void execute(GameObject note){
		//note.GetComponent<> (). 这里调用相应的函数，触发动画;
	}
}

public class Jump :InputCommand{

	public void execute(GameObject note){
		//note.GetComponent<> ().jumpcommand() ;跳
	}

}