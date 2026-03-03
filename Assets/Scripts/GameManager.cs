using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int balasActuales = 4;
    public int balasMaximas = 9;

    public TMP_Text textoBalas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        textoBalas.text = "Balas: " + balasActuales + " / " + balasMaximas;
    }

    public bool GastarBala()
    {
        if (balasActuales > 0)
        {
            balasActuales--;
            return true;
        }
        return false;
    }

    public void RecogerBalas(int cantidad)
    {
        balasActuales += cantidad;

        if (balasActuales > balasMaximas)
            balasActuales = balasMaximas;
    }
}
