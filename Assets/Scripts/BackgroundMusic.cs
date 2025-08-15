using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic bm;
    void Awake()
    {
        if (bm == null)
        {
            bm = this;
            DontDestroyOnLoad(bm);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
