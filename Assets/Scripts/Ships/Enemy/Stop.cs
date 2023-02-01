using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private EnemyShip enemyShip;
    private GameObject playerShip;
    private float shipSpeed;
    private void Start()
    {
        enemyShip = GetComponentInParent<EnemyShip>();
        shipSpeed = enemyShip.speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            playerShip = collision.gameObject;
        }
    }
    private void FixedUpdate()
    {
        if (playerShip==null)
        {
            enemyShip.Move();
        }
    }


       
    
}
