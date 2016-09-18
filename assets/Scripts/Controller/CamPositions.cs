using UnityEngine;
using System.Collections;

public class CamPositions : MonoBehaviour 
{

public  Transform playerPosinion;
private Transform myPosition;

void Start()
{

		myPosition = transform;
		playerPosinion=GameObject.FindWithTag("Player").transform;
		if (!playerPosinion) 
		{
			Start ();
		}
}

void Update () 
{
		if(playerPosinion)
		{
			myPosition.position = new Vector3(playerPosinion.position.x,myPosition.position.y,playerPosinion.position.z);	
		}
}

}
