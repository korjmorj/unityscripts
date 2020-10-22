using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMove : MonoBehaviour
{
    public float speed;
    private bool moveRight;
    // Start is called before the first frame update
    void Start()
    { 
      moveRight=true;  
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>5f){
            moveRight=false;
        }
        else if (transform.position.x<-5f)
        {
            moveRight=true;
        }
        if(moveRight){
            transform.position=new Vector2(transform.position.x+speed*Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position=new Vector2(transform.position.x-speed*Time.deltaTime, transform.position.y);
        }
    }
}
