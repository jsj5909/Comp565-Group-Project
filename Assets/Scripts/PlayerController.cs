using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 1;
    [SerializeField] float moveSpeed = 1;

    private bool canMove = false;

    float originalSpeed;


    Camera mainCamera;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        SlowDown.OnEnteringSlowZone += ModifySpeed;
        
        controller = GetComponent<CharacterController>();

        mainCamera = Camera.main;

        originalSpeed = moveSpeed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {

            Vector3 mouseLook;
            Vector3 verticalMove;
            Vector3 horizontalMove;

            horizontalMove = transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            verticalMove = transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


            mouseLook = new Vector3(Input.GetAxisRaw("Mouse Y") * -1, Input.GetAxisRaw("Mouse X"), 0) * mouseSensitivity;


            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseLook.y, transform.rotation.eulerAngles.z);


            mainCamera.transform.rotation = Quaternion.Euler(mainCamera.transform.rotation.eulerAngles.x + mouseLook.x, mainCamera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            controller.Move(horizontalMove + verticalMove);
        }
    }

    
    void ModifySpeed(float modifier)
    {
        moveSpeed = originalSpeed * modifier;
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    public bool GetCanMove()
    {
        return canMove;
    }

}
