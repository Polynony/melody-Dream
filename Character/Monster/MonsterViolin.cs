using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterViolin : Monster {
	private Vector3 next;
	private Vector3 last;

	void Awake(){
		_IsAwake = true;
		MonsterWeak.Add (1, 3);
	}

	void Start () {
	}
}
