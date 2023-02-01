using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float bulletDamage;
    [HideInInspector]
    public float bulletSpeed;

    private float bulletLifeTime=20f;

    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
    }

}
