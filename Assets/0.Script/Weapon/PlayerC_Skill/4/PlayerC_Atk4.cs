using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerC_Atk4 : MonoBehaviour
{
    public GameObject AtkObj;
    GameObject Dir;
    Animator animator;
    [SerializeField]
    float rotateSpeed;

    void Start()
    {
        Dir = GameObject.Find("Dir");
        animator = AtkObj.GetComponent<Animator>();

        StartCoroutine(Atk());
    }
    bool isOnes = false;
    IEnumerator Atk()
    {
        while (true)
        {
            if (!isOnes)
            {
                isOnes = true;
                float startTime = Time.time;
                animator.SetBool("isCool", false);
                WeaponDataManager.playerCBasicBool = true;
                while (Time.time - startTime < WeaponDataManager.playerCBasicAtkTime)
                {
                    if (Dir.transform.position.x >= PlayerController.PlayerPos.x)
                    {
                        Debug.Log("¿À");
                        // this.transform.localEulerAngles = new Vector3(180, 0, 270);
                        AtkObj.transform.localPosition = new Vector3(2.5f, 0, 0);
                    }
                    else
                    {
                        AtkObj.transform.localPosition = new Vector3(-2.5f, 0, 0);
                    }

                    yield return null;
                }
                startTime = Time.time;
                animator.SetBool("isCool", true);
                WeaponDataManager.playerCBasicBool = false;
                while (Time.time - startTime < WeaponDataManager.playerCBasicCoolTime)
                {
                    yield return null;
                }
                isOnes = false;
            }

        }
    }
    void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
    }
}
