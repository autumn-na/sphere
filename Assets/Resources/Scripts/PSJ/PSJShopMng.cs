using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PSJShopMng : MonoBehaviour {

    
	void Start (){
        for(int i=0;i< SkillList.Length;i++)
        {//초기 스킬리스트 좌표정리
            SkillList[i].transform.localPosition = new Vector2(i * 720, 0);
        }
        ToggleList = GameObject.Find("Toggle1").GetComponentsInChildren<Toggle>();

        SkillEquipImage[0].sprite =
           SkillList[PlayerPrefs.GetInt("SKILL1")-1].transform.FindChild("Name").GetComponent<Image>().sprite;
        SkillEquipImage[1].sprite =
        SkillList[PlayerPrefs.GetInt("SKILL2") - 1].transform.FindChild("Name").GetComponent<Image>().sprite;

        for (int i = 0; i < 2; i++)
            CShop[i].SetActive(false);
    }

    private void Update()
    {
        Skillparent.transform.localPosition = Vector2.MoveTowards(Skillparent.transform.localPosition,
            new Vector2(-1 * ((NowSkill-1) * 720), 0),Time.deltaTime*2000);
    }

    public GameObject[] CShop;

    public GameObject Skillparent;
    public GameObject[] SkillList; //스킬목록
    private int NowSkill = 1;//보고있는 스킬 번호 
    private Toggle[] ToggleList;

    IEnumerator moveSkillList(int Direction)
    {
        for (int i = 0; i < 720; i++)
        {
            yield return null;
            Skillparent.transform.localPosition = new Vector2(Skillparent.transform.localPosition.x + Direction, 0);
        }

    }

    public void nextButton_Skill(int _num)
    {
    //    KHS_EffectSoundManager.instance.ButtonClickOn();
        if (_num == 1)
        {
            if (NowSkill < SkillList.Length)
            {
                NowSkill++;
                ToggleList[NowSkill - 2].isOn = false;
                ToggleList[NowSkill - 1].isOn = true;
            }
        }
    }

    public void prevButton_Skill(int _num)
    {
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
        if (_num == 1)
        {
            if (NowSkill != 1)
            {
                NowSkill--;
                ToggleList[NowSkill].isOn = false;
                ToggleList[NowSkill - 1].isOn = true;
            }
        }
    }

    /////////////////////////////////////////////////
    public GameObject SkillChange;
    public Image SkillChangeImage;
    public Text SkillChangeText;
    public Image SkillChangename;
    public Image[] SkillEquipImage;

    public void buyButton()
    {
      //  KHS_EffectSoundManager.instance.ButtonClickOn();
        if (PlayerPrefs.GetInt("SKILLITEM" + NowSkill.ToString()) != 10)//구매가 안되있다면 
            PlayerPrefs.SetInt("SKILLITEM" + NowSkill.ToString(), 10);
        else
        {
            SkillChangeImage.sprite = SkillList[NowSkill - 1].transform.FindChild("Image").GetComponent<Image>().sprite;
            SkillChangename.sprite = SkillList[NowSkill - 1].transform.FindChild("Name").GetComponent<Image>().sprite;
            //SkillChangeText.text = "SKILL" + NowSkill;
            SkillChange.SetActive(true);
        }

    }
    public void CloseChnage()
    {
    //    KHS_EffectSoundManager.instance.ButtonClickOn();
        SkillChange.SetActive(false);
    }
    int SkillTogglenum = 1;// 스킬 장착해제할때 1과 2선택 

    public void SkillToggle(int i)
    {
        SkillTogglenum = i;
    }

    public void SkillEquip()
    {
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
        PlayerPrefs.SetInt("SKILL" + SkillTogglenum, NowSkill);
        SkillEquipImage[SkillTogglenum - 1].sprite = 
            SkillList[NowSkill - 1].transform.FindChild("Name").GetComponent<Image>().sprite;
    }

    /////////////////////////////////////////////////////
    public void Goskinshop()
    {
    //    KHS_EffectSoundManager.instance.ButtonClickOn();
        CShop[0].SetActive(true);
        CShop[1].SetActive(false);
    }
    public void Goskillshop()
    {
    //    KHS_EffectSoundManager.instance.ButtonClickOn();
        CShop[0].SetActive(false);
        CShop[1].SetActive(true);
    }

    public void BackButton()
    {
    //    KHS_EffectSoundManager.instance.ButtonClickOn();
        for (int i = 0; i < 2; i++)
        {
            CShop[i].SetActive(false);
        }
    }
    public void BackMenu()
    {
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
        Application.LoadLevel(0);
    }
}