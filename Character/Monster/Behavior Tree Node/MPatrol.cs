using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
public class MPatrol : Action {
	private Vector3 next;
	public override void OnStart ()
	{
		StartCoroutine (Patrol ());
	}
	public override TaskStatus OnUpdate ()
	{
		if (FieldOfView.visibletargets.Count > 0) {
			return TaskStatus.Failure;
		}
		patrol (next);
		return TaskStatus.Running;
	}

	IEnumerator Patrol(){
		while (true)
		{
			next = patrolPoint();
			yield return new WaitUntil(() => Vector3.Distance(transform.position, next) <= 1f);
		}
	}

	public void patrol(Vector3 vec){
		transform.DOLookAt (vec, 2);
		//transform.position = Vector3.Lerp (transform.position, vec, 0.5);
		transform.DOMove (vec, 8);
	}

	public Vector3 patrolPoint(){
		Vector3 MovePoint;
		Vector3 OriginPoint;
		OriginPoint = new Vector3 (-27f, transform.position.y, -30f);
		MovePoint = new Vector3 (Random.Range (OriginPoint.x - 25, OriginPoint.x + 25), 
			transform.position.y, Random.Range (OriginPoint.z - 40, OriginPoint.z + 40));
		return MovePoint;
	}
}
