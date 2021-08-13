using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbullet : MonoBehaviour {
    public float Speed;
    public float Angle;
	void Start () {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Angle);
    }
	void Update () {
        gameObject.transform.Translate(Vector2.up * Speed * Time.deltaTime);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Angle);

        if (gameObject.transform.position.y >= 5.402748f && Skillbool)
        {
            Angle = 180;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
            gameObject.tag = "PlayerEbullet";
        }
        else if(gameObject.transform.position.y >= 5.5f)
        {
            Destroy(gameObject);
        }
    }
    private bool Skillbool=false;
    public void SkillOn()
    {
        Skillbool = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (Angle != 180)
        //{
        //    if (collision.gameObject.CompareTag("Ebullet"))
        //    {
        //        Instantiate(KHS_Objectmanager.instance.HitEffect, collision.gameObject.transform.position, Quaternion.identity);
        //        Destroy(collision.gameObject);
        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.CompareTag("Pbullet")&& Skillbool)//스킬 총알은 해당 안됨 
        {// 반 사된 총알과  플레이어 총알 부딪혀서 플레이어 총알 사라짐 
            Destroy(collision.gameObject);
        }
    }
}
