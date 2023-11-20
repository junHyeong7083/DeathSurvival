using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    static TestSound instance;
    public static int check = 0;

    void Awake()
    {

            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        

    }

    void Start()
    {
        // ���⿡ ��� ���� ������ �����ϰ�, ���ϴ� ������ �߰��ϼ���.
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
