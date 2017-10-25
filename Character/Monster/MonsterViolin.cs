using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterViolin : Monster {

	void Awake(){
		_IsAwake = true;
		MonsterWeak.Add (1, 3);
	}

	void Start () {
	}
}
