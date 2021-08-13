using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KHS_Timer : MonoBehaviour {
    private int Time;
    private void Awake()
    {
        Time = 0;
        StartCoroutine(Timego());
    }
    public int getTime()
    {
        return Time;
    }
    IEnumerator Timego()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Time++;
        }
    }
}
