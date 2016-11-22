using UnityEngine;
using System.Collections;

public class raydemo2 : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	Vector3 position = new Vector3(Screen.width/2.0f, Screen.height/2.0f, 0.0f);  
	void Update () {
		

}
	void OnTriggerStay(Collider coll){
		if (coll.tag.CompareTo("monster") == 0)
		{
			print (coll.gameObject.name + ":" + Time.time);
		}
	}

	void raycc(){
		position.x = position.x >= Screen.width ? 0.0f : position.x + 1.0f;  

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);  
		if (Physics.Raycast (ray, out hit, 100.0f)) {  
			Debug.DrawLine (ray.origin, hit.point, Color.green);  
			Debug.Log ("射线检测到的物体名称: " + hit.transform.name);  

		}
	}
		


}
