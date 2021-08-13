using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KHS_ResultWindowScript : MonoBehaviour {
    public Text TimeText;
    public Text GoldText;
    public Text ScoreText;
    public Text GiftText;
    public void setResult(int _Time, int _Gold, int _Score)
    {
        PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD")+_Gold);
        TimeText.text =  _Time.ToString();
        GoldText.text = _Gold.ToString();
        ScoreText.text = _Score.ToString();
        TimeText.text = "0";
        GoldText.text = "0";
        ScoreText.text = "0";
        StartCoroutine(RenewalResult(new Text[3] { ScoreText , TimeText , GoldText },
            new int[3] { _Score, _Time, _Gold }));
    }
    IEnumerator RenewalResult(Text[] _text,int[] _goal)
    {
        yield return null;
        for(int i=0;i<_text.Length;i++)
        {
            int number = 0;
            int num = 0;
            while (true)
            {
                yield return new WaitForSeconds(0.001f);
                number++;
                num = Random.Range(0, _goal[i]);
                _text[i].text = num.ToString();
                if (number == 70)
                {
                    _text[i].text = _goal[i].ToString();
                    break;
                }
            }
        }
    }
    IEnumerator GiftClick2()
    {
        KHS_Objectmanager.instance.GiftButton.GetComponent<Animator>().SetTrigger("Click");
        KHS_Objectmanager.instance.GiftButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        int RandomNum = Random.Range(0, 101);
        if (RandomNum <= 60)
        {
            GiftText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD") + 200);
            GiftText.text = "200Gold";
        }
        else if (RandomNum <= 80)
        {
            GiftText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("GOLD", PlayerPrefs.GetInt("GOLD") + 400);
            GiftText.text = "400Gold";
        }
        else
        {
            GiftText.text = "";
            KHS_Objectmanager.instance.GiftButton.gameObject.SetActive(false);
            KHS_Objectmanager.instance.Boxfail.SetActive(true);
        }
    }
    public void GiftClick()
    {
        StartCoroutine(GiftClick2());
       
       
    }
}
