using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] protected float maxHealthAmmount;
    protected float currentHealthAmmount;

    [SerializeField] protected string tagToShot;

    [SerializeField] protected float shipDamage;
    [SerializeField] protected float shipBulletSpeed;

    [SerializeField] protected float fireRate;
    private float lastShotTime;

    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform[] shootingPosition;

    protected AudioSource shootSound;

    [SerializeField] private GameObject blowUp;

    protected void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(tagToShot) && (other.name != "Bullet(Clone)"))
        {
            Fire();
        }
    }

    protected void Fire()
    {
        if (Time.time > fireRate + lastShotTime)
        {
            for (int i = 0; i < shootingPosition.Length; i++)
            {
                

                GameObject shotBullet = Instantiate(bullet, shootingPosition[i].position, shootingPosition[i].rotation);

                var bulletComponent = shotBullet.GetComponent<Bullet>();

                bulletComponent.bulletSpeed = shipBulletSpeed;
                bulletComponent.bulletDamage = shipDamage;
                bulletComponent.tag = tagToShot;
            }
            shootSound.Play();
            lastShotTime = Time.time;
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            if (collision.gameObject.TryGetComponent<Bullet>(out var bullet))
            {
                TakeDamage(bullet.bulletDamage);
                Destroy(collision.gameObject);
            }
        }
    }

    protected  void TakeDamage(float damage)
    {
       
        currentHealthAmmount -= damage;
        if (currentHealthAmmount <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Instantiate(blowUp);
        Destroy(gameObject);
    }

    protected void Awake()
    {
        currentHealthAmmount = maxHealthAmmount;
        shootSound =GetComponent<AudioSource>();    
    }


}
