using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour 
{
	public   string       selestVolume;
	private  AudioSource  sourse;

	void Awake () 
	{
		sourse = gameObject.GetComponent<AudioSource> ();
		sourse.volume = PlayerPrefs.GetInt (selestVolume) / 10.0f;
		Volume ();
	}
	
	void Volume()
	{
		sourse.volume = PlayerPrefs.GetInt (selestVolume) / 10.0f;
		Invoke ("Volume", 0.1f);
	}
}
