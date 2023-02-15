using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShip : Ship
{
    [SerializeField] private float energyToDrop;

  
    public float speed;
    [SerializeField] private Vector3 direction;

    public static float enemyCount;

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime * direction);
        
    }

    protected override void Die()
    {
        Energy.ChangeEnergy(energyToDrop);
        enemyCount--;

        currentHealthAmmount = maxHealthAmmount; 
        // I did this so ship does not die 2 times, tryed deactivating colliders, script, however only this one seems to work
        // Need to change it in the future. I have no more ideas for now
        Debug.Log(enemyCount);

        if (enemyCount <= 0)
        {
                //event for fading
            SceneManager.LoadScene("LevelSelection");
        }

        base.Die();  
    }
}

