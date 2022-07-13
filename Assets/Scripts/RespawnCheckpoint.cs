using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheckpoint : MonoBehaviour
{
    /// <summary>
    /// This script is for respawning player at certain checkpoint saved 
    /// inside playerinfo script when collide with the cube
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
        //Debug.Log(other.gameObject);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            player = other.gameObject.transform.parent.gameObject;
            playerInfo = player.GetComponent<PlayerInfo>();

            playerInfo.RespawnCheckpoint();
        }
    }
}
