using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;

    private float tiempoSiguienteEnemigo;
    private int currentEnemyCount = 0;  // Contador de enemigos activos
    [SerializeField] private int maxEnemies = 5;  // Número máximo de enemigos en escena

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    private void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        // Comprobar si ha pasado el tiempo para crear un enemigo
        if (tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            if (currentEnemyCount < maxEnemies)  // Solo crear enemigos si no hemos alcanzado el límite
            {
                CrearEnemigo();
            }
        }
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        GameObject enemigoInstanciado = Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);

        // Incrementar el contador de enemigos activos
        currentEnemyCount++;

        // Suscribir el evento OnDeath para disminuir el contador cuando el enemigo muera
        enemigoInstanciado.GetComponent<Enemy>().OnDeath += DecrementarContadorEnemigos;
    }

    // Método que se llama cuando un enemigo muere
    private void DecrementarContadorEnemigos()
    {
        currentEnemyCount--;  // Reducir el contador de enemigos cuando uno muere
    }
}
