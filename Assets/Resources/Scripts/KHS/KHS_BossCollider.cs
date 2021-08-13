using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KHS_BossCollider : MonoBehaviour {
    private int _hp;//보스 체력
    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            KHS_ScoreManager.instance.Score += 10;
            if (_hp <= 0)  
            { //게임 오버 
                StartCoroutine("ClearIE");
            }
        }
    }
    IEnumerator ClearIE()
    {
        if (GameObject.Find("BossHPBar") == null) //changed------------------------------------------------------
        {
            GetComponent<Animator>().SetTrigger("dead");
            yield return new WaitForSeconds(2.0f);
            Destroy(gameObject);

            KHS_Objectmanager.instance.Fail.SetActive(false);
            KHS_Objectmanager.instance.Boxfail.SetActive(false);
            KHS_ScoreManager.instance.Score += 200;
            int timenum = GameObject.Find("Manager").GetComponent<KHS_Timer>().getTime();
            if (timenum <= 60)
            {
                KHS_ScoreManager.instance.Score += timenum * 10;
            }
            KHS_ScoreManager.instance.Score += PControl.HP * 200;
            KHS_Objectmanager.instance.ResultWindow.GetComponent<KHS_ResultWindowScript>().setResult(
                       timenum,
                       KHS_Objectmanager.instance.Gold, KHS_ScoreManager.instance.Score);
            KHS_Objectmanager.instance.ResultWindow.gameObject.SetActive(true);
            KHS_Objectmanager.instance.GiftButton.gameObject.SetActive(true);
            //KHS_Objectmanager.instance.ResultWindow.GetComponent<Animator>().Play("ClearWindowAnimation");
            yield return new WaitForSeconds(2.0f);
            Time.timeScale = 0;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("dead");
            yield return new WaitForSeconds(0.87f);
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        PControl = GameObject.Find("Player").GetComponent<KHS_PlayerControl>();
        BossHpimage = GameObject.Find("BossHp2");
        Debug.Log(BossHpimage);
        HP = 100;
        if (GameObject.Find("BossHPBar") == null)
            BossHpRenderer = BossHpimage.GetComponent<SpriteRenderer>();
        Debug.Log(BossHpimage.GetComponent<SpriteRenderer>());
       
    }
    private void BossHit()
    {
        HP--;
        if (KHS_GamaManager.instance.BossNumber == 1)
        {
            BossHpRenderer.size = new Vector2(BossHpRenderer.size.x, BossHpRenderer.size.y - (4.449821f / 100.0f));
            BossHpimage.transform.position = new Vector2(BossHpimage.transform.position.x, BossHpimage.transform.position.y - (4.449821f / 200.0f));
        }
        else
        {
            BossHpRenderer.size = new Vector2(BossHpRenderer.size.x, BossHpRenderer.size.y - (5.197669f / 100.0f));
            BossHpimage.transform.position = new Vector2(BossHpimage.transform.position.x, BossHpimage.transform.position.y - (5.197669f / 200.0f));
        }
    }
    private KHS_PlayerControl PControl;
    private GameObject BossHpimage;
    private SpriteRenderer BossHpRenderer;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Lazer"))
        {
            StopCoroutine("LazerHit");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pbullet"))
        {
            KHS_Objectmanager.instance.Gold++;
            Destroy(collision.gameObject);
            PControl.SkillGaugeadd();
            if (GameObject.Find("BossHPBar") == null)
                BossHit();
        }
        if(collision.gameObject.CompareTag("Lazer"))
        {
            StartCoroutine("LazerHit");
        }
    }

    IEnumerator LazerHit()
    {
        while(true)
        {
            BossHit();
            KHS_Objectmanager.instance.Gold++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
