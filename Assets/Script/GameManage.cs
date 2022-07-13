using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [Header("Game Variable")]
    [SerializeField] bool isStarting = false;
    [SerializeField] bool isFinished = false;

    //[Header("Audio")]
    //[SerializeField] 

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

                //During the treasure hunt game

                //HideStartCanvas();
                //StartTimer();
                //Start the timer
                //Open all the panel
                //Set up the trap

                //Quiz session

                break;

            case GameState.End:

                //After finishing the game
                //EndTimer();
                //StartCoroutine(SaveScore());
                //DisplayEndCanvas();

                //Stop the timer

                break;
        }
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
        CheckGameState();
    }

    #region WaitGame

    public void StartGame()
    {


        ChangeGameState(GameState.Start);
    }

    #endregion

    #region StartGame



    #endregion

    #region EndGame



    #endregion
}
