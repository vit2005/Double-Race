using UnityEngine;
using System.Collections;

public class CarInstalGame : MonoBehaviour {
	public GameObject[] car;

	void Awake () 
	{
	
		Instantiate (car [PlayerPrefs.GetInt ("carPlayer")], transform.position, transform.rotation);
	}
	

}
