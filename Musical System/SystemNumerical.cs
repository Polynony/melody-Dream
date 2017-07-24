using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class SystemNumerical : MonoBehaviour {
	//乐器类型
	public enum M_Type :byte {
			Wind,
			_String,
			Percussion,
			Keyboard
		};
	//音色
	public enum M_Tone :byte{
			Warm = 4,
			Cold,
			Fat,
			thin
		};
	//变音记号
	public enum Accidental :byte{
		    sharp, 
		    X, 
		    b, 
		    bb
	    };
	//轻重音符号
	public enum pf :byte{
		    p,
		    f
	    };

  }