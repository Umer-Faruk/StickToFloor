using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;


public class player : MonoBehaviour
{
    // Start is called before the first frame update
    int helth=5;
    private float timer;
    public float speed;
    public double score = 0;
    public TextMeshProUGUI  scoretext;
    public TextMeshProUGUI  helthtext;

    public GameObject lavaball;

    public KeyCode right;
    public KeyCode left;
    public KeyCode down;
    public KeyCode up;

    public ParticleSystem  heltheffect;
    public ParticleSystem  playerhhitlavaeffect;

    // public GameObject upbutton;

    public double boostscore = 0;

    private  double nlb;
     int ehp = 0;

     public Image hbfill;

//touch controls
    // private Rigidbody rb;
    // public float speed;
    void Start()
    {
        Time.timeScale = 1;
        // upbutton.interactable(false);
        // upbutton.gameObject.SetActive(false);
        // rb = GetComponent<Rigidbody>();

        //  Instantiate(lavaball,new Vector3(0,0,0),Quaternion.identity);
     Chanagenlb();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    //      if(Input.touchCount > 0){
    //         Touch touch = Input.GetTouch(0);
    //         // Debug.Log(touch);
    //         // Debug.Log(touch.phase);
    //  switch(touch.phase){

    //         case TouchPhase.Began :
    //             if(touch.position.x < Screen.width/2){
    //                 Debug.Log("move left");
    //                 rb.velocity = new Vector3(-speed,0,0);
    //             }
    //             if(touch.position.x > Screen.width / 2){
    //                 Debug.Log("Move right");
    //                 rb.velocity = new Vector3(speed,0,0);
    //             }
    //             break;

    //         case TouchPhase.Ended:
    //                 rb.velocity = new Vector3(0,0,0);
    //             break;
    //     }
        


    //     }

        if(helth == 0){
            Debug.Log("Game Over");
        }
        timer += Time.deltaTime;
        boostscore += Time.deltaTime;
        score = Math.Floor(timer);
        scoretext.text = "Score:"+score.ToString();
        helthtext.text = "HP:"+helth.ToString();

        

        
        if( Math.Floor(score/50) > nlb){
            Chanagenlb();
            
        }
        
        if(Input.GetKey(left)){
GetComponent<Rigidbody>().velocity -= new Vector3(0,0,speed);
        }
        if(Input.GetKey(right)){
            GetComponent<Rigidbody>().velocity += new Vector3(0,0,speed);
        }
        if(Input.GetKey(down)){
GetComponent<Rigidbody>().velocity += new Vector3(speed,0,0);
        }

        if(Input.GetKey(up)){
            GetComponent<Rigidbody>().velocity -= new Vector3(speed,0,0);
        }

        // boostscore up button
        // Debug.Log(boostscore);
        // if( boostscore > 10){
        //     upbutton.gameObject.SetActive(true);
        // }
        

        //player fall

        // if(transform.position.y <= 150){
        //     GameOver();
        // }
        
        
        
    }

    private void OnCollisionEnter(Collision collision) {
        //collide with ball 
        if(collision.gameObject.tag == "lavaball"){
            //instantiate effect
           Destroy(Instantiate(playerhhitlavaeffect.gameObject,collision.transform.position,Quaternion.identity) as GameObject ,0.30f); 
           //reset the position of all 
            collision.transform.position = new Vector3(-14,2,UnityEngine.Random.Range((float)-3.29,(float)4.67));
            //decrement the hp and chack for game over condition
                helth -= 1;
            if(helth <= 0){
                GameOver();
                
            }
            
             
        }
        //collide with the lava ground gane over
        if(collision.gameObject.tag == "lava"){
            Debug.Log("Game Over");
            // Time.timeScale = 0;
            GameOver();
        }
           //collide with hp lit increse the helth bar
        if(collision.gameObject.tag == "hp"){
             
           
            ehp += 1;
            hbfill.fillAmount += 0.1f;
            if(ehp == 10){
                 helth +=1;
                 ehp = 0;
                 hbfill.fillAmount = 0;

            }
            //instantiate the effect
            Destroy(Instantiate(heltheffect.gameObject,collision.transform.position,Quaternion.identity) as GameObject,0.20f);
            //reset the pistion of hp
            collision.transform.position = new Vector3(-3.4f,0.87f,UnityEngine.Random.Range(-3, 5));
        }
    }

    private void Chanagenlb(){
        nlb = Math.Floor(score/50);
        Debug.Log(nlb);
        Instantiate(lavaball,new Vector3(-14,2,-1),Quaternion.identity);
                    // Instantiate(this, new Vector3(Random.Range(-2, 5),3,15), Quaternion.identity);


    }

    public void Moveleft(){
        this.GetComponent<Rigidbody>().velocity -= new Vector3(0,0,speed);
    }

    public void MoveRight(){
        this.GetComponent<Rigidbody>().velocity += new Vector3(0,0,speed);
    }

    // public void BoostUP(){
    //      GetComponent<Rigidbody>().velocity = new Vector3(0,5,0);
    //     //   FindObjectOfType<player>().Desableboostbutton();
    //     boostscore = 0;
    //     // upbutton.gameObject.SetActive(false);

    // }

    public void GameOver(){
    PlayerPrefs.SetInt("Score", (int)score);
    Time.timeScale = 0;
    
    SceneManager.LoadScene(3);

    }

    // public void Desableboostbutton(){
    //     boostscore = 0;
    //     upbutton.gameObject.SetActive(false);
    // }
}
