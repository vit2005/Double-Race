using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {

	private static SoundControl _instance;
	public static SoundControl Instance { get { return _instance; } }

	private  AudioSource  sourse;
	public AudioClip ding;

	// Use this for initialization
	void Start () {
		_instance = this;
		sourse = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	public void SetVolume () {
		sourse.volume = PlayerPrefs.GetInt ("sound") / 10.0f;
		sourse.PlayOneShot (ding);
	}
}
