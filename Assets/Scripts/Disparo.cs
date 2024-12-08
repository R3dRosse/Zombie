using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Projectile LaBala;
    public Transform PuntoDisparo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(LaBala, PuntoDisparo.position, transform.rotation);
        }
    }
}
