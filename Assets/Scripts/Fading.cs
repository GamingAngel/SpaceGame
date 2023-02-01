using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    private Image fadeImage;

    private float fadingTime = 5f;
    private bool fadeOut = true;
    private void Awake()
    {
        Time.timeScale = 1f;
        fadeImage = GetComponent<Image>();
        CallFadeCoroutine();
    }

    public void CallFadeCoroutine()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
       
        if(fadeOut)
        {
            fadeImage.CrossFadeAlpha(0f, fadingTime, true);
            fadeOut = false;
        }
        else
        {
            fadeImage.raycastTarget = true;
            fadeImage.CrossFadeAlpha(1f, fadingTime, true);
            yield return new WaitForSeconds(fadingTime + 2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
        
    }

}
