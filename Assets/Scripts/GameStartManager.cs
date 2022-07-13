using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameStartManager : MonoBehaviour
{

    public static GameStartManager Instance;

    [Header("Game Variable")]
    [SerializeField] bool isStarting = false;
    [SerializeField] bool isFinished = false;
    public GameObject mysteryBoxPrefab;
    public Transform[] spawnPoints;
    public int playerCount = 0;

    public enum GameState
    {
        Start,
        End
    }

    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        //Simpleton
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;

        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        ChangeGameState(GameState.Start);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckGameState()
    {
        switch (gameState)
        {

            case GameState.Start:

                spawnMysteryBoxes();
                

                break;

            case GameState.End:


                break;
        }
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
        CheckGameState();
    }

    #region StartGame
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


    #endregion

    #region EndGame


    #endregion
}
