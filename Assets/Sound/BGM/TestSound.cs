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
        // 여기에 배경 음악 파일을 설정하고, 원하는 설정을 추가하세요.
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
