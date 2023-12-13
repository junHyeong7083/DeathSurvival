using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }

            return instance;
        }
    }

    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField]
    private AudioClip MainBgmAudioClip;

    [SerializeField]
    private AudioClip[] sfxAudioClips;

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();

    bool IsPause = false;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
          //  Debug.Log("???!!!");
            DontDestroyOnLoad(this.gameObject);
        }
        bgmPlayer = GetComponentsInChildren<AudioSource>()[0];
        sfxPlayer = GetComponentsInChildren<AudioSource>()[1];

        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }

        LoadVolume(); // 이전에 저장한 볼륨 값 로드
        ApplyVolume(); // 볼륨 값 적용
    }

    public void LoadVolume()
    {
        masterVolume = PlayerPrefs.GetFloat("masterSound");
        bgmVolume = PlayerPrefs.GetFloat("bgmSound");
        sfxVolume = PlayerPrefs.GetFloat("sfxSound");
    }

    private void ApplyVolume()
    {
        masterVolumeBGM = masterVolume;
        masterVolumeSFX = masterVolume;

        bgmPlayer.volume = bgmVolume * masterVolumeBGM;
        sfxPlayer.volume = sfxVolume * masterVolumeSFX;
    }
    // SFX
    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained audioClipsDic");
            return;
        }

        if (!IsPause)
            sfxPlayer.PlayOneShot(audioClipsDic[name], volume * masterVolumeSFX);
    }

    // BGM 
    public void SetBGMSound(int bgm_num, float volume = 1f)
    {
        bgmPlayer.loop = true;
        bgmPlayer.volume = volume * masterVolumeBGM;

        if (bgm_num == 1)
        {
            bgmPlayer.clip = MainBgmAudioClip;
        }
    }

    // Volume
   /* public void SetMasterVolume(float value)
    {
        masterVolumeBGM = value;
        masterVolumeSFX = value;
    }*/

   /* public float GetMasterVolume()
    {
        return masterVolumeBGM;
    }*/

    // Sound Play
    public void PlaySound()
    {
        bgmPlayer.Play();
      //  Debug.Log("player");
        if (IsPause)
            IsPause = false;
    }

    // Sound Pause
    public void PauseSound()
    {
        bgmPlayer.Pause();

        if (!IsPause)
            IsPause = true;
    }
   
    private void Update()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "SFX_SoundPlayer")
            {
                child.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sfxSound") * PlayerPrefs.GetFloat("masterSound");
            }

            if(child.name == "BGM_SoundPlayer")
            {
                child.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("bgmSound") * PlayerPrefs.GetFloat("masterSound");
            }
        }
    }
}