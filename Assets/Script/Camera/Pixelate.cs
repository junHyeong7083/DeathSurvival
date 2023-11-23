using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class Pixelate : MonoBehaviour
{
    [Range(1, 100)]
    public float pixelate = 1;
    public static float value = 1;
    public static bool toGame;
    public static bool showHpBar;
    public static bool isChange = false;
    public static bool showDieEffect = false;
    public static bool showDiePanel;
    bool dieshow = false;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture resultTexture = RenderTexture.GetTemporary(source.width / (int)pixelate, source.height /(int) pixelate, 0, source.format);
        resultTexture.filterMode = FilterMode.Point;
        Graphics.Blit(source, resultTexture);
        Graphics.Blit(resultTexture, destination);

        RenderTexture.ReleaseTemporary(resultTexture);
    }



    private void Start()
    {
        showHpBar = false;
        pixelate = value;
        showDiePanel = false;
    }

    private void Update()
    {
        if (toGame)
        {
            pixelate += 150 * Time.deltaTime;

            if (pixelate > 100)
            { 
                isChange = true;
                toGame = false;
                value = 100;
                pixelate = value;
                SceneManager.LoadScene(2);
            }
        }
         if (isChange)
        {
            pixelate -= 150 * Time.deltaTime;
            if (pixelate < 5)
            {
                Debug.Log("???");
                pixelate = 1;
                value = pixelate;
                isChange = false;
                showHpBar = true;
            }
        }

         if(showDieEffect)
        {
            Debug.Log("aaa");
            if(!dieshow)
            {
                pixelate += 500*Time.deltaTime;
                if (pixelate > 300)
                {
                    dieshow = true;
                    value = 150;
                    pixelate = value;
                }
            }
            else if(dieshow)
            {
                    pixelate = 1;
                    value = pixelate;
                    dieshow = false;
                    showDieEffect = false;
                    showDiePanel = true;


            }
        }
    }
}
