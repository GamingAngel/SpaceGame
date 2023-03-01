using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OcClickRestart : MonoBehaviour
{
    [SerializeField] private Fading fadingPanel;
    [SerializeField] private GameObject pausePanel;
    public void Restart()
    {
      Time.timeScale = 1.0f;
      fadingPanel.CallFadeCoroutine(SceneManager.GetActiveScene().buildIndex);
      pausePanel.SetActive(false);
    }
}
