using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private static PlayerState instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        DF = 1f;
        ATT = 1f;
        HP = 1f;
    }
    public static float DF;
    public static float ATT;
    public static float HP;



}
