using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是命令接口，抽象命令
public interface IAttackCommand{ 
	void AttackAction (GameObject AnyObject);
}

public interface IOtherCommand{
	void UsualAction (GameObject AnyObject);
}

	




