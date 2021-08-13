using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OHSBossModeScene : MonoBehaviour {
    public GameObject GameStartButton;

    public GameObject[] BossChoiceObject;
    public Button[] BossChoiceButton;
    // Use this for initialization
    void Start()
    {
        GameStartButton.SetActive(false);
        InitSize();
    }
    public void BackButton()
    {
 //       KHS_EffectSoundManager.instance.ButtonClickOn();
        SceneManager.LoadScene("0_MainMenu");
    }
    private void InitSize()
    {
        for(int i=0;i<6;i++)
        {
            BossChoiceObject[i].gameObject.SetActive(false);
            BossChoiceButton[i].image.color = new Color(0.7f, 0.7f, 0.7f);
            BossChoiceButton[i].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
    public void ChoiceButtonClick(int _num)
    {
        KHS_GamaManager.instance.BossNumber = _num - 1;
        InitSize();
        BossChoiceObject[_num - 1].SetActive(true);
        BossChoiceButton[_num - 1].image.color = new Color(1f,1f,1f);
        BossChoiceButton[_num - 1].GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.5f, 1);
        GameStartButton.SetActive(true);
    //    KHS_EffectSoundManager.instance.ButtonClickOn();
    }
    public void GameStartClick()
    {
   //     KHS_EffectSoundManager.instance.ButtonClickOn();
        GameStartButton.GetComponent<Animator>().SetTrigger("Start");
        Invoke("GameStart", 0.3f);
    }
    void GameStart()
    {
        if (KHS_GamaManager.instance.BossNumber < 3)
            SceneManager.LoadScene("inGame");
    }
}

