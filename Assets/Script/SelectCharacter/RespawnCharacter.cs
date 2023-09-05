using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCharacter : MonoBehaviour
{
    public GameObject[] characterPrefab;
    public GameObject player;

    private void Start()
    {
        player = Instantiate(characterPrefab[(int)DataManager.Instance.currentCharacter]);
        player.transform.position = transform.position;
    }
}
