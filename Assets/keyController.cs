using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    public GameObject[] keys;
    public Animator[] animators;
    int currentClear = 0;
    void Start()
    {
        isfirstB = 0;
        isfirstB = PlayerPrefs.GetInt("isfirstB");
        if(isfirstB == 1)
        {
            keys[0].gameObject.SetActive(false);
        }
        isfirstC = 0;
        isfirstC = PlayerPrefs.GetInt("isfirstC");
        if (isfirstC == 1)
        {
            keys[1].gameObject.SetActive(false);
        }
    }

    int isfirstB = 0;
    int isfirstC = 0;

    float checkValueB = 0f;
    float TimeB = 0f;

    float checkValueC = 0f;
    float TimeC = 0f;
    // Update is called once per frame
    void Update()
    {
        checkValueB = PlayerPrefs.GetFloat("CharacterB");
        checkValueC = PlayerPrefs.GetFloat("CharacterC");
        if(checkValueB >= 1.0f)
        {
         // keys[0].GetComponent<Animator>().SetTrigger("unLock");
         // PlayerPrefs.SetFloat("CharacterB",1.5f);
         // checkValueB = PlayerPrefs.GetFloat("CharacterB");
         //
         // TimeB += Time.deltaTime;
         //
         // if (TimeB >= 1.0f)
         // {
                keys[0].gameObject.SetActive(false);
          //      PlayerPrefs.SetInt("isfirstB", 1);
          //  }
        }
        if (checkValueC >= 2.0f)
        {
         //   keys[1].GetComponent<Animator>().SetTrigger("unLock");
         //   PlayerPrefs.SetFloat("CharacterC", 2.5f);
         //   checkValueC = PlayerPrefs.GetFloat("CharacterC");
         //
         //   TimeC += Time.deltaTime;
         //
         //   if (TimeC >= 1.0f)
         //   {

                keys[1].gameObject.SetActive(false);
         //       PlayerPrefs.SetInt("isfirstC", 1);
         //   }
        }
   
    }
}
