using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float movespeed;
    public Transform cameraTransform;

    private Vector3 movement;

    void Start()
    {
        movement = new Vector3();
    }

    void Update()
    {
        Vector3 tmp = Input.GetAxis("Vertical") * cameraTransform.forward * movespeed
                           + Input.GetAxis("Horizontal") * cameraTransform.right * movespeed;
        movement.x = tmp.x;
        movement.z = tmp.z;
        movement.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(movement * Time.deltaTime);
        //characterController.transform.rotation = Quaternion.LookRotation(tmp);
    }
}
