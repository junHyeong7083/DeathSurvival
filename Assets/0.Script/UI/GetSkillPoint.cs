using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSkillPoint : MonoBehaviour
{
    public Image[] checkingLevel;
    public GameObject skillTreePanel;
    public Text skillPointTxt;
    int skillPoint;
    bool Ones;
    public static bool usePoint; // 스킬트리 찍었는지 확인용
    void Start()
    {
        PlayerLevelBar.CheckingLevel = 1;
        skillPoint = 0;
        skillTreePanel.gameObject.SetActive(false);

        for (int e = 0; e< checkingLevel.Length; e++)
        {
            checkingLevel[e].gameObject.SetActive(false);
        }

        usePoint = false;
    }

    public void outSkillPanel()
    {
        usePoint = false;
        UIManager.isPause = false;
        skillTreePanel.gameObject.SetActive(false);
    }

    public void useSkillPoint()
    {
        skillPoint--;
        usePoint = true;
        UIManager.isPause = false;
        skillTreePanel.gameObject.SetActive(false);
    }

    void Update()
    {
        switch(PlayerLevelBar.CheckingLevel %5 )
        {
            case 1:
                Ones = false;
                usePoint = false;
                for (int e = 0; e < checkingLevel.Length; ++e)
                {
                    if (e == 0)
                    {
                        checkingLevel[e].gameObject.SetActive(true);
                    }
                    else
                        checkingLevel[e].gameObject.SetActive(false);
                }
                break;
            case 2:
                for (int e = 0; e < checkingLevel.Length; ++e)
                {
                    if (e == 0 || e ==1)
                    {
                        checkingLevel[e].gameObject.SetActive(true);
                    }
                    else
                        checkingLevel[e].gameObject.SetActive(false);
                }
                break;
            case 3:
                for (int e = 0; e < checkingLevel.Length; ++e)
                {
                    if (e == 0 || e == 1 || e == 2)
                    {
                        checkingLevel[e].gameObject.SetActive(true);
                    }
                    else
                        checkingLevel[e].gameObject.SetActive(false);
                }
                break;
            case 4:
                for (int e = 0; e < checkingLevel.Length; ++e)
                {
                    if (e == 0 || e == 1 || e == 2 || e == 3)
                    {
                        checkingLevel[e].gameObject.SetActive(true);
                    }
                    else
                        checkingLevel[e].gameObject.SetActive(false);
                }
                break;
            case 0:
                Debug.Log(PlayerLevelBar.CheckingLevel % 5);
                if (!Ones)
                {
                    UIManager.isPause = true;
                    skillPoint++;
                    Ones = true;
                    skillTreePanel.gameObject.SetActive(true);
                    for (int e = 0; e < checkingLevel.Length; ++e)
                    {
                        checkingLevel[e].gameObject.SetActive(true);
                    }
                }
                if (usePoint)
                {
                    for(int e = 0; e < checkingLevel.Length; ++e) 
                    {
                        checkingLevel[e].gameObject.SetActive(false);
                    }
                    usePoint = false;
                }
                    

                break;

        }
        skillPointTxt.text = "SkillPoint : " + skillPoint.ToString();
    }
}
