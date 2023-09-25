using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager instance; // �ٸ� ������ ��� ��� �Ұ����� instance

    [SerializeField]
    private GameObject[] patternArray; // ���� �迭, Inspecter���� ���� �������� �޾ƿ��� ����

    Dictionary<string, GameObject> patternDic = new Dictionary<string, GameObject>(); // ���� ��ųʸ�, ���� �̸��� ���� ������ �ҷ����� �ϴ� ����

    public static WeaponManager Instance // �ٸ� ������ ��� �����Ͽ� instance�� ��ȯ
    {
        get
        {
            // ���� ����
            if (instance == null)
            {
                instance = FindObjectOfType<WeaponManager>();
            }

            return instance; // ���� ������ ���������� ��ȯ
        }
    }

    private void Awake()
    {
        // ���� ����
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        //   DontDestroyOnLoad(this.gameObject);

        // ���� �迭�� �ִ� ���ϵ��� ���� ��ųʸ��� ����
        foreach (GameObject pattern in patternArray)
        {
            patternDic.Add(pattern.name, pattern);
        }
    }

    public GameObject StartPattern(string name)
    {
        // ���� ����
        if (patternDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained atternDic");
            return null;
        }

        // ���� ����
        return Instantiate(patternDic[name]);
    }
}
