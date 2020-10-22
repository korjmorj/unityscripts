using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlemove : MonoBehaviour
{
public float speedx;
public float speedy;
private bool moveRight;
    // Start is called before the first frame update
    void Start()
    { 
      moveRight=true;
      transform.position=new Vector2(0, 7); 
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
            if (speedx>=0){
            transform.position=new Vector2(transform.position.x+speedx*Time.deltaTime, transform.position.y-speedy*Time.deltaTime);
            }
            else
            {
                 transform.position=new Vector2(transform.position.x-speedx*Time.deltaTime, transform.position.y-speedy*Time.deltaTime);
            }
            }
        else
        {
            transform.position=new Vector2(transform.position.x-speedx*Time.deltaTime, transform.position.y-speedy*Time.deltaTime);
        }
        if(transform.position.x>7f|transform.position.x<-7f|transform.position.y<-5.4f){
            Destroy(gameObject);

        }
    }

}
