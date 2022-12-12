using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Transform pivot;
    public Vector3 offset;
    public bool useOffsetValues;

    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0f, horizontal, 0f);
        float desiredYAngle = target.eulerAngles.y;

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(vertical, 0, 0);

        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        //transform.position = target.position - (rotation * offset);

       // transform.position = (target.position - offset);

        transform.LookAt(target);
    }
}
