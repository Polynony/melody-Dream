using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是命令接口，抽象命令
public interface AttackCommand{ 
	void AttackAction (GameObject AnyObject);
}

public interface OtherCommand{
	void UsualAction (GameObject AnyObject);
}

	




