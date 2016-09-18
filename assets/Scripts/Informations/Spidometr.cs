using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spidometr : MonoBehaviour 
{ 
	private float     lastPosition;
	private Text      dataSpeed;
	private Transform dataTransform;

	void Start () 
	{
		dataSpeed     = gameObject.GetComponent<Text> ();
		dataTransform = GameObject.FindWithTag ("Player").transform;
		Invoke ("SpeedInfo", 0.05f);
	}
	

	void SpeedInfo () 
	{
		if (dataTransform) {
			int i =  System.Convert.ToInt32 (((dataTransform.position.z - lastPosition) * 36000) / 1000);
			dataSpeed.text = System.Convert.ToString(i) + " km/h";
			lastPosition = dataTransform.position.z;
			Invoke ("SpeedInfo", 0.1f);
		} 
		else 
		{
			dataSpeed.text="0 km/h";
		}
	}
}
