using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeePlayerState : MonoBehaviour
{
    public Text atk;
    public Text df;
    public Text hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atk.text = "ATK : " + PlayerState.ATT.ToString();
        df.text = "DF : " + PlayerState.DF.ToString();
        hp.text = "HP : " + PlayerState.HP.ToString();


    }
}
