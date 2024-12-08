using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void DeathAction();
    public event DeathAction OnDeath;

    public int health = 1;

    public void DestroyEnemy()
    {
        OnDeath?.Invoke();  
        Destroy(gameObject);  
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyEnemy(); 
        }
    }
}
