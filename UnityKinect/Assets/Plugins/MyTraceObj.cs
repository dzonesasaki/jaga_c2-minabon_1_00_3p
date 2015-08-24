using UnityEngine;
using System.Collections;

public class MyTraceObj : MonoBehaviour {

	public int IndxTraceObj =0;
	public GameObject[] ObjTaget;
	private int NumObjTgt;
	private bool FlagActive;
	public float fVelCamCurr = 0.03f;
	private float fDefaultVelCam = 0.03f;
	public double CamDistanceToObj; 
	private double StopDistanceToObj=2.0f;
	private double StopDistanceMargin=0.2f;
	private double dFactorReduce = 1f;


	// Use this for initialization
	void Start () {
		IndxTraceObj =0;
		NumObjTgt = ObjTaget.Length;
		if (NumObjTgt < 1) {
			FlagActive = false;
		}else{
			FlagActive = true;
			IndxTraceObj =1;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagActive == false) {
						return;
				}
		CamDistanceToObj = Vector3.Distance (this.transform.position, ObjTaget [IndxTraceObj].transform.position);
		if ( CamDistanceToObj <= StopDistanceToObj) {
			IndxTraceObj ++;
			fVelCamCurr = fDefaultVelCam;
		}
		if (IndxTraceObj >= (NumObjTgt)) {
			FlagActive = false;
			return;
				}
		this.transform.LookAt (ObjTaget [IndxTraceObj].transform.position);
		CamDistanceToObj = Vector3.Distance (this.transform.position, ObjTaget [IndxTraceObj].transform.position);
		fVelCamCurr = fDefaultVelCam * (float)(1 - System.Math.Exp (-System.Math.Abs (System.Math.Pow((CamDistanceToObj-StopDistanceToObj+StopDistanceMargin)/dFactorReduce,3))));

		Vector3 vectDir = new Vector3 (0, 0, 0);
		//vectDir = Vector3.MoveTowards (ObjTaget [IndxTraceObj - 1].transform.position, ObjTaget [IndxTraceObj].transform.position, fVectCam);
		//vectDir = Vector3.MoveTowards (this.transform.position, ObjTaget [IndxTraceObj].transform.position, fVectCam);
		//vectDir = Vector3.MoveTowards (ObjTaget [IndxTraceObj].transform.position, this.transform.position, fVectCam);
		vectDir[0] = (ObjTaget [IndxTraceObj].transform.position[0] - this.transform.position[0])*fVelCamCurr;
		vectDir[1] = (ObjTaget [IndxTraceObj].transform.position[1] - this.transform.position[1])*fVelCamCurr;
		vectDir[2] = (ObjTaget [IndxTraceObj].transform.position[2] - this.transform.position[2])*fVelCamCurr;
		this.transform.Translate (vectDir);
	
	}
}
