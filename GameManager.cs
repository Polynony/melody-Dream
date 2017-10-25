using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
//这是一个管理当前关卡游戏循环的脚本
public class GameManager : MonoBehaviour {
	public static List<Monster> monsterArray = new List<Monster> ();
	private List<GameObject> _monsterArray = new List<GameObject> ();
	public static Animator player_animator;

	void Awake(){
		_monsterArray.AddRange (GameObject.FindGameObjectsWithTag ("Monster"));
		for(int i = 0; i < _monsterArray.Count; i++){
			monsterArray.Add (_monsterArray [i].GetComponent<Monster> ());
		}

	}

	void Start () {
		player_animator = GameObject.FindWithTag ("Player").GetComponent<Animator> ();
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
