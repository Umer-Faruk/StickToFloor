using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchtomove : MonoBehaviour
{
     private Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            // Debug.Log(touch);
            // Debug.Log(touch.phase);
     switch(touch.phase){

            case TouchPhase.Began :
                if(touch.position.x < Screen.width/2){
                    Debug.Log("move left");
                    rb.velocity = new Vector3(0,0,-speed);
                }
                if(touch.position.x > Screen.width / 2){
                    Debug.Log("Move right");
                    rb.velocity = new Vector3(0,0,speed);
                }
                break;

            case TouchPhase.Ended:
                    rb.velocity = new Vector3(0,0,0);
                break;
        }
        


        }

       

    }
}
