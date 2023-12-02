using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeePlayerState : MonoBehaviour
{
    public Text Damagetxt;
    public Text Defensetxt;
    public Text Hptxt;
    public Text Speedtxt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Damagetxt.text = "ATK : " + PlayerState.Damage.ToString();
        Defensetxt.text = "DF : " + PlayerState.Defense.ToString();
        Hptxt.text = "HP : " + PlayerState.Hp.ToString();
        Speedtxt.text = "Speed : " + PlayerState.Speed.ToString();


    }
}
