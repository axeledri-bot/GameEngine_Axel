using UnityEngine;

public class Municion : MonoBehaviour
{
    [SerializeField] private int cantidad = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.RecogerBalas(cantidad);
            Destroy(gameObject);
        }
    }
}
