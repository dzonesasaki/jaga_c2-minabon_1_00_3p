using UnityEngine;
using System.Collections;

public class MyTraceObj : MonoBehaviour {

	public int IndxTraceObj =0;
	public GameObject[] ObjTaget;
	private int NumObjTgt;
	private bool FlagActive;
	public float fVelCamCurr = 0.03f;
	private float fDefaultVelCam = 0.05f;
	public double CamDistanceToObj; 
	private double StopDistanceToObj=2.0f;
	private double StopDistanceMargin=0.2f;
	private double dFactorReduce = 1f;

	// screenRecoding , refere to https://gist.github.com/keijiro/7429201
	public int framerate = 30;
	public int superSize;
	public bool autoRecord;

	int frameCount;
	bool recording;

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
		StartRecording ();
	
	}

	// screenRecoding , refere to https://gist.github.com/keijiro/7429201
	void StartRecording ()
	{
		System.IO.Directory.CreateDirectory ("Capture");
		Time.captureFramerate = framerate;
		frameCount = -1;
		recording = true;
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
			recording = false;
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

		// screenRecoding , refere to https://gist.github.com/keijiro/7429201
		if (recording)
		{
				if (frameCount > 0)
				{
					var name = "Capture/frame" + frameCount.ToString ("0000") + ".png";
					Application.CaptureScreenshot (name, superSize);
				}
				
				frameCount++;
				
				if (frameCount > 0 && frameCount % 60 == 0)
				{
					Debug.Log ((frameCount / 60).ToString() + " seconds elapsed.");
				}
		}
	
	}
}
