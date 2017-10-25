using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一些实现接口的关于动作的命令类

//以下几个对应不同乐器的演奏动作，可能有更多
public class PlayWindMusic : IAttackCommand {

	public void AttackAction(GameObject AnyObject1){
		//AnyObject1.GetComponent<脚本名> (). 这里调用管乐器动作的方法，触发动画;
	}
}
public class PlayStringMusic : IAttackCommand{
	
	public void AttackAction(GameObject AnyObject1){
		//AnyObject1.GetComponent<脚本名> (). 这里调用弦乐器动作的方法，触发动画;
	}
}


public class Dash : IAttackCommand{
	public void AttackAction(GameObject AnyObject1){
		//AnyObject1.Getcomponent<脚本名> ().调用怪物冲撞攻击的方法，触发动画
	}
}

public class Bellow : IAttackCommand{
	public void AttackAction(GameObject AnyObject1){
		//AnyObject1.Getcomponent<脚本名> ().调用怪物吼叫攻击的方法，触发动画
	}
}

public class Worry : IAttackCommand{
	public void AttackAction(GameObject AnyObject1){
		//AnyObject1.Getcomponent<脚本名> ().调用怪物吼叫攻击的方法，触发动画
	}
}