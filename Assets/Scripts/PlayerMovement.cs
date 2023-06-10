using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    private float speed = 8f;
    private float cameraMoveSpeed = 5f;
    float rotationX = 0f;
    public float lookXLimit = 45.0f;
    
  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {

            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5f, 0));
        }
    }

    void Rotate()
    {


        rotationX += -Input.GetAxis("Mouse Y") * cameraMoveSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * cameraMoveSpeed, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        player.transform.position = new Vector3(0, 1, 0);
        Debug.Log("contact");
    }
}
