using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPointing;
    private float cameraMoveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Mouse X");
        //float y = Input.GetAxis("Mouse Y");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z);
        //transform.Rotate(cameraMoveSpeed * y, cameraMoveSpeed * x, 0);
        
    }
}
