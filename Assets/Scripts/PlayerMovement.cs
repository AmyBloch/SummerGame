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
        Vector3 movTmp = Input.GetAxis("Vertical") * cameraTransform.forward * movespeed
                           + Input.GetAxis("Horizontal") * cameraTransform.right * movespeed;
        movement.x = movTmp.x;
        movement.z = movTmp.z;
        movement.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(movement * Time.deltaTime);

        Vector3 rotTmp = cameraTransform.forward;
        rotTmp.y = 0;
        characterController.transform.rotation = Quaternion.LookRotation(rotTmp);
    }
}
