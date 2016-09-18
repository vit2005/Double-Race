using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponShop :   MonoBehaviour 
{
	[Header ("Классы с информацией об оружии")]
	public  TTXWeapon[]    WeaponArrey;       //классы с информацией 
	private TTXWeapon      WeaponInfoSelest;  //клас с ттх выбраного оружия
	private CarInfo        WeaponInfoPosition;//клас с позицией оружия для выбраного авто
	
	[Header ("Массив с обьектами вооружения")]
	public  GameObject[]   weponObject;          //массив с моделями автомобилей
	private int            selest;               //индекс выбранного автомобиль из списка
	private GameObject     weaponSelestObject;   //обьект созданного автомобиля(для удаления не нужного авто)
	
	[Header ("Кнопки управления выбором оружия и текст на кнопке выбора/покупки")]
	public  Button         ButtonLeft;        //кнопки смены автомобиля
	public  Button         ButtonRight;        
	public  Button         ButtonSelest;      //кнопка выбора
	public  Text           ButtonSelestText;  //текст на кнопке выбора авто
	
	[Header ("Всплывающие окна")]
	public  RectTransform  BayWindow;         //окно покупок 
	public  RectTransform  BayWindowEror;     //окно покупок 
	
	[Header ("Индикатор выбранна/не выбранна ()")]
	public  Text           selestIndicator;   //надпись Выбрано
	
	[Header ("Текстовые поля с данными об оружии")]
	public  Text           name;           //елементы интерфейса с информацией об автомобиле      
	public  Text           ttx;

	       

	
	
	void Start () 
	{
		//PlayerPrefs.SetInt ("AKSU",0);
		//		PlayerPrefs.SetInt("maney",1000);
		
		//		PlayerPrefs.SetInt ("Iveco" + "hpUpdate",0);
		//		PlayerPrefs.SetInt ("Iveco" + "speedUpdate",0);
		//
		//		PlayerPrefs.SetInt ("Humvee" + "hpUpdate",0);
		//		PlayerPrefs.SetInt ("Humvee" + "speedUpdate",0);
		
		PlayerPrefs.SetInt ("AKSU",1);
		selest = PlayerPrefs.GetInt("weaponPlayer");
		WeaponInstantiate (0);
		WeaponInfoSelest = WeaponArrey [selest];
	}
	
	
	public	void WeaponInstantiate (int i) //создание и удаление автомобилей и смена индекса
	{
		selest+=i;
		WeaponInfoPosition = gameObject.GetComponent<CarSelest> ().carInfoSelest;
		Destroy (weaponSelestObject);
		weaponSelestObject = Instantiate (weponObject [selest], WeaponInfoPosition.positionWeapon, transform.rotation) as GameObject;
		TTXUpdate ();
		ButtonControl ();
	
	}

	public void  TTXUpdate() //обновление информации об автомобиле
	{
		WeaponInfoSelest = WeaponArrey [selest];
		name.text        = WeaponInfoSelest.name;
		ttx.text         = WeaponInfoSelest.DPS + "\n" + WeaponInfoSelest.Clip + "\n" + WeaponInfoSelest.Rld;

		
		Purchase_and_Selest_Button();
	}




	public void ButtonControl()  //включение и отключение кнопок выбора автомобилей 
	{
		if (selest > 0) {
			ButtonLeft.interactable = true;
		} else {
			ButtonLeft.interactable = false;
		}
		
		if (selest < weponObject.Length-1) 
		{
			ButtonRight.interactable = true;
		} 
		else 
		{
			ButtonRight.interactable = false;
			
		}
		
	}


	public void Purchase_test()
	{
		if(PlayerPrefs.GetInt (WeaponInfoSelest.name) == 1)
		{
			//Purchase(1);
			SelestSave(0);
		}
		else
		{
			if(PlayerPrefs.GetInt("maney") >= WeaponInfoSelest.price)
			{
				BayWindow.localPosition = new Vector3 (0,0,0);
				BayWindowEror.localPosition = new Vector3 (0,2000,0);
				
			}
			else
			{
				BayWindow.localPosition = new Vector3 (0,4000,0);
				BayWindowEror.localPosition = new Vector3 (0,0,0);
			}
		}
		
	}
	
	public void Purchase(int index)
	{
		if(index==0)
		{
			if(PlayerPrefs.GetInt("maney") >= WeaponInfoSelest.price)
			{
				PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")-WeaponInfoSelest.price);
				BayWindow.localPosition = new Vector3 (0,4000,0);
				BayWindowEror.localPosition = new Vector3 (0,2000,0);
				SelestSave(1);
			}
			else
			{
				BayWindow.localPosition = new Vector3 (0,4000,0);
				BayWindowEror.localPosition = new Vector3 (0,0,0);
			}
		}
		else
		{
			BayWindow.localPosition = new Vector3 (0,4000,0);
			BayWindowEror.localPosition = new Vector3 (0,2000,0);
		}
		TTXUpdate ();
		Purchase_and_Selest_Button();
	}


	public void Purchase_and_Selest_Button()
	{
		if(PlayerPrefs.GetInt ("weaponPlayer") == selest)
		{
			selestIndicator.text = "ВЫБРАНА";
			ButtonSelest.interactable = false;
		}
		else
		{
			selestIndicator.text = "";
			ButtonSelest.interactable = true;
		}
		
		
		
		if(PlayerPrefs.GetInt (WeaponInfoSelest.name) == 1)
		{
			ButtonSelestText.text = "ВЫБРАТЬ";
			
			
		}
		else
		{
			ButtonSelestText.text = System.Convert.ToString(WeaponInfoSelest.price)+ " $";
			
		}
		
		
	}

	public void SelestSave(int info)
	{
		if(info == 1)
		{
			PlayerPrefs.SetInt (WeaponInfoSelest.name,1);
		}
		
		PlayerPrefs.SetInt ("weaponPlayer",selest);
		PlayerPrefs.Save();
	}



}
