using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class fade_off_ani : MonoBehaviour {

	static bool already = false;
	public Color c;
	static bool done = false;

	// Use this for initialization
	void Start () {
		if (already) {
			gameObject.SetActive (false);
			//Destroy (this);
		}
		else
			already = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Image> ().color = c;
		if (c.a == 0 || done) {
			gameObject.SetActive (false);
			done = true;
		}
	}


}
