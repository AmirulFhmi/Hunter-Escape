using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Shield : MonoBehaviour
{
    /// <summary>
    /// This script is for giving shield to player upon collide
    /// will called bool isShield = true at playerInfo script
    /// </summary>

    GameObject player;
    PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //OnShield(other.gameObject);
            player = other.gameObject.transform.parent.gameObject;
            Debug.Log(player);
            StartCoroutine(OnShield(player));
        }
    }

    IEnumerator OnShield(GameObject p)
    {

        player = p;
        playerInfo = player.GetComponent<PlayerInfo>();
        
        playerInfo.hasShield = true;
        Debug.Log("Shield on!");

        yield return new WaitForSeconds(5f);
        
        playerInfo.hasShield = false;
        Debug.Log("Shield off!");

        yield return null;
    }
}
