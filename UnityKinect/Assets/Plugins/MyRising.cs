using UnityEngine;
using System.Collections;

public class MyRising : MonoBehaviour {
	public bool FlagActive = false;
	float MoveStep = 0.8f;
	public int CountMaster = 0;
	public int DirectionPlusMinus = 1;
	public float VelocityCam = 1.0f;

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
		MoveStep = MoveStep*(float)System.Math.Exp (- (double)CountMaster*CountMaster*0.00005);
		Vector3 vectDir = new Vector3 (0, 0, 0);
		vectDir[0] = 1*DirectionPlusMinus*(MoveStep)*VelocityCam;
		vectDir[1] = 1*DirectionPlusMinus*(MoveStep)*VelocityCam;
		vectDir[2] = 0*DirectionPlusMinus*(MoveStep)*VelocityCam;
		this.transform.Translate (vectDir);
		CountMaster++;

	}
}
