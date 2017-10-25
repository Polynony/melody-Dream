using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;

public class MAttack : Action {
	private Transform player;
	private Animator v_animator;

	public override void OnStart ()
	{
		v_animator = this.GetComponent<Animator> ();
	}

	public override TaskStatus OnUpdate ()
	{
		if(FieldOfView.visibletargets.Count > 0){
			player = FieldOfView.visibletargets [0];
			transform.LookAt (player);
			v_animator.SetBool ("v_left", false);
			transform.DOMove (player.position, 8);
			if(Vector3.Distance(transform.position, player.position) < 8f){
				v_animator.SetBool ("bite", true);
			}
			if(Vector3.Distance(transform.position, player.position) >= 8f){
				v_animator.SetBool ("bite", false);
			}
			return TaskStatus.Running;
		}
		return TaskStatus.Failure;
	}
}
