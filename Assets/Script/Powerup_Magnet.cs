using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Magnet : MonoBehaviour
{

    /// <summary>
    /// This script is for pulling other players towards the powerup location
    /// </summary>

    [Header("Game Variable")]
    [SerializeField] GameObject magnetpower;
    [SerializeField] Powerup_Activate powerup;
    GameObject thisPlayer;
    GameObject player;
    PlayerInfo playerInfo;
    int numPowerup = 0;

    [Header("Pull speed")]
    [SerializeField] float pullSpeed = 1f;

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
        if(other.CompareTag("Player") && !thisPlayer && numPowerup < 3)
        {
            player = other.gameObject.transform.parent.gameObject;
            playerInfo = player.GetComponent<PlayerInfo>();

            if (!playerInfo.hasShield)
            {
                StartCoroutine(Magnet(playerInfo));
                numPowerup++;
            }
        }
    }

    IEnumerator Magnet(PlayerInfo p)
    {
        p.PullPlayer(magnetpower, pullSpeed);
        Debug.Log("Magnet on!");

        yield return new WaitForSeconds(5f);

        //speed back to normal after few seconds
        p.ReleasePlayer();
        Debug.Log("Magnet off!");

        Destroy(gameObject.transform.parent.gameObject);

        yield return null;
    }
}
