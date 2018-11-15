using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public float distanceAway;
	public float distanceUp;
	public float smooth;
	private Vector3 targetPosition;
	private float Distance = 0;
	private float MinDistance = 2;
	private float MaxDistance = 4;
	private float ZoomSpeed = 2;

	Transform follow;

	void Start ()
	{
		follow = GameObject.FindGameObjectWithTag ("Player").transform;

	}
		
	void Update ()
	{
		targetPosition = follow.position + Vector3.up * distanceUp -follow.forward * distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt (follow);
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			Distance -= Input.GetAxis ("Mouse ScrollWheel") * ZoomSpeed;    
			Distance = Mathf.Clamp (Distance, MinDistance, MaxDistance);
			if(distanceUp <= 6 && distanceAway <= 11){
			distanceUp += Distance * 0.5f;
			distanceAway += Distance;
			}
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			Distance -= Input.GetAxis ("Mouse ScrollWheel") * ZoomSpeed;    
			Distance = Mathf.Clamp (Distance, MinDistance, MaxDistance);
			if(distanceUp >= Distance - 1 && distanceAway >= Distance - 0.5f){
			distanceUp -= Distance * 0.5f;
			distanceAway -= Distance;
			}
		}
	}
}
