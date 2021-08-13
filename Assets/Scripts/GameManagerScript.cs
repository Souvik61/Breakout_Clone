using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //Editor vars
    public BricksKeeperScript keeperScript;
    public Transform ballSpawnPoint;
    public GameObject paddle;
    public AltBallScript activeBall;
    public BallMoverScript ballMoverScript;
    public LiveSystemScript livesDisplay;
    public GameObject winText;
    public GameObject levelPrefab;
    public GameObject ballPrefab;

    //Internal vars
    private bool ballOnPaddle;
    private uint ballLives;
    private enum GameState { RUNNING, PAUSED } ;
    private GameState currentState;
    private GameObject levelTilemap;

    //Unity messages --start

    private void OnEnable()
    {
        AllEventsScript.OnBallGoOut += EndTrigger_OnBallEnter;
        AllEventsScript.OnAllTilesDestroyed += OnAllBricksDestroyed;
    }

    private void OnDisable()
    {
        AllEventsScript.OnBallGoOut += EndTrigger_OnBallEnter;
        AllEventsScript.OnAllTilesDestroyed -= OnAllBricksDestroyed;

    }

    private void Awake()
    {
        levelTilemap = null;
        ballOnPaddle = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        //ballMoverScript.ballVelocityVec = new Vector2(Random.Range(-1, 1), 1).normalized;
        //ballMoverScript.ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), 1).normalized);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ballOnPaddle) Invoke("LaunchBall", 0.1f);
        }

    }

    //Unity messages --end

    //Game events --start

    void ResetGame()
    {
        ballLives = 3;
        livesDisplay.SetLives(3);
        ResetBall();
        winText.SetActive(false);

        //Destroy previous tilemaps and create new one.
        if (levelTilemap != null)
        {
            DestroyImmediate(levelTilemap);
        }

        var tile = Instantiate(levelPrefab);
        levelTilemap = tile;
        keeperScript.SetGridToKeep(tile.GetComponent<Grid>());

        currentState = GameState.RUNNING;

    }

    void OnGameWin()
    {
        winText.GetComponent<TMPro.TMP_Text>().text = "You Win!";
        winText.SetActive(true);
        currentState = GameState.PAUSED;
    }

    void OnGameOver()
    {
        winText.GetComponent<TMPro.TMP_Text>().text = "You Lose";
        winText.SetActive(true);
        currentState = GameState.PAUSED;

    }

    //Resart Level
    void RestartLevel()
    {
        ResetGame();
       // ballMoverScript.ballVelocityVec = new Vector2(Random.Range(-1, 1), 1).normalized;
      //  ballMoverScript.ballObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), 1).normalized);

        // SceneManager.LoadScene(1);

    }

    //Game events --end

    //Ball 
    void ResetBall()
    {
        //If active ball ==null when level restart
        if (activeBall == null)
        { activeBall = Instantiate(ballPrefab).GetComponent<AltBallScript>(); }

        ballMoverScript.ResetBall();

        ballOnPaddle = true;
    }

    void LaunchBall()
    {
        ballMoverScript.LaunchBall();
        ballOnPaddle = false;
    }

    //External trigger events --start

    private void EndTrigger_OnBallEnter()
    {
        OnBallDied();
    }

    private void OnAllBricksDestroyed()
    {
        OnGameWin();
    }

    //External trigger events --end

    void OnBallDied()
    {
        //Stop the ball
        ballMoverScript.ballVelocityVec = Vector2.zero;

        //If life left respawn ball else Game Over
        if (ballLives > 0 && currentState != GameState.PAUSED)
        {
            ballLives--;
            if (ballLives == 0)
            {
                OnGameOver();
            }
            else
            {
                ResetBall();
                //ballMoverScript.ballVelocityVec = new Vector2(Random.Range(-1.0f, 1.0f), 1.0f).normalized;
            }

            livesDisplay.SetLives(ballLives);
        }

    }
}
