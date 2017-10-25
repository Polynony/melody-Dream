using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//这是一个挂在主角上的脚本，主要处理输入并调用相关方法
public class PlayerAction : Unit {
	public GameObject Hero;
	public float roteate;
	public static GameObject currentTool;

	void Start(){
		currentTool = GameObject.FindWithTag ("Tool");
	}

	void Update() {
		//playMusicAction (Hero);
		MoveKeyboard ();
		Toolactive ();

	}

	//void FixedUpdate () {
	//	MoveMouse ();
	//}

	public void playMusicAction(GameObject hero){
		byte type = currentTool.GetComponent<MusicInstruments> ().m_Type;
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
			//这是发出乐符的动作,
		    }
		}
	}

	public void MoveKeyboard (){

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * Speed * Time.deltaTime, Space.Self);
			GameManager.player_animator.SetBool ("run", true);
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			GameManager.player_animator.SetBool ("run", false);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.forward * (-Speed * 0.3f)* Time.deltaTime, Space.Self);
			GameManager.player_animator.SetBool ("backmove", true);
		}

		if (Input.GetKeyUp (KeyCode.S)) {
			GameManager.player_animator.SetBool ("backmove", false);
		}

		if (Input.GetKey (KeyCode.A)) {
			if (GameManager.player_animator.GetCurrentAnimatorStateInfo (0).IsName("player_run")) {
				transform.Rotate (Vector3.up * -roteate * Time.deltaTime, Space.Self);
				GameManager.player_animator.SetBool ("run", true);
			}else if(GameManager.player_animator.GetCurrentAnimatorStateInfo (0).IsName("player_idle")){
				transform.Rotate (Vector3.up * -roteate * Time.deltaTime, Space.Self);
				GameManager.player_animator.SetFloat ("RL_turn", 2);
			}
		}

		if (Input.GetKeyUp (KeyCode.A)) {
			GameManager.player_animator.SetBool ("run", false);
			GameManager.player_animator.SetFloat ("RL_turn", 0);
		}

		if (Input.GetKey (KeyCode.D)) {
			if (GameManager.player_animator.GetCurrentAnimatorStateInfo (0).IsName("player_run")) {
				transform.Rotate (Vector3.up * roteate * Time.deltaTime, Space.Self);
				GameManager.player_animator.SetBool ("run", true);
			}else if(GameManager.player_animator.GetCurrentAnimatorStateInfo (0).IsName("player_idle")){
				transform.Rotate (Vector3.up * roteate * Time.deltaTime, Space.Self);
				GameManager.player_animator.SetFloat ("RL_turn", 3);
			}
		}

		if (Input.GetKeyUp (KeyCode.D)) {
			GameManager.player_animator.SetBool ("run", false);
			GameManager.player_animator.SetFloat ("RL_turn", 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameManager.player_animator.SetBool ("jump", true);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			GameManager.player_animator.SetBool ("jump", false);
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

	public void Toolactive(){
		if(Input.GetKeyDown(KeyCode.C)){
			GameManager.player_animator.SetBool ("take", true);
			currentTool =  GameObject.FindWithTag ("Tool");
			if (currentTool.GetComponent<MeshRenderer> ().enabled) {
				toolactive (false, currentTool);
			} else {
				toolactive (true, currentTool);
			}
		}
		if(Input.GetKeyUp(KeyCode.C)){
			GameManager.player_animator.SetBool ("take", false);
		}
	}
	public void toolactive(bool a,GameObject b){
		b.GetComponent<MeshRenderer> ().enabled = a;
		b.GetComponent<BoxCollider> ().enabled = a;
		b.GetComponent<MusicInstruments> ().enabled = a;
	}

}
