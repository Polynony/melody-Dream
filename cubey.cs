using UnityEngine;
using System.Collections;

public class cubey : colliderbata {

	public Transform Targetpos;
	
	public float speed;
	public float rotatespeed;

	void Start(){
		Targetpos = GameObject.Find ("BoxUnityChan").GetComponent<Transform> ();

	}

	void Update () {
		Vector3 targetpos = Targetpos.position;
		this.transform.position = Vector3.Lerp (this.transform.position,targetpos,speed * Time.deltaTime);

		Quaternion targetRot = Quaternion.LookRotation (Targetpos.position - this.transform.position);

		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, targetRot, rotatespeed * Time.deltaTime);
	
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag.CompareTo("monster") == 0)
		{
		Destroy(gameObject);
		}

	}
}
