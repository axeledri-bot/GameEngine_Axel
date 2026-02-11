using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Transform shootPoint;
    private Transform shootBullet;

    [HideInInspector]
    private RaycastHit hit;

    [SerializeField]private int danio;
    [SerializeField]private float fuerza;
    [SerializeField]private float fuerzaBala;
    [SerializeField]private LayerMask enemyMask;
    //[SerializeField]private GameObject instanceObject;
    [SerializeField]private GameObject instanceBullet;
    private void Start()
    {
        shootPoint = transform.parent;
        shootBullet = transform.GetChild(0);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(shootPoint.position, transform.forward, out hit, 100, enemyMask))
            {
                Debug.Log(hit.transform.name);
                hit.rigidbody.AddForceAtPosition(-hit.normal * fuerza, hit.point);
                hit.transform.GetComponent<VidaEnemigo>().DanioEnemigo(danio);
                //GameObject clone = Instantiate(instanceObject, hit.point, instanceObject.transform.rotation);
                //clone.transform.parent = hit.transform;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject clone = Instantiate(instanceBullet,shootBullet.position,instanceBullet.transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaBala);
            Destroy(clone,10);
            //if (Physics.Raycast(shootPoint.position, transform.forward, out hit, 100, enemyMask))
            //{
            //    Debug.Log(hit.transform.name);
            //    hit.rigidbody.AddForceAtPosition(hit.normal * fuerza, hit.point);
            //    hit.transform.GetComponent<VidaEnemigo>().DanioEnemigo(20);
            //    GameObject clone = Instantiate(instanceObject, hit.point, instanceObject.transform.rotation);
            //    clone.transform.parent = hit.transform;
            //}
        }
    }
}
