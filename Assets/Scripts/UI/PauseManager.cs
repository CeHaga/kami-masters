using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject optionsGamePopUp;
    public GameObject pauseGamePopUp;
    public Button confirmOptionsGame, cancelOptionsGame, exitOptionsGame;

    private void Awake(){
        confirmOptionsGame.onClick.AddListener(delegate{optionsGame(true);});
        cancelOptionsGame.onClick.AddListener(delegate{optionsGame(false);});
        exitOptionsGame.onClick.AddListener(delegate{optionsGame(false);});
    }

    public void Pause(){
        pauseGamePopUp.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume(){
        pauseGamePopUp.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Options(){
        pauseGamePopUp.gameObject.SetActive(false);
        optionsGamePopUp.gameObject.SetActive(true);
    }

    public void Home(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }

    public void optionsGame(bool clicked){
        if(clicked == true){
            optionsGamePopUp.gameObject.SetActive(false);
            pauseGamePopUp.gameObject.SetActive(true);
        }else{
            optionsGamePopUp.gameObject.SetActive(false);
            pauseGamePopUp.gameObject.SetActive(true);
        }
    }
}
