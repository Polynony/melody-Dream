using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;

public class M_pathfinding : Action {
	private Transform tagrget_player;
	public override void OnStart(){
		
	}
	public override TaskStatus OnUpdate(){

		tagrget_player = FieldOfView.visibletargets[0];
		transform.DOLookAt(tagrget_player.position, 3);
		return TaskStatus.Running;
	}
}
