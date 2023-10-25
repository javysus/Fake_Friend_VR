using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerSit : MonoBehaviour
{
    [SerializeField] private InputActionProperty sitButton;
    [SerializeField] private float sitHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    public Animator CamiController;

    private float vomitHeight = 1f;
    private float sittingHeight = 1.5f;
    private float normalHeight = 1.7f;

    public Vector3 posicionPararse = new Vector3(-0.435000002f, 0.32100001f, 0.569999993f);
    public GameObject sentarseButton;
    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bool _isGrounded = IsGrounded();

        /*if(sitButton.action.WasPressedThisFrame() *//*&& _isGrounded*//*)
        {
            Sit();

            cc.height = sittingHeight;
            cc.Move(movement * Time.deltaTime);

            //CamiController.SetTrigger("vomitar");
        }*/

        //movement.y += gravity * Time.deltaTime;

        
    }

    public void Vomitar()
    {
        movement.y = transform.position.y - 5f;
        cc.height = vomitHeight;
        cc.Move(movement * Time.deltaTime);
        CamiController.SetTrigger("vomitar");

        //Evitar que se mueva
        GetComponent<HeredaXR>().moveSpeed = 0f;
    }

    public void SitDown()
    {
        movement.y = transform.position.y - 5f;
        cc.height = sittingHeight;
        cc.Move(movement * Time.deltaTime);
        CamiController.SetTrigger("sentarse");

        //Evitar que se mueva
        GetComponent<HeredaXR>().moveSpeed = 0f;
    }

    public void SitUp()
    {
        movement.y = transform.position.y + 3f;
        cc.Move(movement * Time.deltaTime);
        cc.height = normalHeight;

        CamiController.SetTrigger("idle");

        //Mover al personaje para que no se pare encima 
        
        transform.position = posicionPararse;

        //Reanudar movimiento que se mueva
        GetComponent<HeredaXR>().moveSpeed = 0.5f;

        //Desactivar boton
        sentarseButton.LeanScale(Vector3.zero, 1f);
        sentarseButton.SetActive(false);

    }

    private void Sit()
    {
        //movement.y = Mathf.Sqrt(sitHeight * -3.0f * gravity);

        movement.y = transform.position.y - 5f;
    }
}
