using UnityEngine;
using System.Collections;

public class MyTraceObj : MonoBehaviour {

	public int IndxTraceObj =0;
	public GameObject[] ObjTaget;
	private int NumObjTgt;
	private bool FlagActive;
	public float fVectCam = 0.01f;
	public double CamDistance; 


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
		CamDistance = Vector3.Distance (this.transform.position, ObjTaget [IndxTraceObj].transform.position);
		if ( CamDistance <= 1) {
			IndxTraceObj ++;
		}
		if (IndxTraceObj >= (NumObjTgt)) {
			FlagActive = false;
			return;
				}
		this.transform.LookAt (ObjTaget [IndxTraceObj].transform.position);

		Vector3 vectDir = new Vector3 (0, 0, 0);
		//vectDir = Vector3.MoveTowards (ObjTaget [IndxTraceObj - 1].transform.position, ObjTaget [IndxTraceObj].transform.position, fVectCam);
		//vectDir = Vector3.MoveTowards (this.transform.position, ObjTaget [IndxTraceObj].transform.position, fVectCam);
		//vectDir = Vector3.MoveTowards (ObjTaget [IndxTraceObj].transform.position, this.transform.position, fVectCam);
		vectDir[0] = (ObjTaget [IndxTraceObj].transform.position[0] - this.transform.position[0])*fVectCam;
		vectDir[1] = (ObjTaget [IndxTraceObj].transform.position[1] - this.transform.position[1])*fVectCam;
		vectDir[2] = (ObjTaget [IndxTraceObj].transform.position[2] - this.transform.position[2])*fVectCam;
		this.transform.Translate (vectDir);
	
	}
}
