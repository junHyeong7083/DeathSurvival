using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA_Atk3System : MonoBehaviour
{
    public GameObject childObj;
    public int Count;

    int checkCount = 0;
    private void Start()
    {
        for (int e = 0; e < Count; ++e)
        {
            checkCount++;
            GameObject instantiatedChild = Instantiate(childObj);
            instantiatedChild.transform.SetParent(this.transform);
        }
    }
    int a = 0;
    private void Update()
    {
        if(checkCount != Count) // 동적 생성
        {
            StartCoroutine(DynamicInstantiate());
            checkCount = Count;
        }
    }

    IEnumerator DynamicInstantiate()
    {
        a = Count - checkCount;
        for(int e = 0; e < a; ++e)
        {
            GameObject instantiatedChild = Instantiate(childObj);
            instantiatedChild.transform.SetParent(this.transform);

            yield return null;
        }
    }

}
