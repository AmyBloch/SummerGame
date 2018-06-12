using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;
    public float rotationSpeed;

	void Start()
    {
        offset = this.transform.position - target.transform.position;
	}
	
	void LateUpdate()
    {
        Quaternion rotationAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
        offset = rotationAngle * offset;
        this.transform.position = target.transform.position + offset;
        this.transform.LookAt(target.transform);
	}
}
