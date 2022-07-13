using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameStartManager : MonoBehaviour
{
    public GameObject mysteryBoxPrefab;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        spawnMysteryBoxes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMysteryBoxes()
    {
        for(int i =0; i<3; i++)
        {
            Debug.Log(i);
            int randomNumber = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomNumber];
            //GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
            PhotonNetwork.Instantiate(mysteryBoxPrefab.name, spawnPoint.position, Quaternion.identity);
        }
       
    }
}
