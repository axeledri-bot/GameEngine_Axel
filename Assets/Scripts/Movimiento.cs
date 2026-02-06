using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private CharacterController charCtrl;

    public float velocidad;
    public float salto;

    private float movX;
    private float movZ;

    public float gravedad = -9.8f;
    private Vector3 veloY;

    //Ground check
    private bool isGrounded;
    private Transform groundCheck;
    public float radius;
    public LayerMask whatIsGround;

    private void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        groundCheck = transform.GetChild(2);
    }

    private void Update()
    {
        //Gravedad
        isGrounded = Physics.CheckSphere(groundCheck.position,radius,whatIsGround);
        veloY.y += gravedad * Time.deltaTime;
        
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            veloY.y = Mathf.Sqrt(salto * -2f * gravedad);
        }

        if(isGrounded && veloY.y < 0)
        {
            veloY.y = 0;
        }
        charCtrl.Move(veloY * Time.deltaTime);

        //Movimiento
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movX + transform.forward * movZ;

        charCtrl.Move(movimiento * velocidad * Time.deltaTime);
    }
}
