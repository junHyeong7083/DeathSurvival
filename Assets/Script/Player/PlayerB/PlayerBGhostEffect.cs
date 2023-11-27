using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBGhostEffect : PlayerController
{
    public ParticleSystem GhostEffect;


    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (WeaponDataManager.playerBFourbool)
                GhostEffect.gameObject.SetActive(true);
            if (isRight)
            {
                GhostEffect.transform.localScale = new Vector3(-1*1.1f, 0.9f, 0.9f);
            }
            else if (!isRight)
            {
                GhostEffect.transform.localScale = new Vector3(1.1f, 0.9f, 0.9f);
            }
        }
        else
        {
                GhostEffect.gameObject.SetActive(false);
        }
    }
}
