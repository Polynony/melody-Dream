using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;
public class M_Patrol : Action
{
	private Vector3 next;
	static protected Vector3 InitialPosition;
	private Animator v_animator;
	private NavMeshAgent v_agent;
	private float speeds;

	public override void OnAwake(){
		InitialPosition = transform.position;
	}

	public override void OnStart(){
		v_animator = GetComponent<Animator>();
		v_agent = GetComponent<NavMeshAgent>();
		StartCoroutine(Patrol());
	}
	public override TaskStatus OnUpdate(){
		if (FieldOfView.visibletargets.Count > 0)
		{
			return TaskStatus.Failure;
		}
		patrol(next);
		return TaskStatus.Running;
	}

	IEnumerator Patrol(){
		while (true)
		{
			next = patrolPoint(InitialPosition);
			yield return new WaitUntil(() => Vector3.Distance(transform.position, next) <= 1f);
		}
	}

	IEnumerator move(Vector3 vecs, string rotation){
		transform.DOLookAt(vecs, 3);
		yield return new WaitForSeconds(3);
		v_animator.SetBool(rotation, false);
		speeds = Vector3.Distance(transform.position, vecs) * 0.4f;
		StartCoroutine(HesitateAction());
		//v_agent.SetDestination(vecs);
		transform.DOMove (vecs, speeds);
	}

	IEnumerator HesitateAction(){
		float values = Random.value;
		if (values < 0.5f)
		{
			//v_animator.SetBool("",);
			yield return new WaitForSeconds(4);
		}
	}

	public void patrol(Vector3 vec){
		if(Vector3.Cross(transform.forward, vec - transform.position).y < 0){
			//v_animator.SetBool("v_right", false);
			v_animator.SetBool("v_left", true);
			StartCoroutine(move(vec, "v_left"));
		}else if(Vector3.Cross(transform.forward, vec - transform.position).y > 0){
			v_animator.SetBool ("v_right", true);
			//v_animator.SetBool("v_left", false);
			StartCoroutine(move(vec, "v_right"));
		}
	}

	public Vector3 patrolPoint(Vector3 p){
		Vector3 MovePoint;
		Vector3 OriginPoint = p;
		MovePoint = new Vector3 (Random.Range (OriginPoint.x - 25, OriginPoint.x + 25), 
			transform.position.y, Random.Range (OriginPoint.z - 40, OriginPoint.z + 40));
		return MovePoint;
	}
}
