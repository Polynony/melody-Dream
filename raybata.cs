using UnityEngine;
using System.Collections;

public class raybata : MonoBehaviour {



	void Start () {  

	}  

	// Update is called once per frame  
	void Update () {  
		if(Input.GetKeyDown(KeyCode.A)){
			
		Ray ray = new Ray(Vector3.zero,transform.position);
		Ray raya = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray,out hit,100);
		if(Physics.Raycast(ray,out hit))
		{
			
		}

		}
}
}