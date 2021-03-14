using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public Text ResultsText;

    public void Start()
    {
        string playerName = PlayerPrefs.GetString("playerName", "Player");
        ResultsText.text = playerName + ": " + PlayerPrefs.GetInt("playerLives", 1) + " Lives - " + Score.PinCount.ToString() + " Pins.";
    }

    public void Retry()
    {
        Score.PinCount = 0;
        Score.livesRemaining = PlayerPrefs.GetInt("playerLives", 1);
        Score.timeRemaining = PlayerPrefs.GetFloat("playTime", 60f);
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
