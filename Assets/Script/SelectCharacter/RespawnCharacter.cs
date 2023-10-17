using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    public GameObject[] characterPrefab;
    public GameObject player;

    public GameObject[] seeBtnObj;

    private void Start()
    {
        for(int e = 0; e < seeBtnObj.Length; ++e)
        {
            seeBtnObj[e].SetActive(false);
        }

        player = Instantiate(characterPrefab[(int)CharacterManager.Instance.currentCharacter]);
        player.transform.position = transform.position;


        #region SeeSkillBtn for Character
        if ((int)CharacterManager.Instance.currentCharacter == 0)
        {
            seeBtnObj[0].SetActive(true);
        }
        else if ((int)CharacterManager.Instance.currentCharacter == 1)
        {
            seeBtnObj[1].SetActive(true);
        }
        else if ((int)CharacterManager.Instance.currentCharacter == 2)
        {
            seeBtnObj[2].SetActive(true);
        }
        #endregion
    }

    private void Update()
    {
      
    }

}
