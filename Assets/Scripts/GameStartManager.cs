using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject startLine;
    public int playerCount = 0;
    public bool isChangeScene = false;

    public TMP_Text scoreText;
    public TMP_Text panelPositionText;
    public TMP_Text panelScoreText;
    public TMP_Text countdownText;

    public GameObject scorePanel;
    public GameObject positionPanel;

    [SerializeField] int playeractualscore = 0;

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

        Debug.Log("Player: "+GameObject.FindGameObjectsWithTag("Player").Length);
        Debug.Log("Room: " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (GameObject.FindGameObjectsWithTag("Player").Length == PhotonNetwork.CurrentRoom.PlayerCount)
        {
            StartCoroutine(StartTimer());
        }

        //ChangeGameState(GameState.Start);

    }

   public IEnumerator StartTimer()
   {
        for(int i=1; i<4;  i++)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(2);
        }
        countdownText.text = null;
        startLine.SetActive(false);
        ChangeGameState(GameState.Start);
        yield return null;
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

                SpawnScorePanel();
                spawnMysteryBoxes();
                spawnPowerups();

                break;

            case GameState.End:
                HideScorePanel();
                SpawnPositionPanel();

                break;
        }
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
        CheckGameState();
    }

    #region StartGame

    public void SpawnScorePanel()
    {
        scorePanel.SetActive(true);
    }

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
            Transform spawnPoint = powerupsSpawnPoints[randomNumber];
            //GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
            PhotonNetwork.Instantiate(powerupsPrefab[randomPrefab].name, spawnPoint.position, Quaternion.identity);
        }

    }

    public void AddScoreGame(int s)
    {
        playeractualscore = playeractualscore + s;
        scoreText.text = playeractualscore.ToString();
    }

    #endregion

    #region EndGame

    public void HideScorePanel()
    {
        scorePanel.SetActive(false);
    }

    public void SpawnPositionPanel()
    {
        positionPanel.SetActive(true);
    }

    public IEnumerator saveScore()
    {
        int totalScore = (int)PhotonNetwork.LocalPlayer.CustomProperties["scores"];
        yield return new WaitForSeconds(1f);
        FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "hunter_escape_point", "add", totalScore.ToString());
        //SceneManager.LoadScene("Leaderboard");
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(6f);

        isChangeScene = true;

        yield return null;
    }

    public void SetPositionPanel(int s)
    {
        string t = s.ToString();
        panelPositionText.text = t;
        panelScoreText.text = scoreText.text;

    }

    #endregion
}
