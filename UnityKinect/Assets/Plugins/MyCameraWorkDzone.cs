using UnityEngine;
using System.Collections;

public class MyCameraWorkDzone : MonoBehaviour {

	public int CounterVib =0;
	public float VelocityCam = 1.0f;
	public bool FlagActive = false;
	public int DirectionPlusMinus = 1;
	float MoveStep = 5.0f;
	public int CountMaster = 0;

	// Use this for initialization
	void Start () {
		FlagActive = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagActive == false) {
			return;
		}
		if (CountMaster >= 100) {
			FlagActive=false;
		}

		if (CounterVib >= 10) {
			CounterVib=0;
			DirectionPlusMinus = (-1)*DirectionPlusMinus;
		}
		MoveStep = MoveStep*(float)System.Math.Exp (- (double)CountMaster*CountMaster*0.00005);
		Vector3 vectDir = new Vector3 (0, 0, 0);
		vectDir[0] = 1*DirectionPlusMinus*(MoveStep)*VelocityCam;
		vectDir[1] = 0*DirectionPlusMinus*(MoveStep)*VelocityCam;
		vectDir[2] = 0*DirectionPlusMinus*(MoveStep)*VelocityCam;
		this.transform.Translate (vectDir);
		CounterVib++;
		CountMaster++;

	
	}
}
