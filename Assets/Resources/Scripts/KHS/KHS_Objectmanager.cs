using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KHS_Objectmanager : MonoBehaviour {
    public static KHS_Objectmanager instance;
    private void Awake()
    {
        instance = this;
    }
    public Image ResultWindow;
    public Button GiftButton;
    public GameObject HitEffect;
    public GameObject PB;//플레이어 총알 
    public GameObject PdownHitEffect;

    private int _Gold;
    public int Gold
    {
        get
        {
            return _Gold;
        }
        set
        {
            _Gold = value;
        }
    }

    public GameObject Clear;
    public GameObject Fail;
    public GameObject Box;
    public GameObject Box2;
    public GameObject Boxfail;

    public Sprite[] Icon;
}
