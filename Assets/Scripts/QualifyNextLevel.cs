using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class QualifyNextLevel : MonoBehaviour
{
    int slot = 0;
    [SerializeField] GameStartManager gameManager;
    bool isMany = false;
    GameObject player;
    PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameStartManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(slot == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            StartCoroutine(gameManager.ChangeScene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.playerCount <= 3)
        {
            isMany = false;

            if (other.CompareTag("Player"))
            {
                player = other.gameObject;
                playerInfo = player.GetComponent<PlayerInfo>();

                

                if (slot <= 2)
                {
                    //save score
                    StartCoroutine(gameManager.saveScore());
                    gameManager.SetPositionPanel(slot+1);
                    gameManager.ChangeGameState(GameStartManager.GameState.End);
                    //qualify to next level
                    playerInfo.isMany = 1;

                    Debug.Log("Your position is " + slot);
                    slot++;
                }
                else
                {
                    //save score
                    StartCoroutine(gameManager.saveScore());
                    gameManager.SetPositionPanel(slot+1);
                    gameManager.ChangeGameState(GameStartManager.GameState.End);
                    //not qualify
                    playerInfo.isMany = 3;
                    slot++;
                }
            }
        }
        else if(gameManager.playerCount > 3)
        {
            isMany = true;

            if (other.CompareTag("Player"))
            {
                player = other.gameObject.transform.parent.gameObject;
                playerInfo = player.GetComponent<PlayerInfo>();

                

                if (slot <= 4)
                {
                    //save score
                    StartCoroutine(gameManager.saveScore());
                    gameManager.SetPositionPanel(slot+1);
                    gameManager.ChangeGameState(GameStartManager.GameState.End);
                    //qualify to next level
                    playerInfo.isMany = 1;
                    Debug.Log("Your position is " + slot);

                    slot++;
                }
                else
                {
                    //save score
                    StartCoroutine(gameManager.saveScore());
                    gameManager.SetPositionPanel(slot+1);
                    gameManager.ChangeGameState(GameStartManager.GameState.End);
                    //not qualify
                    playerInfo.isMany = 3;
                    slot++;
                }
            }
        }
    }
}
