using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMonsterController : MonoBehaviour
{
    float disableTime;
    private void OnEnable()
    {
        disableTime = 0f;
    }


    void Update()
    {
        disableTime += Time.deltaTime;
        switch (EventMonster.patternRandom)
        {

            case 0:
                this.gameObject.transform.position += new Vector3(0, -2 * Time.deltaTime, 0);
                break;

            case 1:
                this.gameObject.transform.position += new Vector3(2*Time.deltaTime, 0, 0);
                break;

            case 2:
                this.gameObject.transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
                break;

            case 3:
                this.gameObject.transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
                break;
        }
    }
}
