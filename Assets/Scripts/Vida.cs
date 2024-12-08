using UnityEngine;

public class Vida : MonoBehaviour
{

    public float PuntosVida;
    public float VidaMaxima = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PuntosVida = VidaMaxima;
    }

    public void TakeHit(float golpe)
    {
        PuntosVida -= golpe;
        if (PuntosVida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
