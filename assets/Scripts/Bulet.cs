using UnityEngine;
using System.Collections;

public class Bulet : MonoBehaviour 
{
	public int damage;
	public GameObject efectPrefarb;
	public AudioSource asource;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


void OnCollisionEnter(Collision collision) 
{
		if(collision.collider.gameObject.GetComponentInParent<HitPoint>())
		{
			collision.collider.gameObject.GetComponentInParent<HitPoint>().Damage(damage);
		}
		ContactPoint contact = collision.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Instantiate(efectPrefarb, pos, rot);
		Destroy (gameObject);

}

}
