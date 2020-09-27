using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaball : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "lava"){
            Debug.Log("collide with lava");
            transform.position = new Vector3(-14,2,Random.Range((float)-3.29,(float)4.67));
        }
    }
}
