using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public Camera mainCamera;
    public Player player;

    public Camera GetCamera() {
        return mainCamera;
    }

    public Player GetPlayer() {
        return player;
    }

    public GameObject welcomeCanvas;
    public GameObject welcomeCamera;

    public Text scoreText;
    public Text gameOverText;
    public Text lifeText;

    private int score;
    private bool gameOver;
    private bool notStarted = true;


    void Start() {
        Time.timeScale = 0;
    }

    void startGame() {

        score = 0;
        UpdateScore();
        UpdateLife(100f);
        gameOver = false;
        notStarted = false;
        welcomeCanvas.SetActive(false);
        welcomeCamera.SetActive(false);

        Time.timeScale = 1;

        gameOverText.text = "";
    }

    void Update() {
        if (notStarted) {
            if (Input.GetKeyDown(KeyCode.S)) {
                startGame();
                notStarted = false;
            }
        }

        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
                gameOverText.text = "";
            }
        }

    }

    public void AddScore (int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over! \nPress R to restart";
        gameOver = true;
        Time.timeScale = 0;
    }


    public void GameWin() {
        gameOverText.text = "Congratulations! You've rebuilt the space folder!\nYou can go back to earth!\nPress R to retart" +
        "\n(The game takes sometime to load, be patient!)";
        gameOver = true;
        Time.timeScale = 0;
    }

    public void UpdateLife(float amt) {
        lifeText.text = "Current Life: " + amt;
    }
}
