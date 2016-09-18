using UnityEngine;
using System.Collections;

public class TargetEnemi : Target {


	void Start () 
	{
		target = GameObject.FindWithTag("PlayerTarget").transform;
	}
	


}
