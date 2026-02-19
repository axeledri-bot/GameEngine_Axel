using UnityEngine;

[System.Serializable]
public class Palabras 
{
    public string nombre;

    [TextArea(3,5)]
    public string dialogo;

    public Sprite pers1;
    public Sprite pers2;

    public Sprite caja;
}
