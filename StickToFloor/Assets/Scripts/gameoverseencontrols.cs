 
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class gameoverseencontrols : MonoBehaviour
{ 
 public TextMeshProUGUI  scoretext;
 
//  public void Start() {
       
//     //  scoretext.text = "high Score:"+FindObjectOfType<player>().score.ToString(); 
//  }

private void Start() {
    
    // setendscore();
    scoretext.text = "high Score:"+PlayerPrefs.GetInt("Score");
    PlayerPrefs.DeleteKey("Score");

}
 public void playagain(){
     SceneManager.LoadScene(1);
 }

 public void blackbutton(){
     SceneManager.LoadScene(0);
 }

 public void setendscore(){

     Debug.Log(FindObjectOfType<player>().score);
 }
 
}
