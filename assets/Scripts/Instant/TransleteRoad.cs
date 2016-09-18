using UnityEngine;
using System.Collections;

public class TransleteRoad : MonoBehaviour 
{
	public TrackInstantiate roadInstal;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="PlayerTarget" && roadInstal != null)  
		{
			roadInstal.TrackTranslete(transform);
		}
	}



}
