using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

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

    public static bool showClearEffect = false;
    public static bool showClearPanel;
    bool dieshow = false;
    bool clearshow = false;
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
        clearshow = false;
        dieshow = false;
        showClearPanel = false;
        toGame = false;
        value = 1;
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
                SceneManager.LoadScene(3);
            }
        }
         if (isChange)
        {
            pixelate -= 150 * Time.deltaTime;
            if (pixelate < 5)
            {
               // Debug.Log("???");
                pixelate = 1;
                value = pixelate;
                isChange = false;
                showHpBar = true;
            }
        }

        #region Die
        if (showDieEffect)
        {
           // Debug.Log("aaa");
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
        #endregion

        #region Clear
        if (showClearEffect)
        {
            if (!clearshow)
            {
                pixelate += 500 * Time.deltaTime;
                if (pixelate > 300)
                {
                    clearshow = true;
                    value = 150;
                    pixelate = value;
                }
            }
            else if (clearshow)
            {
                pixelate = 1;
                value = pixelate;
                clearshow = false;
                showClearEffect = false;
                showClearPanel = true;
            }
        }
        #endregion
    }
}
