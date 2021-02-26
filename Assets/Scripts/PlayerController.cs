using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 1;
    [SerializeField] float moveSpeed = 1;


    Camera mainCamera;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseLook;
        Vector3 verticalMove;
        Vector3 horizontalMove;

        horizontalMove = transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMove = transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        mouseLook = new Vector3(Input.GetAxisRaw("Mouse Y") * -1, Input.GetAxisRaw("Mouse X"), 0) * mouseSensitivity;

        //Quaternion look = Quaternion.LookRotation(mouseLook);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseLook.y, transform.rotation.eulerAngles.z);


        mainCamera.transform.rotation = Quaternion.Euler(mainCamera.transform.rotation.eulerAngles.x + mouseLook.x, mainCamera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        controller.Move(horizontalMove + verticalMove);
    }
}
