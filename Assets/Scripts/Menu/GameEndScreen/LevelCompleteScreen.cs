using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen: MonoBehaviour
{
    [SerializeField] Button restartBtn;
    [SerializeField] Button nextLevelBtn;
    [SerializeField] int curr_level;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void Setup(){
        gameObject.SetActive(true);
        //release the cursor to press the button.
        Cursor.lockState = CursorLockMode.None;
        restartBtn.onClick.AddListener(ResetGame);
        nextLevelBtn.onClick.AddListener(NextLevel);
        Debug.Log("Setup game end ui");
    }

    void ResetGame(){
        Debug.Log("Restart Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void NextLevel(){
        curr_level = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Next Level");
        if(curr_level == 0){
            SceneManager.LoadScene("Level_1");
        }
    }
}
