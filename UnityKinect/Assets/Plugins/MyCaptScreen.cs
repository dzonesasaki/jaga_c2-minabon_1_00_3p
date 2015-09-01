using UnityEngine;
using System.Collections;

public class MyCaptScreen : MonoBehaviour {
	public bool FlagActive = false;
	public int CountMaster = 0;
	// screenRecoding , refere to https://gist.github.com/keijiro/7429201
	public int framerate = 30;
	public int superSize;
	public bool autoRecord;
	int frameCount;
	bool recording;

	// Use this for initialization
	void Start () {
		FlagActive = true;
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
		if (CountMaster >= 100) {
			FlagActive=false;
		}
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
