using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{

    public static GameStartManager Instance;

    [Header("Game Variable")]
    [SerializeField] bool isStarting = false;
    [SerializeField] bool isFinished = false;
    public GameObject mysteryBoxPrefab;
    public Transform[] mysteryBoxSpawnPoints;
    public GameObject[] powerupsPrefab;
    public Transform[] powerupsSpawnPoints;
    public int playerCount = 0;
    public bool isChangeScene = false;

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
                spawnPowerups();

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
            int randomNumber = Random.Range(0, mysteryBoxSpawnPoints.Length);
            Transform spawnPoint = mysteryBoxSpawnPoints[randomNumber];
            //GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
            PhotonNetwork.Instantiate(mysteryBoxPrefab.name, spawnPoint.position, Quaternion.identity);
        }
       
    }

    public void spawnPowerups()
    {
        for (int i = 0; i<3; i++)
        {
            Debug.Log(i);
            int randomNumber = Random.Range(0, powerupsSpawnPoints.Length);
            int randomPrefab = Random.Range(0, powerupsPrefab.Length);
            Transform spawnPoint = mysteryBoxSpawnPoints[randomNumber];
            //GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
            PhotonNetwork.Instantiate(powerupsPrefab[randomPrefab].name, spawnPoint.position, Quaternion.identity);
        }

    }

    #endregion

    #region EndGame
    public IEnumerator saveScore()
    {
        int totalScore = (int)PhotonNetwork.LocalPlayer.CustomProperties["scores"];
        yield return new WaitForSeconds(1f);
        FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "hunter_escape_point", "add", totalScore.ToString());
        //SceneManager.LoadScene("Leaderboard");
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);

        isChangeScene = true;

        yield return null;
    }

    #endregion
}
