using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vida;

    public void DanioEnemigo(int danio)
    {
        vida -= danio;
        if( vida <= 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
