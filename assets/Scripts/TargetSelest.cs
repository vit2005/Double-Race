using UnityEngine;
using System.Collections;

public class TargetSelest : MonoBehaviour 
{
private Transform  playerPosition;	
public  float      radius;
public  LayerMask  layer;
private Collider[] targetAround;
public  Transform  target;

public  Target[]        MasageTarget;
public  FireMachineGun  MasageFire;


void Start()
	{
MasageTarget = gameObject.GetComponentsInChildren<Target>();
MasageFire   = gameObject.GetComponent<FireMachineGun>();

playerPosition=transform;

	}
	   
public void Update () 
{
TargetArray();

if(targetAround.Length != 0)
{

target=SortTargets();

foreach (var TargetPlayer in MasageTarget) //передача целей
{
TargetPlayer.target=target;
}
MasageFire.target=target;


}
else
{
foreach (var TargetPlayer in MasageTarget) //отмена целей
{
TargetPlayer.target=null;
}
MasageFire.target=null;
}


		

}


public void TargetArray()
	{

targetAround = Physics.OverlapSphere(transform.position,radius,layer);

	}





public Transform SortTargets()
	{
			float closestMobDistance = 0; //инициализация переменной для проверки дистанции до моба
			Transform nearestmob = null; //инициализация переменной ближайшего моба

			
		foreach (var everyTarget in targetAround) //для каждого моба в массиве
			{
				//если дистанция до моба меньше, чем closestMobDistance или равна нулю
			if (((Vector3.Distance(everyTarget.transform.position, playerPosition.position) < closestMobDistance) || closestMobDistance == 0) && everyTarget.transform.position.z - playerPosition.position.z>0 )
				{
					closestMobDistance = Vector3.Distance(everyTarget.transform.position, playerPosition.position);
					nearestmob = everyTarget.gameObject.transform;//устанавливаем его как ближайшего
				}
			}
			return nearestmob; //возвращаем ближайшего моба
}

}
	

