using UnityEngine;

public class Balas : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           collision.gameObject.GetComponent<VidaEnemigo>().DanioEnemigo(100);
            Destroy(gameObject);
        }
    }
}
