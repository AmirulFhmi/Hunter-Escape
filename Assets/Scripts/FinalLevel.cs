using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinalLevel : MonoBehaviour
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
        if (slot == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            StartCoroutine(gameManager.ChangeScene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            player = other.gameObject.transform.parent.gameObject;
            playerInfo = player.GetComponent<PlayerInfo>();

            isMany = true;

            if (slot <= 3)
            {
                //save score
                StartCoroutine(gameManager.saveScore());
                gameManager.SetPositionPanel(slot + 1);
                gameManager.ChangeGameState(GameStartManager.GameState.End);

                //qualify to next level
                playerInfo.isMany = 3;
                Debug.Log("Your position is " + slot);
                slot++;
            }
            else
            {
                //save score
                StartCoroutine(gameManager.saveScore());
                gameManager.SetPositionPanel(slot + 1);
                gameManager.ChangeGameState(GameStartManager.GameState.End);

                //not qualify
                playerInfo.isMany = 3;
                Debug.Log("Your position is " + slot);
                slot++;
            }
        }
    }
}
