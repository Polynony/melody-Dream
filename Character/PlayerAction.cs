using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这是一个挂在主角上的脚本，主要处理输入并调用相关方法
public class PlayerAction : MonoBehaviour {
	public float speed = 5f;
	public GameObject Hero;

	void Update () {
		Action ();
		MoveMouse ();
		MoveKeyboard ();
	}

	public void Action(){
		if(Input.GetKey(KeyCode.Alpha6)){
			PlayWindMusic musicnote = new PlayWindMusic ();
			//musicnote.execute (Hero);
			//这是一个发出乐符的动作，目前就只写了一个，应该会有很多个
		}
	}


	public void MoveKeyboard (){
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.up * -speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.right * -speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey (KeyCode.Space)) {
			Jump jump = new Jump ();
			//jump.execute (Hero);
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
					transform.Translate (target * speed, Space.Self);
				}
			}
		}
	}


}
