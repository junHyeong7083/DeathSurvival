using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtk2 : MonoBehaviour
{
    GameObject SkillData;
    GameObject Player;
    Transform PlayerTransform;
    GameObject Dir;
    Transform DirTransform;

    GameObject skillParentB; // �� ������Ʈ�� ������ ����

    public float spawnTime;
    public float stardTime;
    float delayTime = 0f;

    SpriteRenderer spriteRenderer;
    Color color;

    bool isInit = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        SkillData = GameObject.Find("WeaponManager/Skill Data");
        Player = GameObject.Find("Player");
        Dir = GameObject.Find("Dir");
        PlayerTransform = Player.transform;
        DirTransform = Dir.transform;
        // ��ų�� ���� �� ������Ʈ ����
        skillParentB = new GameObject("Skill ParentB");
        skillParentB.transform.parent = SkillData.transform;
    //    this.gameObject.SetActive(false); // �ʱ⿡ ��Ȱ��ȭ
    }

    IEnumerator isSkillInit()
    {
        Debug.Log("!!");
        this.gameObject.SetActive(true);
        float startTime = Time.time;
        color.a = 0f;
        spriteRenderer.color = color;

        while (Time.time - startTime < spawnTime)
        {
            transform.rotation *= Quaternion.Euler(0,0,45f);
       //     this.transform.position = DirController.DirPos;

            float alpha = (Time.time - startTime) / spawnTime;
            color.a = alpha;
            spriteRenderer.color = color;
            yield return null;
        }
        isInit = true;
    }

    public float surviveTime;
    float moveSpeed = 2f;

    IEnumerator isSkillStart()
    {
        Vector3 dir = (DirTransform.position - PlayerTransform.position).normalized;
        float startTime = Time.time;
        Vector3 startPosition = transform.position; // ���� ��ġ ����

        while (Time.time - startTime < surviveTime)
        {
            // ���� �������� ������
            transform.rotation *= Quaternion.Euler(0, 0, 45f); // z�� ȸ�� ����
            float journeyLength = Vector3.Distance(startPosition, DirTransform.position);
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
           this.transform.position = Vector3.Lerp(startPosition, DirTransform.position, fractionOfJourney);

            yield return null;
        }

        delayTime = 0f;
        color.a = 0f;
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        delayTime += Time.deltaTime;

        if (PlayerController.isMove)
        {
            if (delayTime >= stardTime)
            {
                if (!isInit)
                {
                    Debug.Log("dirpos.x : " + DirController.DirPos.x);
                    StartCoroutine(isSkillInit());
                }
                else
                {
                    StartCoroutine(isSkillStart());
                }
            }
        }
    }
}
