using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {
	public float viewRadius;//范围
	[Range(0,360)]
	public float viewAngle;//角度
	public LayerMask targetmask;//目标蒙版
	public LayerMask odstaclemask;//障碍物蒙版

	[HideInInspector]

	public static List<Transform> visibletargets = new List<Transform>();
	 
	public float meshResolution; //网格分辨率
	public int edgeResolveIterations;//边缘迭代
	public float edgeDstThreshold;//边缘阈值

	public MeshFilter viewMeshFilter;
	Mesh viewMesh;



	void Start(){
		viewMesh = new Mesh ();
		viewMesh.name = "View Mesh";
		viewMeshFilter.mesh = viewMesh;
		StartCoroutine ("findTargetWithDelay", .2f);
	}


	//寻找目标 协程
	IEnumerator findTargetWithDelay(float delay){
		while (true){
			yield return new WaitForSeconds (delay);
			FindVisibleTargets ();
		}
	}

	void LateUpdate(){
		DrawFieldOfView ();
	}

	//寻找看得见的目标
	void FindVisibleTargets()
	{
		visibletargets.Clear ();
		Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetmask);
		for (int i = 0; i < targetsInViewRadius.Length; i++) {
			Transform target = targetsInViewRadius [i].transform;
			Vector3 DirToTarget = (target.position - transform.position).normalized;
			if(Vector3.Angle(transform.forward, DirToTarget) < viewAngle / 2)
			{
				float dstotarget = Vector3.Distance (transform.position, target.position);
				if (!Physics.Raycast (transform.position, DirToTarget, dstotarget, odstaclemask)) {
					visibletargets.Add (target);
				}
			}
		}
	}
	//绘制视线区域
	void DrawFieldOfView(){
		int stepCount = Mathf.RoundToInt (viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;
		List<Vector3> viewPoints = new List<Vector3> ();
		ViewCastInFo oldViewCast = new ViewCastInFo ();
		for (int i = 0; i <= stepCount; i++) {
			float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
			//Debug.DrawLine (transform.position, transform.position + DirFromAngle (angle, true) * viewRadius, Color.red);
			ViewCastInFo newViewCast = ViewCast(angle);

			if(i > 0){
				bool edgeDstThresholdExceeded = Mathf.Abs (oldViewCast.dst - newViewCast.dst) > edgeDstThreshold;
				if(oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded)){
					EdgeInfo edge = FindEdge (oldViewCast, newViewCast);
					if(edge.pointA != Vector3.zero){
						viewPoints.Add (edge.pointA);
					}
					if(edge.pointB != Vector3.zero){
						viewPoints.Add (edge.pointA);
					}
				}
			}

			viewPoints.Add (newViewCast.point);
			oldViewCast = newViewCast;
		}
		int vertexCount = viewPoints.Count + 1;
		Vector3[] vertices = new Vector3[vertexCount];
		int[] triangles = new int[(vertexCount - 2) * 3];

		vertices [0] = Vector3.zero;
		for(int i = 0; i < vertexCount - 1; i++){
			vertices [i + i] = transform.InverseTransformPoint (viewPoints [i]);
			if(i < vertexCount -2){
			triangles [i * 3] = 0;
			triangles [i * 3 + 1] = i=1;
			triangles [i * 3 + 2] = i +2;
			}
		}
		viewMesh.Clear ();
		viewMesh.vertices = vertices;
		viewMesh.triangles = triangles;
		viewMesh.RecalculateNormals ();
	}

	EdgeInfo FindEdge(ViewCastInFo minViewCast, ViewCastInFo maxViewCast){
		float minAngle = minViewCast.angle;
		float maxAngle = maxViewCast.angle;
		Vector3 minpoint = Vector3.zero;
		Vector3 maxpoint = Vector3.zero;

		for(int i =0; i< edgeResolveIterations; i++){
			float angle = (minAngle + maxAngle) / 2;
			ViewCastInFo newViewCast = ViewCast (angle);

			bool edgeDstThresholdExceeded = Mathf.Abs (minViewCast.dst - newViewCast.dst) > edgeDstThreshold;
			if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded) {
				minAngle = angle;
				minpoint = newViewCast.point;
			} else {
				maxAngle = angle;
				maxpoint = newViewCast.point;
			}
		}
		return new EdgeInfo (minpoint, maxpoint);
	}

	ViewCastInFo ViewCast(float globalAngle){
		Vector3 dir = DirFromAngle (globalAngle, true);
		RaycastHit hit;

		if (Physics.Raycast (transform.position, dir, out hit, viewRadius, odstaclemask)) {
			return new ViewCastInFo (true, hit.point, hit.distance, globalAngle);
		} else {
			return new ViewCastInFo (false, transform.position + dir * viewRadius, viewRadius, globalAngle);
		}
	}

	public Vector3 DirFromAngle(float angleDegress, bool angleIsGlobal){
		if(!angleIsGlobal){
			angleDegress += transform.eulerAngles.y; 
		}
		return new Vector3 (Mathf.Sin (angleDegress * Mathf.Deg2Rad), 0, Mathf.Cos (angleDegress * Mathf.Deg2Rad));
	}
	//视线显示信息
	public struct ViewCastInFo {
		public bool hit;
		public Vector3 point;
		public float dst;
		public float angle;

		public ViewCastInFo(bool _hit, Vector3 _point, float _dst, float _angle){
			hit = _hit;
			point = _point;
			dst = _dst;
			angle = _angle;
		}

	}
	//边缘信息
	public struct EdgeInfo {
		public Vector3 pointA;
		public Vector3 pointB;

		public EdgeInfo(Vector3 _ponitA, Vector3 _pointB){
			pointA = _ponitA;
			pointB = _pointB;
			
		}
	}
		
}
 

















