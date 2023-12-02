using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerC_BasicShowGauge : MonoBehaviour
{
    public Image bgImage;
    public Image fillImage;
    Camera camera;
    IEnumerator AtkCheck()
    {
        float startTime = Time.time;
        while(Time.time - startTime < WeaponDataManager.playerCBasicAtkTime)
        {
            float decreasePercentage = (Time.time - startTime) / WeaponDataManager.playerCBasicAtkTime;
            float fillValue = 1 - decreasePercentage; // 0에서 1을 거꾸로 매핑

            fillImage.fillAmount = fillValue;

            yield return null;
        }
    }

    IEnumerator CoolCheck()
    {
        float startTime = Time.time;
        while (Time.time - startTime < WeaponDataManager.playerCBasicAtkTime)
        {
            float increasePercentage = (Time.time - startTime) / WeaponDataManager.playerCBasicAtkTime;
            float fillValue = increasePercentage; // 0에서 1을 거꾸로 매핑

            fillImage.fillAmount = fillValue;

            yield return null;
        }
    }



    bool notUse = false;
    void Start()
    {
        camera = Camera.main;
        if (CharacterManager.Instance.currentCharacter != Character.Green)
        {
            bgImage.gameObject.SetActive(false);
            fillImage.gameObject.SetActive(false);
            notUse = true;
        }
    }


    bool isOnes = false;
    void Update()
    {
        if(!notUse)
        {
            // camera.WorldToScreenPoint
            bgImage.transform.position = camera.WorldToScreenPoint(new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y - 1.5f, 0));

            if (WeaponDataManager.playerCBasicBool)
            {
                if (!isOnes)
                {
                    StartCoroutine(AtkCheck());
                    isOnes = true;
                }
            }
            else if (!WeaponDataManager.playerCBasicBool)
            {
                if (isOnes)
                {
                    StartCoroutine(CoolCheck());
                    isOnes = false;
                }
            }
        }

    }
}
