using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Distantion : MonoBehaviour 
{ 
	private float     lastPosition;
	private Text      dataDist;
	private Transform dataTransform;

	void Start () 
	{
		dataDist     = gameObject.GetComponent<Text> ();
		dataTransform = GameObject.FindWithTag ("Player").transform;

	}
	
	
	void Update () 
	{

		if (dataTransform) 
	  {
			lastPosition        = System.Convert.ToInt32(dataTransform.position.z);
			dataDist.text       = System.Convert.ToString(lastPosition/1000.0f)+ " km";

	  }
   }


}