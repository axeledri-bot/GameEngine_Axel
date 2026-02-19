using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDeDialogos : MonoBehaviour
{
    public Palabras[] palabras;

    //Referencia a UI
    [Header("UI")]
    public GameObject sistemaDialogos;
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI texto;
    public Image pers1;
    public Image pers2;
    public Image caja;

    private int linea = 0;

    //Deteccion
    private bool inside;
    [Header("Deteccion")]
    public float radio;
    public LayerMask personaje;


    private void Update()
    {
        inside = Physics.CheckSphere(transform.position, radio, personaje);
        if (inside && Input.GetKeyDown(KeyCode.E) && linea < palabras.Length)
        {
            sistemaDialogos.SetActive(true);
            nombre.text = palabras[linea].nombre;
            nombre.text = palabras[linea].nombre;
            texto.text = palabras[linea].dialogo;
            pers1.sprite = palabras[linea].pers1;
            pers2.sprite = palabras[linea].pers2;
            caja.sprite = palabras[linea].caja;
            linea++;
        }
        else if (inside && Input.GetKeyDown(KeyCode.E))
        {
            sistemaDialogos.SetActive(false);
            linea = 0;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

}
