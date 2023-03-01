using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnClickLoad : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    [SerializeField] private InterstitialAds ad;
    public void LoadLevel()
    {   if(levelIndex > 1)
        {
            ad.ShowAd();
        }
        SceneManager.LoadScene(levelIndex);
    }
    private void Start()
    {
        if (levelIndex > PlayerPrefs.GetInt("OpenLevel") && levelIndex!=1)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
