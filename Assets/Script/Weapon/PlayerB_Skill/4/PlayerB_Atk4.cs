using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB_Atk4 : PlayerController
{
    bool isStart = true;
    float skillTime = 0f;
    float coolTime = 0f;

    public GameObject showPlayerChar;
    public GameObject targetTrailRender;

    private Color[] originalColors;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    bool isOnes = false;
   

    void Update()
    {
        if(isStart)
        {
            this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, PlayerController.PlayerPos.z);
            if(transform.localScale.x < 15)
            {
                this.transform.localScale += new Vector3(22 * Time.deltaTime, 22 * Time.deltaTime, 22 * Time.deltaTime);
            }

            if (!isOnes)
            {
                showPlayerChar.gameObject.SetActive(true);
                targetTrailRender.gameObject.SetActive(true);
                this.transform.localScale = new Vector3(-5, 3, 3);     
                isOnes = true;
            } // 4번스킬이 시작된 위치에 플레이어 잔상 이미지 남겨두기
            WeaponDataManager.playerBFourbool = true;
            skillTime += Time.deltaTime;
          //  GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

            /*    foreach (GameObject monster in monsters)
                {
                    //monster.SendMessage("OnSlow", SendMessageOptions.DontRequireReceiver);
                }

                if(skillTime > WeaponDataManager.playerBFourTime)
                {

                    foreach (GameObject monster in monsters)
                    {
                      //  monster.SendMessage("OutSlow", SendMessageOptions.DontRequireReceiver);
                    }
                }*/


            if (skillTime > WeaponDataManager.playerBFourTime + 0.3f)
            {
                WeaponDataManager.playerBFourbool = false;
                isStart = false;

            }
        }
        else if(!isStart)
        {

            this.transform.position = new Vector3(PlayerController.PlayerPos.x - 100f, 0, 0);
            this.transform.localScale = Vector3.zero; 
            coolTime += Time.deltaTime;

            if(coolTime > WeaponDataManager.playerBFourCoolTime)
            {
                coolTime = 0f;
                isStart = true;
                isOnes = false;
            }

            
        }
    }
}
