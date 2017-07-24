using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public float distanceAway;
	public float distanceUp;
	public float smooth;
	private Vector3 targetPosition;

	Transform follow;

	void Start ()
	{
		follow = GameObject.FindGameObjectWithTag ("Player").transform;
	}
		
	void FixedUpdate ()
	{
		targetPosition = follow.position + Vector3.up * distanceUp -follow.forward * distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt (follow);
	}
}
