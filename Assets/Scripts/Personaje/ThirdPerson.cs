using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    private float movX;
    private float movY;

    [SerializeField] private float velocidad;

    private CharacterController charCtrl;

    private void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * movX + transform.forward * movY; 

        charCtrl.Move(movimiento * velocidad * Time.deltaTime);
    }
}
