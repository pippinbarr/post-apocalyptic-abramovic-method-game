using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionsFader : MonoBehaviour
{

    public Texture2D fadeTexture;
    public float fadeSpeed = 0.6f;
    public float fadeDelay = 1.0f;
    public float instructionsTime = 2.0f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = 0;


    void Awake()
    {
        alpha = 1.0f;
        StartCoroutine(BeginFade(-1));
        StartCoroutine(BeginLoadGame());
    }

    void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

        if (fadeDirection == -1 && alpha == 0)
        {
            fadeDirection = 0;
            StartCoroutine(ShowInstructions());
        }
    }

    public IEnumerator BeginFade(int direction)
    {
        yield return new WaitForSeconds(fadeDelay);
        fadeDirection = direction;
        alpha = 1.0f;
    }

    public IEnumerator ShowInstructions()
    {
        yield return new WaitForSeconds(instructionsTime);
        fadeDirection = 1;
        alpha = 0.0f;
    }

    public IEnumerator BeginLoadGame()
    {
        float secondsToLoad = fadeDelay + (0.5f / fadeSpeed) + instructionsTime + (0.5f / fadeSpeed);
        Debug.Log("Instructions seconds to load = " + secondsToLoad);
        yield return new WaitForSeconds(secondsToLoad);
        SceneManager.LoadScene("Game");
    }
}
