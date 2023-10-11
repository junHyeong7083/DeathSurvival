using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterEffect : MonoBehaviour
{
    public ParticleSystem Lightning;
    void Start()
    {
        Lightning.Pause();
    }

    // Update is called once per frame
    void Update()
    {
         switch(SelectCharacter.selectNum)
        {
            case 1:
                Lightning.gameObject.SetActive(true);
                Lightning.Play();
                break;
            case 2:
                Lightning.gameObject.SetActive(false);
                Lightning.Pause();
                break;
            default:
                Lightning.gameObject.SetActive(false);
                Lightning.Pause();
                break;
        }
        
    }
}
