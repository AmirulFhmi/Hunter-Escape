using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Photon;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviourPun
{
    /// <summary>
    /// This script for getting info from player such as player speed, player collider, etc
    /// </summary>

    [SerializeField] GameObject player;
    PlayerScripts playerController;
    public bool hasShield = false;
    float oldMoveSpeed;
    //float oldSprintSpeed;
    public Transform playerCheckpoint;
    //bool isTeleported = false;

    public int isMany = 0;
    bool changeScene = false;

    //for activating magnet
    GameObject magnetPosition;
    bool isMagnet = false;
    float pullSpeed = 0;
    GameStartManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            player = gameObject;
            playerController = gameObject.GetComponent<PlayerScripts>();
            oldMoveSpeed = playerController.playerSpeed;
            //oldSprintSpeed = playerController.SprintSpeed;
            gameManager = GameStartManager.Instance;

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnet)
        {
            //transform.position = Vector3.Lerp(transform.position, magnetPosition.transform.position, pullSpeed * Time.deltaTime);
            player.transform.position = Vector3.MoveTowards(player.transform.position, magnetPosition.transform.position, pullSpeed * Time.deltaTime);
        }

        if (gameManager.isChangeScene)
        {
            ChangeScene();
            //return;
        }
    }

    private void FixedUpdate()
    {
    }

    public void ChangePlayerSpeed(float newMoveSpeed)
    {
        playerController.playerSpeed = newMoveSpeed;
        //playerController.SprintSpeed = newSprintSpeed;
    }

    public void ReturnPlayerSpeed()
    {
        playerController.playerSpeed = oldMoveSpeed;
        //playerController.SprintSpeed = oldSprintSpeed;
    }

    public void PullPlayer(GameObject p, float speed)
    {
        magnetPosition = p;
        Debug.Log(magnetPosition);
        pullSpeed = speed;
        playerController.enabled = false;
        isMagnet = true;
    }

    public void ReleasePlayer()
    {
        isMagnet = false;
        playerController.enabled = true;
    }

    public void UpdateCheckpoint(Transform p)
    {
        playerCheckpoint = p;
        Debug.Log("Updated checkpoint!");
    }

    public void RespawnCheckpoint()
    {
        player.transform.position = new Vector3(playerCheckpoint.transform.position.x, playerCheckpoint.transform.position.y, playerCheckpoint.transform.position.z);
    }

    public void ChangeScene()
    {
        if (isMany == 1)
        {
            SceneManager.LoadScene("Level2New");
        }
        else if (isMany == 2)
        {
            SceneManager.LoadScene("Level3New");
        }
        else if (isMany == 3)
        {
            SceneManager.LoadScene("Leaderboard");
        }
    }

    //public void TriggerShieldOn()
    //{
    //    hasShield = true;
    //    Debug.Log("Shield on!");

    //    new WaitForSeconds(5f);

    //    hasShield = false;
    //    Debug.Log("Shield off!");
    //}


}
