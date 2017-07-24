using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierUtils : MonoBehaviour {
	
		/* private static Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			float u = 1 - t;
			float tt = t * t;
			float uu = u * u;

			Vector3 p = uu * p0;
			p += 2 * u * t * p1;
			p += tt * p2;

			return p;
		}
	//startpoint 起始点，controlPoint控制点，endpoint 终止点，segmentNum 采样点的数量
		public static Vector3 [] GetBeizerList(Vector3 startPoint, Vector3 controlPoint, Vector3 endPoint,int segmentNum)
		{
			Vector3 [] path = new Vector3[segmentNum];
			for (int i = 1; i <= segmentNum; i++)
			{
				float t = i / (float)segmentNum;
				Vector3 pixel = CalculateCubicBezierPoint(t, startPoint,
					controlPoint, endPoint);
				path[i - 1] = pixel;
			}
			return path;

		}*/


	/* private void FixedUpdate()
	{
		Debug.DrawLine(a.position, b.position);
		Debug.DrawLine(b.position, c.position);
		Debug.DrawLine(c.position, a.position);
		Debug.DrawLine(a1.position, b1.position, Color.red);
	}*/

	bool isBool = false;


	public static Vector3 GetBezierPath(Transform current, Transform target) {
		Vector3 b;
		Vector3 a1;
		Vector3 b1; 
		Vector3 c1 = Vector3.zero;
		float passTime = 0.00f;
		float useTime = 3.00f;
		b = Vector3.Lerp (current.position, target.position, 0.5f);
		b.y += 20f;
			passTime += Time.deltaTime;
			float baifenbi = passTime / useTime;
		a1 = Vector3.Lerp(current.position, b, baifenbi);
		b1 = Vector3.Lerp(b, target.position, baifenbi);
			Vector3 dis = a1 - b1;
			Vector3 point = new Vector3(dis.x * (1.0f - baifenbi), dis.y * (1.0f - baifenbi), dis.z * (1.0f - baifenbi));
			Vector3 newPoint = point + b1;

			c1 = newPoint;
		return c1;
	}



	}
