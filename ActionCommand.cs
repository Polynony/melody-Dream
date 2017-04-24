using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一些实现接口的关于动作的命令类

//以下几个对应不同乐器的演奏动作，可能有更多
public class PlayWindMusic : AttackCommand {

	public void AttackAction(GameObject AnyObject1){
		//note.GetComponent<> (). 这里调用管乐器动作的方法，触发动画;
	}
}
public class PlayStringMusic : AttackCommand{
	
	public void AttackAction(GameObject AnyObject1){
		//note.GetComponent<> (). 这里调用弦乐器动作的方法，触发动画;
	}
}
public class PlayPercussionMusic : AttackCommand{
	
	public void AttackAction(GameObject AnyObject1){
		//note.GetComponent<> (). 这里调用打击乐器动作的方法，触发动画;
	}
}

public class Jump : OtherCommand{
	public void UsualAction(GameObject AnyObject2){
		//note.GetComponent<> ().jumpcommand() ;跳，如果怪物有跳的动作同样调用这个方法。
	}
}
	
public class Leisurely : OtherCommand{
	public void UsualAction (GameObject AnyObject2){
		//AnyObject2.GetComponent<> ().usual ();
	}
}


public class Dash : AttackCommand{
	public void AttackAction(GameObject AnyObject1){
		//monsters.Getcomponent<> ().调用怪物冲撞攻击的方法，触发动画
	}
}

public class Bellow : AttackCommand{
	public void AttackAction(GameObject AnyObject1){
		//monsters.Getcomponent<> ().调用怪物吼叫攻击的方法，触发动画
	}
}

public class Worry : AttackCommand{
	public void AttackAction(GameObject AnyObject1){
		//monsters.Getcomponent<> ().调用怪物吼叫攻击的方法，触发动画
	}
}