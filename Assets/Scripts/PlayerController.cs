using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpVelocity = 5f;
    public float gravityScale = 10f;
    public Rigidbody rigidbody;
    public CharacterController controller;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();   
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        //rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rigidbody.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            //rigidbody.velocity = new Vector3(rigidbody.velocity.x, Vector3.up.y * jumpVelocity, rigidbody.velocity.z);
            moveDirection.y = jumpVelocity ;
        }
        float yVector = moveDirection.y;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection.y = yVector;
        if(!controller.isGrounded)
            moveDirection.y += (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }
}
