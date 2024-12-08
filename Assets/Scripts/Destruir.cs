using UnityEngine;

public class Destruir : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
