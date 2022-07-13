using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class CollectMysteryBox : MonoBehaviour
{
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    int randomScore;
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        playerProperties["scores"] = 0;
        randomScore = Random.Range(5, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            score.text = "+ " + randomScore.ToString();
            Debug.Log(score.text);
            playerProperties["scores"] = (int)playerProperties["scores"] + randomScore;
            Debug.Log((int)playerProperties["scores"]);
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);
            Destroy(gameObject);
        }
    }
}
