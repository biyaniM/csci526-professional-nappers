using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MysteryBox : MonoBehaviour
{
    private enum mysteryBoxTypes {Health, Ammo, GoldenCoin};
    [SerializeField] private mysteryBoxTypes mysteryBoxType;
    [SerializeField] private int changeAmount;
    [SerializeField] private float hudAlertTime = 0.5f;
    private healthUpdate healthUpdateObj;
    private Player playerObj;
    private AmmoCount ammoCountObj;
    private CollectCoins coinCollectObj;
    private Coroutine coroutine;

    void Start()
    {
        GameObject hudObj = GameObject.Find("HUD");
        if (mysteryBoxType == mysteryBoxTypes.Health|| mysteryBoxType == mysteryBoxTypes.GoldenCoin){
            GameObject playerArmature = GameObject.FindGameObjectWithTag("Player");
            if(mysteryBoxType == mysteryBoxTypes.Health){
                healthUpdateObj = playerArmature.GetComponent<healthUpdate>();
            }
            else{
                coinCollectObj = playerArmature.GetComponent<CollectCoins>();
            }
        }else{
            ammoCountObj = hudObj.GetComponentInChildren<AmmoCount>();
        }
        playerObj = hudObj.GetComponent<Player>();
    }

    void Update()
    {
        
    }

    IEnumerator HealthReplenish(int healthIncerement){
        string msg = "HP +"+healthIncerement.ToString();
        playerObj.ShowAlert(msg,"hp");
        healthUpdateObj.currentHealth += healthIncerement;

        try {FindObjectOfType<AudioManager>().play("mystery health");}
        catch (System.NullReferenceException e) { Debug.LogWarning("Death sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

        healthUpdateObj.updateHealth(Mathf.Min(healthUpdateObj.currentHealth,healthUpdateObj.maxHealth));
        yield return new WaitForSeconds(hudAlertTime);
        playerObj.CloseAlert();
    }

    IEnumerator AmmoReplenish(int ammoIncrement){
        string msg = "Ammo +"+ammoIncrement.ToString();
        playerObj.ShowAlert(msg,"ammo");
        ammoCountObj.increaseAmmoCount(ammoIncrement);

        try {FindObjectOfType<AudioManager>().play("mystery ammo");}
        catch (System.NullReferenceException e) { Debug.LogWarning("Death sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

        yield return new WaitForSeconds(hudAlertTime);
        playerObj.CloseAlert();
    }

    IEnumerator GoldenCoin(int coinIncrement){
        string msg = "Gem +"+coinIncrement.ToString();
        playerObj.ShowAlert(msg,"gem");
        coinCollectObj.updateGoldenCoin(coinIncrement);

        try {FindObjectOfType<AudioManager>().play("mystery coin");}
        catch (System.NullReferenceException e) { Debug.LogWarning("Death sound not appointed in "+gameObject.scene+"\n"+e.ToString()); }

        yield return new WaitForSeconds(hudAlertTime);
        playerObj.CloseAlert();
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag=="Player"){
            switch (mysteryBoxType){
                case mysteryBoxTypes.Health:
                    coroutine = StartCoroutine(HealthReplenish(changeAmount));
                    break;
                case mysteryBoxTypes.Ammo:
                    coroutine = StartCoroutine(AmmoReplenish(changeAmount));
                    break;
                case mysteryBoxTypes.GoldenCoin:
                    coroutine = StartCoroutine(GoldenCoin(changeAmount));
                    break;
            }
        }
        StopCoroutine(coroutine);
        Destroy(gameObject);
    }
}
