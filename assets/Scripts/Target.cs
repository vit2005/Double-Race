using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour 
{

	public  float     minX;
	public  float     maxX;
	
	public  float     minY;
	public  float     maxY;
	
    public  float     minZ;
    public  float     maxZ;
	
	
    public  float     speed;
	public  Transform target;
	 

public void Start()
	{

	}


	void Update()
	{
		Targets ();
	}

	
	
public void Targets(){

if(target)
{

Vector3 relativePos = target.position - transform.position;
Quaternion rotation = Quaternion.LookRotation(relativePos);
transform.rotation = Quaternion.Slerp(
transform.rotation,rotation,speed*Time.deltaTime);

}
		
float _x = Mathf.Clamp(transform.localEulerAngles.x ,minX,maxX);
float _y = Mathf.Clamp(transform.localEulerAngles.y ,minY,maxY);
float _z = Mathf.Clamp(transform.localEulerAngles.z ,minZ,maxZ);
transform.localEulerAngles = new Vector3(_x,_y,_z);
	}
}
