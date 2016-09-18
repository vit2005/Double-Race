using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpPlayer : HitPoint 
{
	public  GameObject destroyPrefarb;
	public  Sprite    hpGreen;
	public  Sprite    hpLightGreen;
	public  Sprite    hpYellow;
	public  Sprite    hpRed;
	public  Sprite    hpAlfa;

	private int       _hpStart;

	private Image     hpInd;
	private Text      hpIndText;

	private int       hpTextureCollorSelest;

	void Start () 
	{
	hp += PlayerPrefs.GetInt (gameObject.name + "hp");
	_hpStart = hp;
	hpInd = GameObject.FindWithTag ("HP_UI").GetComponent<Image> ();
	hpIndText = GameObject.FindWithTag ("HP_UIint").GetComponent<Text> ();

	hpInd.sprite=hpGreen;
	hpIndText.text=System.Convert.ToString(hp);

	hpTextureCollorSelest=hp/4;
	}
	





	void Update () 
	{
		if (hp > _hpStart) 
		{
			hp = _hpStart;
		}

		hpIndText.text=System.Convert.ToString(hp);

		if(hp <  hpTextureCollorSelest*3 && hp >=  hpTextureCollorSelest*2)
		{
				hpInd.sprite= hpLightGreen;
		}

		if(hp >=  hpTextureCollorSelest && hp <  hpTextureCollorSelest*2)
		{
				hpInd.sprite=hpYellow;
		}

		if(hp <  hpTextureCollorSelest && hp > 0)
		{
				hpInd.sprite=hpRed;
		}



		if(hp <= 0)
		{
			hpInd.sprite=hpAlfa;
			hpIndText.text="0";
			Instantiate(destroyPrefarb, transform.position,transform.rotation);
			Destroy(gameObject);
		}



	}
}
