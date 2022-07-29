using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameFadeIn : MonoBehaviour
{

    public Texture2D fadeTexture;
    public float fadeSpeed = 0.6f;
    public float fadeDelay = 10.0f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = 0;


    void Awake()
    {
        alpha = 1.0f;
        StartCoroutine(BeginFade(-1));
    }

    void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public IEnumerator BeginFade(int direction)
    {
        yield return new WaitForSeconds(fadeDelay);
        fadeDirection = direction;
    }

}
