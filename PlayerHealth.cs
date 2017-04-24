using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	private float Health;

	public float health {
		get {return Health; }
		set {Health = value;}
	}

	void Start () {
		
	}

	void Update () {

	}

	public void playerhurt(){
		//主角受到攻击时调用这个方法，根据情况减血，若Health<0，sendmessage（gamemanagaer.GameOver())
	}
	void OnCollisionEnter(Collision collision){
		// 检测碰撞
	}
}
