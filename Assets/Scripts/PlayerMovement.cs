using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float movespeed;

    private Vector3 movement;

    void Start()
    {
        movement = new Vector3();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * movespeed;
        movement.z = Input.GetAxis("Vertical") * movespeed;
        movement.y += Physics.gravity.y;
        movement *= Time.deltaTime;
        characterController.Move(movement);
    }
}
