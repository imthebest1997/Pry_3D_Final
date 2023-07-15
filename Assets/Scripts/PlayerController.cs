using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] Camera playerCamera;

    [SerializeField] CharacterController characterController;
    [SerializeField] GameObject playerModel;
    [SerializeField] Animator animator;


    private Vector3 moveDirection;

    private void Start()
    {
        print(Physics.gravity.y);
        print(moveDirection.y);
    }

    void Update()
    {
        float y = moveDirection.y;
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Dar movimiento a mi personaje
        moveDirection = (transform.forward * z) + (transform.right * x);
        moveDirection.Normalize();
        moveDirection *= moveSpeed;
        moveDirection.y = y;


        //TODO: NEW
        if(characterController.isGrounded && moveDirection.y< 0)
        {
            moveDirection.y -= (2 * gravityScale);
        }

        //Salto
        if (characterController.isGrounded)
        {
//            print(moveDirection.y);
//            moveDirection.y = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }

        //Agregar gravedad  
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;// * gravityScale

        characterController.Move(moveDirection * Time.deltaTime);

        //Rotar al jugador cuando hay movimiento
        if (x != 0 || z != 0)
        {
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        animator.SetBool("Grounded", characterController.isGrounded);
    }
}