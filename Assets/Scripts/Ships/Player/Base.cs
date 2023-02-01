using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] private TMP_Text healthAmmount;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Fading fadingPanel;

    [SerializeField] private float maxHealthAmmount;
    private float currentHealthAmmount;

   private void Start()
    {
        currentHealthAmmount = maxHealthAmmount;

        healthAmmount.text = currentHealthAmmount.ToString();
        healthSlider.maxValue = currentHealthAmmount;
        healthSlider.value = healthSlider.maxValue;
    }


    private void OnCollisionEnter(Collision collision)
    {

            if (collision.gameObject.TryGetComponent<Bullet>(out var bullet))
            {
                TakeDamage(bullet.bulletDamage);
                Destroy(collision.gameObject);
            }
        
    }



    private  void TakeDamage(float damage)
    {

        currentHealthAmmount -= damage;

        healthSlider.value = currentHealthAmmount;
        healthAmmount.text = currentHealthAmmount.ToString();

        if (currentHealthAmmount <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        fadingPanel.CallFadeCoroutine();
        Destroy(gameObject);
    }

}
