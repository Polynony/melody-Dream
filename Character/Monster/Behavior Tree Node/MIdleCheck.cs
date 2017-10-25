using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MIdleCheck : Conditional {

	public override TaskStatus OnUpdate ()
	{
		if (FieldOfView.visibletargets.Count <= 0) {
			return TaskStatus.Success;
		} else {
			return TaskStatus.Failure;
		}
	}
}
