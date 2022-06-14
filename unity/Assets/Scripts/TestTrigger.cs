using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestTrigger : MonoBehaviour
{
    public Text uiText;
    public float fadeSpeed = 0.75f;
    public float displayTime = 2.0f;

    private bool triggered = false;
    private float alpha = 0.0f;
    private int direction = 0;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            alpha += direction * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);
            Color newColor = new Color(1f, 1f, 1f);
            newColor.a = alpha;
            uiText.color = newColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered)
        {
            return;
        }

        triggered = true;
        direction = 1;

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(displayTime + (1 / fadeSpeed));
        direction = -1;
    }
}
