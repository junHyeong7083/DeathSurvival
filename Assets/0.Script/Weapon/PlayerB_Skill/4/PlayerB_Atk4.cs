using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerB_Atk4 : PlayerController
{
    bool isStart = true;
    float skillTime = 0f;
    float coolTime = 0f;

    Image atk4Icon;

    public GameObject showPlayerChar;
    public GameObject targetTrailRender;

    private Color[] originalColors;

    SpriteRenderer spriteRenderer;
    Color color;
    Vector3 originScale;

    // Start is called before the first frame update
    void Start()
    {
        GameObject atk4IconObj = GameObject.Find("CameraCanvas/ShowSkillIcon/PlayerB/BG4/SkillD");
        if (atk4IconObj != null)
        {
            atk4Icon = atk4IconObj.GetComponent<Image>();
            atk4Icon.fillAmount = 1f;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;

        originScale = this.transform.localScale;

        StartCoroutine(Atk());
    }

    // Update is called once per frame
    float currentSpeed = 0f;

    IEnumerator Atk()
    {
        while(true)
        {
            this.transform.localScale = originScale;
            color.a = 0.25f;
            spriteRenderer.color = color;


            float startTime = Time.time;
            atk4Icon.fillAmount = 0f;
            WeaponDataManager.playerBFourbool = true;
            while (Time.time - startTime < 1f)
            {
                this.transform.localScale += new Vector3(50 * Time.deltaTime, 30 * Time.deltaTime, 30 * Time.deltaTime);

                yield return null;
            }

            startTime = Time.time;
            currentSpeed = PlayerState.Speed;

            PlayerState.Speed *= 1.5f;
            while (Time.time-  startTime< WeaponDataManager.playerBFourTime)
            {
                showPlayerChar.gameObject.SetActive(true);
                targetTrailRender.gameObject.SetActive(true);

                yield return null;
            }
            PlayerState.Speed = currentSpeed;
            startTime = Time.time;
            color.a = 0f;
            spriteRenderer.color = color;
            WeaponDataManager.playerBFourbool = false;
            while (Time.time - startTime < WeaponDataManager.playerAFourCoolTime)
            {
                float t = (Time.time - startTime ) / WeaponDataManager.playerAFourCoolTime;
                float fillAmount = Mathf.Clamp(coolTime / WeaponDataManager.playerAFourCoolTime, 0, 1);
                atk4Icon.fillAmount = fillAmount;


                yield return null;
            }
            
        }


    }


    void Update()
    {
        this.transform.position = PlayerController.PlayerPos;
/*        if(isStart)
        {
            atk4Icon.fillAmount = 0f;
            this.transform.position = new Vector3(PlayerController.PlayerPos.x, PlayerController.PlayerPos.y, PlayerController.PlayerPos.z);
            if(transform.localScale.x < 15)
            {
                this.transform.localScale += new Vector3(25 * Time.deltaTime, 25 * Time.deltaTime, 25 * Time.deltaTime);
            }

            if (!isOnes)
            {
                Debug.Log("??");
                currentSpeed = PlayerPrefs.GetFloat("PlayerASpeed"); // 나중에 변수 PlayerBSpeed 로 변경해야함
                currentSpeed *= 1.5f;
                PlayerPrefs.SetFloat("PlayerASpeed", currentSpeed);
                showPlayerChar.gameObject.SetActive(true);
                targetTrailRender.gameObject.SetActive(true);
                this.transform.localScale = new Vector3(-5, 3, 3);     
                isOnes = true;
            } // 4번스킬이 시작된 위치에 플레이어 잔상 이미지 남겨두기
            WeaponDataManager.playerBFourbool = true;
            skillTime += Time.deltaTime;
          //  GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

            *//*    foreach (GameObject monster in monsters)
                {
                    //monster.SendMessage("OnSlow", SendMessageOptions.DontRequireReceiver);
                }

                if(skillTime > WeaponDataManager.playerBFourTime)
                {

                    foreach (GameObject monster in monsters)
                    {
                      //  monster.SendMessage("OutSlow", SendMessageOptions.DontRequireReceiver);
                    }
                }*//*


            if (skillTime > WeaponDataManager.playerBFourTime + 0.3f)
            {
                currentSpeed /= 1.5f;
                PlayerPrefs.SetFloat("PlayerASpeed", currentSpeed);
                WeaponDataManager.playerBFourbool = false;
                isStart = false;

            }
        }
        else if(!isStart)
        {
            float fillAmount = Mathf.Clamp(coolTime / WeaponDataManager.playerAFourCoolTime, 0, 1);
            atk4Icon.fillAmount = fillAmount;
            this.transform.position = new Vector3(PlayerController.PlayerPos.x - 100f, 0, 0);
            this.transform.localScale = Vector3.zero; 
            coolTime += Time.deltaTime;

            if(coolTime >= WeaponDataManager.playerBFourCoolTime)
            {
                coolTime = 0f;
                isStart = true;
                isOnes = false;
            }

            
        }*/
    }
}
