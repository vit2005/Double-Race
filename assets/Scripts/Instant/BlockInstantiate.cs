using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockInstantiate : MonoBehaviour 
{ 
	public  int               quantityFence;                 //количество блоков
	public  int               quantityHuman;            //количество людей
	public  int               quantityDetail;            //количество деталей


	private int               quantityStart;             //стартовое количество блоков
	private int               quantityHumanStart;        //стартовое количество людей
	private int               quantityDetailStart;       //стартовое количество деталей

	public  List<Transform>   transformBlock;           //позиция возможного появления  
	public  List<Transform>   transformBlockInstal;     //оставшиеся позиции возможного появления 

	public  GameObject[]      block;                    //массив препятствий
	public  GameObject[]      human; 
	public  GameObject[]      detail;

	private float             timer;


	void Awake () 
	{
		for(int i = 0 ; i < transformBlock.Count ; i ++ )
		{
			transformBlockInstal.Add(transformBlock[i]);
		}

		quantityStart       = quantityFence;
		quantityHumanStart  = quantityHuman;
		quantityDetailStart = quantityDetail;
	}

void OnTriggerEnter(Collider other)
{
	if(other.tag=="PlayerTarget")
		{
			transformBlockInstal.Clear();

			for(int i = 0 ; i < transformBlock.Count ; i ++ )
			{
				transformBlockInstal.Add(transformBlock[i]);
			}

			quantityFence  = quantityStart;
			quantityHuman  = quantityHumanStart;
			quantityDetail = quantityDetailStart;
		}
}



public	void Update()
	{

		
if(Time.time >= timer && quantityFence > 0 && block.Length !=0 )
			{
int selest       = Random.Range(0, transformBlockInstal.Count-1);	
int selestBlock  = Random.Range(0, block.Length-1);	
GameObject clone = Instantiate(block[selestBlock],transformBlockInstal[selest].position,transformBlockInstal[selest].rotation) as GameObject;
transformBlockInstal.RemoveAt(selest);
timer=Time.time+Random.Range(0.05f,0.1f);
quantityFence--;		

			}	

		if(Time.time >= timer && quantityHuman > 0 && human.Length !=0)
		{
			int selest       = Random.Range(0, transformBlockInstal.Count-1);	
			int selestBlock  = Random.Range(0, human.Length-1);	
			GameObject clone = Instantiate(human[selestBlock],transformBlockInstal[selest].position,transformBlockInstal[selest].rotation) as GameObject;
			transformBlockInstal.RemoveAt(selest);
			timer=Time.time+Random.Range(0.05f,0.1f);
			quantityHuman--;		
			
		}


		if(Time.time >= timer && quantityDetail > 0 && detail.Length !=0)
		 {
			 int selest       = Random.Range(0, transformBlockInstal.Count-1);	
			 int selestBlock  = Random.Range(0, detail.Length-1);	
			 GameObject clone = Instantiate(detail[selestBlock],transformBlockInstal[selest].position,transformBlockInstal[selest].rotation) as GameObject;
			 transformBlockInstal.RemoveAt(selest);
			 timer=Time.time+Random.Range(0.05f,0.1f);
			 quantityDetail--;		
			
		 }
	
		

	}
	

}
