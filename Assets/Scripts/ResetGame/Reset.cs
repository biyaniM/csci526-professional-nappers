using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public float threshold = -20f;
    public healthUpdate gameOverHud;
    public LevelComplete level_complete_object;
    SendToGoogle analyticsComponent;

    // Start is called before the first frame update
    void Start()
    {
        analyticsComponent = GameObject.Find("HUD").GetComponent<SendToGoogle>();
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y < threshold) && !level_complete_object.levelOverCheck){
            analyticsComponent.Send(SceneManager.GetActiveScene().buildIndex.ToString(), "NA", "Died", "NA", "NA", "NA", "Falling Down");
            gameOverHud.runGameOverHud();
            gameOverHud.timer.pauseTimer();
            level_complete_object.levelOverCheck = !level_complete_object.levelOverCheck;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }    
    }
}
