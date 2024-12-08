using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 3.0f;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemigo = collision.collider.GetComponent<Vida>();
        if (enemigo)
        {
            enemigo.TakeHit(2);
        }
        
        
        Destroy(gameObject);
    }
}