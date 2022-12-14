using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    // [SerializeField] public bool GameIsPaused = false;
    public Button resume_btn;
    public Button menu_btn;
    public Button restart_btn;
    public Button guide_btn;
    public CountDownTimer timer;
    private ThirdPersonController controller;

    void Awake(){
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }

    private void Start() {
        gameObject.SetActive(false);
    }

    public void Setup(){    // pause the game
        gameObject.SetActive(true);
        //release the cursor to press the button.
        Cursor.lockState = CursorLockMode.None;
        resume_btn.onClick.AddListener(Resume);
        menu_btn.onClick.AddListener(BackToMenu);
        restart_btn.onClick.AddListener(Restart);
        //guide_btn.onClick.AddListener(ShowGuideMenu);
        // timer.pauseTimer();
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
    
    public void Resume(){  //  working
        Debug.Log("resume the game!");
        // timer.resumeTimer();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        // GameIsPaused = false;
        Cursor.visible = false;
        controller.SetPause(false);
    }

    void Restart(){     // working
        Debug.Log("Restart Game!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.visible = false;
        controller.SetPause(false);
    }

    void BackToMenu(){  // working
        Debug.Log("Main Menu!");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene("New_Menu");
        controller.SetPause(false);
    }

    void ShowGuideMenu(){
        Debug.Log("show controls menu!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("TutorialScene");
    }








}
