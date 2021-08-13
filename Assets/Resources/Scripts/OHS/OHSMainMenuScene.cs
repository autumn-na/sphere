using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OHSMainMenuScene : MonoBehaviour
{
    public GameObject option;
    public GameObject credit;
    public GameObject on;
    public GameObject offs;
    public GameObject soundoffs;
    int a = 0;
    // private AudioSource shootaudio;
    //  public AudioClip shootsound;

    // Use this for initialization
    void Start()
    {
        
        a++;

        if (PlayerPrefs.GetInt("BGM") == 0)
        {
            OHSBackGroundSound.instance.BGMsrc.Pause();
            on.SetActive(false);
            offs.SetActive(true);
            soundoffs.SetActive(true);
        }
        else
        {
            OHSBackGroundSound.instance.BGMsrc.UnPause();
            credit.SetActive(false);
            option.SetActive(false);
            offs.SetActive(false);
            soundoffs.SetActive(false);
        }
        //this.shootaudio = this.gameObject.AddComponent<AudioSource>();
        //this.shootaudio.clip = this.shootsound;
        //this.shootaudio.loop = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void InfiniteModeButton()
    {
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
        SceneManager.LoadScene("InfiniteMode");
    }
    public void OptionButton()
    {
        option.SetActive(true);
      //  KHS_EffectSoundManager.instance.ButtonClickOn();
    }
    public void OptionClose()
    {
        option.SetActive(false);
       // KHS_EffectSoundManager.instance.ButtonClickOn();
    }
    public void CreditOn()
    {
        credit.SetActive(true);
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
    }
    public void CreditClose()
    {
        credit.SetActive(false);
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
    }

    public void soundonoff()
    {
        a++;

        if (a == 1)
        {
            if (!OHSBackGroundSound.instance.BGMsrc.isPlaying)
            {
                PlayerPrefs.SetInt("BGM", 1);
                OHSBackGroundSound.instance.BGMsrc.UnPause();
                on.SetActive(true);
                offs.SetActive(false);
                soundoffs.SetActive(false);
          //      KHS_EffectSoundManager.instance.ButtonClickOn();
            }
        }
        if (a == 2)
        {
            a = 0;
            PlayerPrefs.SetInt("BGM", 0);
            OHSBackGroundSound.instance.BGMsrc.Pause();
            on.SetActive(false);
            offs.SetActive(true);
            soundoffs.SetActive(true);
      //      KHS_EffectSoundManager.instance.ButtonClickOn();
        }
    }
    public void BossModeButton()
    {
        SceneManager.LoadScene("1_BossMode");
     //   KHS_EffectSoundManager.instance.ButtonClickOn();
    }
    public void goShop()
    {
        SceneManager.LoadScene("ShopScene");
      //  KHS_EffectSoundManager.instance.ButtonClickOn();
    }

}
