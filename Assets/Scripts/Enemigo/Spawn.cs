using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float tiempoEntreSpawns = 3f;



    void Start()
    {
        StartCoroutine(SpawnEnemy(tiempoEntreSpawns, enemy));
    }
    IEnumerator SpawnEnemy(float intervalo, GameObject enemy)
    {
        yield return new WaitForSeconds(intervalo);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f),0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(intervalo, newEnemy));
    }
}
