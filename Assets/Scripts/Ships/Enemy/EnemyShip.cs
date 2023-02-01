using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyShip : Ship
{
    [SerializeField] private float energyToDrop;
    public float speed;
    [SerializeField] private Vector3 direction;

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    protected override void Die()
    {
        Energy.ChangeEnergy(energyToDrop);
        base.Die();
    }

}

