using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerC_BasicAttack : MonoBehaviour
{
    GameObject Dir;

    float attackTime = 3f;
    float coolTime = 3f;
    Animator aanimator;
    BoxCollider2D boxCollider2D;
    

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();  
        Dir = GameObject.Find("Dir");
        aanimator = GetComponent<Animator>();

        StartCoroutine(Atk());
    }


    bool isOnes = false;
    float lastPlaySoundTime = 0f;
    IEnumerator Atk()
    {
        while(true)
        {
            if(!isOnes)
            {
                isOnes = true;
                float startTime = Time.time;
                aanimator.SetBool("isCool", false);
                WeaponDataManager.playerCBasicBool = true;
                boxCollider2D.enabled = true;
                while (Time.time - startTime < WeaponDataManager.playerCBasicAtkTime)
                {
                    if (Dir.transform.position.x >=PlayerController.PlayerPos.x)
                    {
                        // Debug.Log("��");
                        this.transform.localEulerAngles = new Vector3(180, 0, 270);
                        this.transform.position = new Vector3(PlayerController.PlayerPos.x + 1.0f, PlayerController.PlayerPos.y, 0);
                    }
                    else
                    {
                        //Debug.Log("��");
                        this.transform.localEulerAngles = new Vector3(0, 0, 90);
                        this.transform.position = new Vector3(PlayerController.PlayerPos.x - 1.0f, PlayerController.PlayerPos.y, 0);
                    }
                    if((Time.time - lastPlaySoundTime)>= 1)
                    {
                        SoundManager.Instance.StopAudioClip("CBasicAtk");
                        SoundManager.Instance.PlaySFXSound("CBasicAtk",0.5f);
                        lastPlaySoundTime = Time.time;
                    }
                    yield return null;
                }
                SoundManager.Instance.StopAudioClip("CBasicAtk");
                startTime = Time.time;
                aanimator.SetBool("isCool", true);
                WeaponDataManager.playerCBasicBool = false;
                boxCollider2D.enabled = false;
                lastPlaySoundTime = 0;
                while (Time.time - startTime < WeaponDataManager.playerCBasicCoolTime)
                {
                    if ((Time.time - lastPlaySoundTime) >= 1)
                    {
                        SoundManager.Instance.PlaySFXSound("CBasicharage");
                        lastPlaySoundTime = Time.time;
                    }

                    yield return null;
                }
                isOnes = false;
            }
           
        }
    }








    
    void Update()
    {
        
    }
}
