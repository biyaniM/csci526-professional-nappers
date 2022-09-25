using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecctionOnEnemyKill : MonoBehaviour
{
    public Player player;
    public int redCoins; 
    public int blueCoins;
    public int yellowCoins;
    private bool passed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        // redCoins = int.Parse(player.coinsScore.redScore.text);
        // blueCoins = int.Parse(player.coinsScore.blueScore.text);
         // yellowCoins = int.Parse(player.coinsScore.yellowScore.text);
        passed = false;
    }

    void OnTriggerEnter(Collider collider){
        if(!passed){
            if (collider.gameObject.name == "PaintBallProjectile(Clone)"){
                Debug.Log("Passed?"+passed);
                passed = true;
                Debug.Log("Hit!");
                redCoins = player.GetRedCoinsScore();
                blueCoins = player.GetBlueCoinsScore();
                yellowCoins = player.GetYellowCoinsScore();

                if (gameObject.tag=="enemy1"){
                    Debug.Log("Before Red Kill"+redCoins);
                    redCoins += 1;
                    player.UpdateCoins(redCoins, blueCoins, yellowCoins);
                    Debug.Log("After Red Kill"+redCoins);
                }
                else if (gameObject.tag=="enemy2"){
                    // Debug.Log("Before Blue Kill"+redCoins);
                    yellowCoins += 1;
                    player.UpdateCoins(redCoins, blueCoins, yellowCoins);

                    
                    // Debug.Log("After Red Kill"+redCoins);
                }
                else if (gameObject.tag=="enemy3"){
                    // Debug.Log("Before Red Kill"+redCoins);
                    blueCoins += 1;
                    player.UpdateCoins(redCoins, blueCoins, yellowCoins);
                    
                    // Debug.Log("After Red Kill"+redCoins);
                }
                else{
                    return;
                }
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {        
         //check if player has collected enough colors to pass gate
        player.CheckGoal(redCoins, blueCoins, yellowCoins);
    }
}