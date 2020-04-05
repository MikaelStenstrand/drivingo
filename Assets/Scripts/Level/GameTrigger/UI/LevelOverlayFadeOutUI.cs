using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LevelOverlayFadeOutUI : MonoBehaviour
{

    private Image levelOverlayImg;


    private void Awake()
    {
        levelOverlayImg = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(LevelFadeOut());
    }

    IEnumerator LevelFadeOut()
    {
        for (float fade = 0f; fade <= 1; fade += 0.1f)
        {
            Color color = levelOverlayImg.color;
            color.a = fade;
            levelOverlayImg.color = color;
            yield return null;
        }
    }
}
/**
 *  float fade = 0.0f;
        while (fade <= 1.0f)
        {
            Color color = Color.Lerp(Color.clear, Color.black, fade);
            
            fade = 0.05f * Time.deltaTime;
            yield return null;
        }
*/