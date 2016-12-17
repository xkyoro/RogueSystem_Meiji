using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIManager : MonoBehaviour {

    public Image textureLifeGage;

    public Image textureLifeRedGage;

    public float playerHp;

    public float playerMaxHp;

    public Text equipmentName;
    

    private Text _textHpValue;
    private Text _textMaxHpValue;
    //仮置き
    //------------------------------


    //------------------------------
    
    void Start () {


        _textHpValue = GameObject.Find("Hp").GetComponent<Text>();

        playerMaxHp = 100;
        playerHp = playerMaxHp;
	}
	
	// Update is called once per frame
	void Update () {
       // lifeGage.fillAmount = PlayerPrefs.life / PlayerPrefs.maxLife;
	}


   //被ダメージを受け取る
    public float receiveDamage(float damage) {
        return damage;
    }

    public void SetHpText() {
        _textHpValue.text = "HP" + _textHpValue.ToString();
    }

}
/*
 ・画面に表示させるもの
 HP
 現在装備してるもの
 フロア数
 所持アイテム
  -アイテムアイコン×所持数


     */