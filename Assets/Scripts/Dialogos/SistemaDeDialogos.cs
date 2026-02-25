using System.Collections;
using System.Diagnostics.Tracing;
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

    private Coroutine rout;
    private bool active;
    private void Update()
    {
        inside = Physics.CheckSphere(transform.position, radio, personaje);
        if (inside && Input.GetKeyDown(KeyCode.E) && linea < palabras.Length - 1)
        {
            Time.timeScale = 0f;
            if (active)
            {
                active = false;
                StopCoroutine(Hablar());
            }
            sistemaDialogos.SetActive(true);
            nombre.text = palabras[linea].nombre;
            nombre.text = palabras[linea].nombre;
            rout = StartCoroutine(Hablar());
            pers1.sprite = palabras[linea].pers1;
            pers2.sprite = palabras[linea].pers2;
            caja.sprite = palabras[linea].caja;
        }
        else if (inside && Input.GetKeyDown(KeyCode.E))
        {
            if (active)
            {
                StopCoroutine(Hablar());
                active = false;
            }
            sistemaDialogos.SetActive(false);
            linea = 0;
            Time.timeScale = 1f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
    IEnumerator Hablar()
    {
        active = true;
        texto.text = "";
        for(int i = 0; i< palabras[linea].dialogo.Length; i++)
        {
            texto.text += palabras[linea].dialogo[i];
            yield return new WaitForSecondsRealtime(.1f);
        }
        linea++;
        active = false;
    }
}
