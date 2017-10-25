using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
public class MPatrol : Action {
	private Vector3 next;
	static protected Vector3 InitialPosition;
	private Animator v_animator;
	private float speeds;

	public override void OnAwake ()
	{
		InitialPosition = this.transform.position;
	} 

	public override void OnStart ()
	{
		v_animator = this.GetComponent<Animator> ();
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
			next = patrolPoint(InitialPosition);
			yield return new WaitUntil(() => Vector3.Distance(transform.position, next) <= 1f);
		}
	}

	IEnumerator move(Vector3 vecs){
		transform.DOLookAt (vecs, 3);
		yield return new WaitForSeconds (3);
		speeds = Vector3.Distance (transform.position, vecs) * 0.4f;
		transform.DOMove (vecs, speeds);
	}

	public void patrol(Vector3 vec){
		Vector3 v_this = this.transform.position;
		v_this = v_this - Vector3.Project (v_this, Vector3.up);
		vec = vec - Vector3.Project (vec, Vector3.up);
		if(Vector3.Dot(v_this, vec - this.transform.position) < 0){
		v_animator.SetBool ("v_left", true);
			StartCoroutine (move (vec));
		}else if(Vector3.Dot(v_this, vec - this.transform.position) > 0){
			v_animator.SetBool ("v_right", true);
			StartCoroutine (move (vec));
		}
		if(Vector3.Dot(v_this, vec - this.transform.position)  >= 0.8){
			v_animator.SetBool ("v_left", false);
			v_animator.SetBool ("v_right", false);
		}
	}

	public Vector3 patrolPoint(Vector3 p){
		Vector3 MovePoint;
		Vector3 OriginPoint = p;
		OriginPoint = new Vector3 (-27f, transform.position.y, -30f);
		MovePoint = new Vector3 (Random.Range (OriginPoint.x - 25, OriginPoint.x + 25), 
			transform.position.y, Random.Range (OriginPoint.z - 40, OriginPoint.z + 40));
		return MovePoint;
	}
}
