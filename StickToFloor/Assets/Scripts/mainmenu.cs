using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI  startHelpText;
    

   
   public void showtext(){
       if(startHelpText.enabled){
           startHelpText.enabled = false;
       }
       else{
           startHelpText.enabled = true;
       }
       
   }
    
    public void playebutton(){
    SceneManager.LoadScene(1);

    }

    public void Optionbutton(){
    SceneManager.LoadScene(2);
    }

    public void Quitbutton(){
        Application.Quit();
    }

    public void Backbutton(){
        SceneManager.LoadScene(0);

      
    }


}
