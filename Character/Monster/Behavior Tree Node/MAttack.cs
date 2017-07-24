using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;

public class MAttack : Action {
	private Transform player;
	
	public override TaskStatus OnUpdate ()
	{
		if(FieldOfView.visibletargets.Count > 0){
			player = FieldOfView.visibletargets [0];
			transform.DOMove (player.position, 10);
			return TaskStatus.Running;
		}
		return TaskStatus.Success;
	}
}
