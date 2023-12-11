using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC_Atk4Main : MonoBehaviour
{
    public GameObject[] childObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       switch(WeaponDataManager.playerCFourAtkCnt)
        {
            case 1:
                for(int e = 0; e < 1; ++e)
                {
                    childObj[e].gameObject.SetActive(true);
                }
                break;

            case 2:
                for (int e = 0; e < 2; ++e)
                {
                    childObj[e].gameObject.SetActive(true);
                }
                break;

            case 3:
                for (int e = 0; e < 3; ++e)
                {
                    childObj[e].gameObject.SetActive(true);
                }
                break; ;

            case 4:
                for (int e = 0; e < 4; ++e)
                {
                    childObj[e].gameObject.SetActive(true);
                }
                break;

            case 5:
                for (int e = 0; e < 5; ++e)
                {
                    childObj[e].gameObject.SetActive(true);
                }
                break;
        }
    }
}
