using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {


	void Start () 
	{
		gameObject.transform.Rotate(0,Random.Range(0,360),0);
	}
	

	void Update () {
	
	}
}
