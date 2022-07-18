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
    GameObject gmanager;
    GameStartManager gameManager;
    //TMP_Text playerScore;
    //[SerializeField] int playeractualscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        //playerProperties["scores"] = 0;
        randomScore = Random.Range(5, 50);
        gmanager = GameObject.Find("GameManager");
        gameManager = gmanager.GetComponent<GameStartManager>();
        //playerScore = gameManager.scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject); //this will work after 3 seconds.

            /*int currentScore;
            if (PhotonNetwork.LocalPlayer.CustomProperties["scores"] == null)
            {
                 currentScore = 0;
            }
            else
            {
                currentScore = (int)PhotonNetwork.LocalPlayer.CustomProperties["scores"];
            }
             
            score.text = "+ " + randomScore.ToString();
            Debug.Log(score.text);
            playerProperties["scores"] = currentScore + randomScore;
            Debug.Log((int)playerProperties["scores"]);
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);

            gameManager.AddScoreGame(randomScore);

            StartCoroutine(Destroy());*/
        }
    }

    IEnumerator Destroy()
    {
        //play your sound
        yield return new WaitForSeconds(.3f); //waits 3 seconds
        Destroy(gameObject); //this will work after 3 seconds.
    }
}
