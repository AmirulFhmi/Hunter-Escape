using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Speed : MonoBehaviour
{

    /// <summary>
    /// This script is for giving extra speed to player upon collide
    /// </summary>

    [Header("Game Variable")]
    GameObject player;
    PlayerInfo playerInfo;
    bool once = false;
    [SerializeField] SkinnedMeshRenderer material;

    [Header("Speed up speed:")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float sprintSpeed = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        //material = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !once)
        {
            player = other.gameObject.transform.parent.gameObject;
            playerInfo = player.GetComponent<PlayerInfo>();
            Debug.Log(player);
            material.enabled = false;
            StartCoroutine(OnSpeed(playerInfo));
            once = true;
        }
    }

    IEnumerator OnSpeed(PlayerInfo p)
    {
        p.ChangePlayerSpeed(moveSpeed, sprintSpeed);
        Debug.Log("Speed up on!");

        yield return new WaitForSeconds(5f);

        p.ReturnPlayerSpeed();
        Debug.Log("Speed up off!");

        Destroy(gameObject);
        yield return null;
    }
}
