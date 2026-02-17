using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float tiempoEntreSpawns = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreSpawns);

            GameObject enemigo = Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
