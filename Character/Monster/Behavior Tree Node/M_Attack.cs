using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;

public class M_Attack : Action {
	private Transform player;
	private Animator v_animator;
	private NavMeshAgent v_agent;
	private PlayerAction H;
	private float attackTime;

	public override void OnStart (){
		v_animator = this.GetComponent<Animator> ();
		v_agent = GetComponent<NavMeshAgent>();
	}

	public override TaskStatus OnUpdate (){
		if (FieldOfView.visibletargets.Count > 0)
		{
			V_attack();

		}
		else
		{
			v_animator.SetBool("bite", false);
		}
			return TaskStatus.Failure;
	}

	public TaskStatus V_attack(){
		player = FieldOfView.visibletargets[0];
			transform.LookAt(player);
			v_animator.SetBool("v_left", false);
		//v_agent.SetDestination(player.position);
			transform.DOMove(player.position, 8);
			if (Vector3.Distance(transform.position, player.position) < 8f)
			{
					v_animator.SetBool("bite", true);
			return TaskStatus.Failure;
			}
			if (Vector3.Distance(transform.position, player.position) >= 8f)
			{
				v_animator.SetBool("bite", false);
			}
			return TaskStatus.Running;
		
	}

}
