using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject optionsGamePopUp;
    public GameObject exitGamePopUp;

    [Header("Buttons")]
    public Button yesExitGame;
    public Button noExitGame;
    public Button exitExitGame;
    public Button confirmOptionsGame;
    public Button cancelOptionsGame;
    public Button exitOptionsGame;
    
    private void Awake(){
        confirmOptionsGame.onClick.AddListener(delegate{optionsGame(true);});
        cancelOptionsGame.onClick.AddListener(delegate{optionsGame(false);});
        exitOptionsGame.onClick.AddListener(delegate{optionsGame(false);});

        yesExitGame.onClick.AddListener(delegate{exitGame(true);});
        noExitGame.onClick.AddListener(delegate{exitGame(false);});
        exitExitGame.onClick.AddListener(delegate{exitGame(false);});
    }

    //Start Button Function
    public void startMenu(){
        SceneManager.LoadScene("ChoosePhase");
    }

    //Options Button Function
    public void optionsMenu(){
        homeMenu.gameObject.SetActive(false);
        optionsGamePopUp.gameObject.SetActive(true);
    }


    //Exit Button Function
    public void exitMenu(){
        homeMenu.gameObject.SetActive(false);
        exitGamePopUp.gameObject.SetActive(true);
    }

    //Options Game PopUp Function
    public void optionsGame(bool clicked){
        if(clicked == true){
            optionsGamePopUp.gameObject.SetActive(false);
            homeMenu.gameObject.SetActive(true);
        }else{
            optionsGamePopUp.gameObject.SetActive(false);
            homeMenu.gameObject.SetActive(true);
        }
    }

    //Exit Game PopUp Function
    public void exitGame(bool clicked){
        if(clicked == true){
            Debug.Log("Saindo do Jogo");
            Application.Quit();
        }else{
            exitGamePopUp.gameObject.SetActive(false);
            homeMenu.gameObject.SetActive(true);
        }
    }
}
