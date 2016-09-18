using UnityEngine;
using System.Collections;

public class DeleteObject : MonoBehaviour {
	public float       timer;
	public int         damage;
	public GameObject  deletPrefarb;
	public GameObject  deletTarget;

	void Start () 
	{
		if(!deletTarget)
		{
			deletTarget=gameObject;
		}
	}
	

	void InstalPrefarb () 
	{
		if(deletPrefarb)
		{
		Instantiate(deletPrefarb, transform.position,transform.rotation);
		}
		Destroy(deletTarget);
	}


	void OnCollisionEnter(Collision collision) 
	{
		if(collision.collider.gameObject.GetComponentInParent<HpPlayer>())
		{
			collision.collider.gameObject.GetComponentInParent<HitPoint>().Damage(damage);

			Invoke("InstalPrefarb",timer);
			damage=0;
		}

	}


}
