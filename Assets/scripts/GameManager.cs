using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamepause = false;
    bool gameOver = false;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas2;
    [SerializeField] spaceship player;
    [SerializeField] int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();


    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }

    void PauseGame()
    {
        gamepause = gamepause ? false : true;

        player.gamePaused = gamepause;

        canvas.SetActive(gamepause);
        Time.timeScale = gamepause ? 0 : 1;

    }

    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if (numEnemies < 1)
        {

            Ganar();
        }
    }
    void Ganar()
    {

        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        Debug.Log("ganaste :D");
        Time.timeScale = gamepause ? 0 : 1;
        canvas2.SetActive(gameOver);

    }
}
