using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个命令基类
public class Command : MonoBehaviour{

}
public interface InputCommand{
	void execute (GameObject note);

}
	




