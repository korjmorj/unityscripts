using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour

{   
    public float moveSpeed = 6f;
    public float HorizontalBorder = 4.0f;
    public float VerticalBorder = 4.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, verticalInput * moveSpeed * Time.deltaTime, 0);
        if (transform.position.x<-HorizontalBorder){transform.position = new Vector3(-HorizontalBorder, transform.position.y, transform.position.z);}
        if (transform.position.x>HorizontalBorder){transform.position = new Vector3(HorizontalBorder, transform.position.y, transform.position.z);}
        if (transform.position.y<-VerticalBorder){transform.position = new Vector3(transform.position.x, -VerticalBorder, transform.position.z);}
        if (transform.position.y<-VerticalBorder){transform.position = new Vector3(transform.position.x, VerticalBorder, transform.position.z);}
    }
}
