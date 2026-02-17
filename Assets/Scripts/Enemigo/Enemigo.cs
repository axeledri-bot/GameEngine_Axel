using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    //[SerializeField] private string escena;

    //Detrect
    private bool detected;
    [SerializeField] private float radio;
    [SerializeField] private LayerMask whatIsPlayer;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        detected = Physics.CheckSphere(transform.position, radio, whatIsPlayer);
        if (detected)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent.SetDestination(player.position);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            //SceneManager.LoadScene(escena);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
