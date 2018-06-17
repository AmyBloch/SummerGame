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
        // get inputs
        Vector3 movTmp = Input.GetAxis("Vertical") * cameraTransform.forward
                           + Input.GetAxis("Horizontal") * cameraTransform.right;
        // isloate the x and y components
        movTmp = Vector3.ProjectOnPlane(movTmp, Vector3.up);
        movTmp.Normalize();
        // apply movespeed
        movTmp *= movespeed;
        movement.x = movTmp.x;
        movement.z = movTmp.z;
        movement.y += Physics.gravity.y * Time.deltaTime;
        // move the character
        characterController.Move(movement * Time.deltaTime);
        // rotate if the character moved
        if(Vector3.zero != movTmp)
        {
            characterController.transform.rotation = Quaternion.LookRotation(movTmp);
        }

    }
}
