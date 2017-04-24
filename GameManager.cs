using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个管理当前关卡游戏循环的脚本
public class GameManager : MonoBehaviour {

	void Awake(){
		Initialize ();
	}

	void Start () {
		
	}

	void Update () {
		
	}

	public void GameOver(){
		//游戏结束时调用此方法，终止当前关卡，弹出结束界面或者返回开始界面等
	}

	public void Waiting(){
		//当玩家点击触发暂停的GUI时调用此方法
	}

	public void Initialize(){
		//当实例化此脚本时 加载当前关卡
	}

}
