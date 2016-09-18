using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadDetailInstal : MonoBehaviour {

	private Transform        target_lampposts; //позиция трассы

	public  GameObject       busStop;
	public  Transform[]      busStopPos;

	public  Rigidbody        lampposts;        //фонарный столб(префарб)
	public  List<Rigidbody>  lampposts_arrey;  //массив созданых столбов на етом участке трассы 
	public  float            dist;             //расстояние между столбами 
	public  int              quantity;         //количество столбов которые требуеться создать 
	
	void Awake () 
	{
	target_lampposts=transform;

	for(int i = 0;i<quantity;i++)
		{
	Rigidbody clone = Instantiate(lampposts,target_lampposts.position,target_lampposts.rotation) as Rigidbody;
	lampposts_arrey.Add(clone);
	
		}

		MovingDetal () ;
		BusStop();
	}
	

	void MovingDetal () 
	{
		int i = 0;
		while (i < quantity)
		{

			lampposts_arrey[i].MovePosition(new Vector3(0.0f,0.19f,target_lampposts.position.z-dist));
			lampposts_arrey[i].MoveRotation(target_lampposts.rotation);
			
			i++;
			

			lampposts_arrey[i].MovePosition(new Vector3(0.0f,0.19f,target_lampposts.position.z+dist));
			lampposts_arrey[i].MoveRotation(Quaternion.Euler(0.0f,0.0f,0.0f));
			i++;
		}

	
	}

	void BusStop()
	{
		for(int i = 0 ; i < busStopPos.Length && busStopPos.Length!=0 ; i++)
		{
		GameObject clone = Instantiate(busStop,busStopPos[i].position,busStopPos[i].rotation) as GameObject;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="PlayerTarget")
		{
			MovingDetal ();
			BusStop();
		}
	}
}
