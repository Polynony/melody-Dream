using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个挂在主角上的脚本，主要处理输入并调用相关方法
public class PlayerAction : Unit {
	public GameObject Hero;

	void Update() {
		playMusicAction (Hero);
	}

	void FixedUpdate () {
		MoveMouse ();
		MoveKeyboard ();
	}

	public void playMusicAction(GameObject hero){
		int type = hero.GetComponent<MusicInstruments> ().m_Type;
		if(Input.GetKey(KeyCode.T)||Input.GetKey(KeyCode.Y)||Input.GetKey(KeyCode.U)||Input.GetKey(KeyCode.I)||Input.GetKey(KeyCode.O)||Input.GetKey(KeyCode.P)){
		switch(type){
		case 0:
			PlayWindMusic musicnote0 = new PlayWindMusic ();
			//musicnote0.AttackAction (Hero);
			break;
		case 1:
			PlayStringMusic musicnote1 = new PlayStringMusic ();
			//musicnote1.AttackAction (Hero);
			break;
		case 2:
			PlayPercussionMusic musicnote2 = new PlayPercussionMusic ();
			//musicnote2.AttackAction (Hero);
			break;
		case 3:
			PlayKeyboardMusic musicnote3 = new PlayKeyboardMusic ();
			//musicnote3.AttackAction (Hero);
			break;
			//这是发出乐符的动作,
		    }
		}
	}

	public void MoveKeyboard (){
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.up * -Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.right * -Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.Space)) {
			Jump jump = new Jump ();
			//jump.UsualAction (Hero);
		}
	}
		
	public void MoveMouse(){
		Vector3 target;
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit ();
			if (Physics.Raycast (ray, out hitInfo)) {
				if (hitInfo.collider.name == "Plane") {
					target = hitInfo.point;
					Vector3 offSet = target - transform.position;
					transform.Translate (target * Speed, Space.Self);
				}
			}
		}
	}


}
