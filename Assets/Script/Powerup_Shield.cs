using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Shield : MonoBehaviour
{
    /// <summary>
    /// This script is for giving shield to player upon collide
    /// will called bool isShield = true at playerInfo script
    /// </summary>

    [Header("Game Variable")]
    GameObject player;
    PlayerInfo playerInfo;
    bool once = false;
    [SerializeField] SkinnedMeshRenderer material;

    // Start is called before the first frame update
    void Start()
    {
        //material = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !once)
        {
            //OnShield(other.gameObject);
            player = other.gameObject;
            Debug.Log(player);
            material.enabled = false;
            StartCoroutine(OnShield(player));
            once = true;
            //gameObject.SetActive(false);
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

        Destroy(gameObject);
        yield return null;
    }
}
