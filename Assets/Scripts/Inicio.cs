using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
   
    void Start()
    {
        //AudioManager.instance.Play("");
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("");
            //AudioManager.instance.Stop("");
        }
    }
}
