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
                shootSound.Play();

                GameObject shotBullet = Instantiate(bullet, shootingPosition[i].position, shootingPosition[i].rotation);

                var bulletComponent = shotBullet.GetComponent<Bullet>();

                bulletComponent.bulletSpeed = shipBulletSpeed;
                bulletComponent.bulletDamage = shipDamage;
                bulletComponent.tag = tagToShot;
            }

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
        Destroy(gameObject);
    }

    protected void Awake()
    {
        currentHealthAmmount = maxHealthAmmount;
        shootSound =GetComponent<AudioSource>();    
    }


}
