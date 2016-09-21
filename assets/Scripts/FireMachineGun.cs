using UnityEngine;
using System.Collections;

public class FireMachineGun: MonoBehaviour 
{
	[Header ("Характеристики")]
	public  float      scatter;        //разброс
	public  int        damage;         //урон
	public  float      forseBulet;     //сила придаваемая пуле

	public  float      reloadBulet;    //промежуток между выстрелами
	public  float      reloadHolder;   //время перезарядки обоймы
	public  float      timer;          //время разрешения выстрела 

	public  int        buletHolder;    //количество патронов в обойме
	public  int        buletHolderMax;

	
	[Header ("Позиция выстрела и эфекты")]
	public  Transform  transformFire;   //позиция выстрела
	public  Rigidbody  bulet;           //пуля
	public  GameObject efect;           //ефект от выстрела


	public  float      agleFire;        //угол при котором разрешенна стрельба
	public  float      agleTarget;      //угол между игроком и противником

	public  Transform  target;          //трансформ цели
	          



public	void Start()
	{
	
buletHolderMax=buletHolder; //сохраняем максимальное количество патроннов в обойме
efect.SetActive(false);//выключить ефект(вспышка от выстрелла)
timer=0.0f;

	}



 

public void AngleTarget()
	{
		if(target != null)
		{
			agleTarget=Vector3.Angle(transformFire.forward, target.position - transformFire.position); //получаем угол между точкой выстрела и целью 
			
			if(agleTarget <= agleFire )//проверяем возможность выстрела
			{
				Fire();
			}
			
			if(buletHolder == 0)
			{
				Reload();
			}
		}
	}

public void Reload()
{
buletHolder=buletHolderMax;
timer=Time.time+reloadHolder;
}

public void EfectOf()
{
efect.SetActive(false);					
}


	public void Fire () 
	{
		if(buletHolder > 0 && Time.time > timer){
			Quaternion fireScatter = transformFire.rotation;
			fireScatter.x+= Random.Range(-scatter,scatter);
			fireScatter.y+= Random.Range(-scatter,scatter);

			efect.SetActive(true);
			Invoke("EfectOf",reloadBulet/2);

			Rigidbody clone;
			clone= Instantiate(bulet, transformFire.position,fireScatter) as Rigidbody;
			clone.velocity = transformFire.TransformDirection(Vector3.forward * forseBulet);
			clone.gameObject.GetComponent<Bulet>().damage=damage;

			buletHolder--;
			timer=Time.time+reloadBulet;
		}
	}
	

}
