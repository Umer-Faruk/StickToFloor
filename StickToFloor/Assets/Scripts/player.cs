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

    public GameObject upbutton;

    public double boostscore = 0;

    private  double nlb;
    void Start()
    {
        Time.timeScale = 1;
        // upbutton.interactable(false);
        upbutton.gameObject.SetActive(false);
        //  Instantiate(lavaball,new Vector3(0,0,0),Quaternion.identity);
     Chanagenlb();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(helth == 0){
            Debug.Log("Game Over");
        }
        timer += Time.deltaTime;
        boostscore += Time.deltaTime;
        score = Math.Floor(timer);
        scoretext.text = "Score:"+score.ToString();
        helthtext.text = "Helth:"+helth.ToString();

        

        
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
        Debug.Log(boostscore);
        if( boostscore > 10){
            upbutton.gameObject.SetActive(true);
        }
        

        //player fall

        if(transform.position.y <= 150){
            GameOver();
        }
        
        
        
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "lavaball"){
            collision.transform.position = new Vector3(165,184,UnityEngine.Random.Range(-496,-478));
            
                helth -= 1;
            if(helth <= 0){
                GameOver();
                
            }
            
             
        }

        if(collision.gameObject.tag == "lava"){
            Debug.Log("Game Over");
            // Time.timeScale = 0;
            GameOver();
        }
    }

    private void Chanagenlb(){
        nlb = Math.Floor(score/50);
        Debug.Log(nlb);
        Instantiate(lavaball,new Vector3(173,176,-492),Quaternion.identity);
                    // Instantiate(this, new Vector3(Random.Range(-2, 5),3,15), Quaternion.identity);


    }

    public void Moveleft(){
        this.GetComponent<Rigidbody>().velocity -= new Vector3(0,0,speed);
    }

    public void MoveRight(){
        this.GetComponent<Rigidbody>().velocity += new Vector3(0,0,speed);
    }

    public void BoostUP(){
         GetComponent<Rigidbody>().velocity -= new Vector3(speed*5,0,0);
        //   FindObjectOfType<player>().Desableboostbutton();
        boostscore = 0;
        upbutton.gameObject.SetActive(false);

    }

    public void GameOver(){
    PlayerPrefs.SetInt("Score", (int)score);
    Time.timeScale = 0;
    
    SceneManager.LoadScene(3);

    }

    public void Desableboostbutton(){
        boostscore = 0;
        upbutton.gameObject.SetActive(false);
    }
}
