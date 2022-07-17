using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Freeze : MonoBehaviour
{
    /// <summary>
    /// This script for freezing player which slow their movement speed
    /// Maybe effect on around 2 players in the range
    /// Will refer from powerup activate script and player info script
    /// </summary>

    [Header("Game Variable")]
    [SerializeField] Powerup_Activate powerup;
    GameObject thisPlayer;
    GameObject player;
    PlayerInfo playerInfo;
    int numPowerup = 0;

    [Header("Freeze movement speed")]
    [SerializeField] float moveSpeed = 1f;
    //[SerializeField] float sprintSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        thisPlayer = powerup.player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !thisPlayer && numPowerup < 3){
            //Freeze players

            player = other.gameObject;
            playerInfo = player.GetComponent<PlayerInfo>();

            if (!playerInfo.hasShield)
            {
                StartCoroutine(Freeze(playerInfo));
                numPowerup++;
            }
            
        }
    }

    IEnumerator Freeze(PlayerInfo p)
    {
       
        p.ChangePlayerSpeed(moveSpeed);
        Debug.Log("Freeze on!");

        yield return new WaitForSeconds(5f);

        //speed back to normal after few seconds
        p.ReturnPlayerSpeed();
        Debug.Log("Freeze off!");

        Destroy(gameObject);
        yield return null;
    }
}
