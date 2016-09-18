using UnityEngine;
using System.Collections;

public class FpsGUI : MonoBehaviour {
	public float fps;
	public GUISkin skinFPS;

	void Start () 
	{
		Invoke ("FpsInfo",0.3f);
	}

	void FpsInfo () 
	{
		fps = 1.0f/Time.deltaTime;
		Invoke ("FpsInfo",0.3f);
	}


	void OnGUI () 
	{
		GUI.skin = skinFPS;
		GUI.Label (new Rect(Screen.width/2,0,200,50),System.Convert.ToInt32(fps)+" fps");
	}
}
