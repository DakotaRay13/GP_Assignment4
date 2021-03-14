using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public InputField playerName;

    public Dropdown playerLives;

    public Text rotSpeedText;
    public Slider rotSpeed;

    public Text pinSpeedText;
    public Slider pinSpeed;

    public Text playTimeText;
    public Slider playTime;

    private void Start()
    {
        playerName.text = PlayerPrefs.GetString("playerName", "Player Name");
        playerLives.value = PlayerPrefs.GetInt("playerLives", 1) - 1;
        
        rotSpeed.value = PlayerPrefs.GetFloat("rotSpeed", 100f) / 100f;
        rotSpeedText.text = "Rotation Speed: " + rotSpeed.value.ToString();

        pinSpeed.value = PlayerPrefs.GetFloat("pinSpeed", 20f) / 20f;
        pinSpeedText.text = "Pin Speed: " + pinSpeed.value.ToString();

        playTime.value = PlayerPrefs.GetFloat("playTime", 60f);
        playTimeText.text = "Play Time: " + playTime.value.ToString();
    }

    ////////////////////////////////////
    ///Button Functions

    public void StartGame()
    {
        Score.PinCount = 0;
        Score.livesRemaining = PlayerPrefs.GetInt("playerLives", 1);
        Score.timeRemaining = PlayerPrefs.GetFloat("playTime", 60f);
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    ////////////////////////////////////
    ///Options Functions
    
    public void ChangeName()
    {
        PlayerPrefs.SetString("playerName", playerName.text);
        Debug.Log("Player Name changed to " + PlayerPrefs.GetString("playerName", "Player"));

        PlayerPrefs.Save();
    }

    public void ChangeLives()
    {
        PlayerPrefs.SetInt("playerLives", playerLives.value + 1);
        Debug.Log("Lives changed to " + PlayerPrefs.GetInt("playerLives", 0));

        PlayerPrefs.Save();
    }

    public void ChangeRotSpeed()
    {
        rotSpeedText.text = "Rotation Speed: " + rotSpeed.value.ToString();

        PlayerPrefs.SetFloat("rotSpeed", rotSpeed.value * 100f);
        Debug.Log("Rotation Speed changed to " + PlayerPrefs.GetFloat("rotSpeed", 0f));

        FindObjectOfType<Rotator>().speed = PlayerPrefs.GetFloat("rotSpeed", 0f);

        PlayerPrefs.Save();
    }

    public void ChangePinSpeed()
    {
        pinSpeedText.text = "Pin Speed: " + pinSpeed.value.ToString();

        PlayerPrefs.SetFloat("pinSpeed", pinSpeed.value * 20f);
        Debug.Log("Pin Speed changed to " + PlayerPrefs.GetFloat("pinSpeed", 0f));

        PlayerPrefs.Save();
    }

    public void ChangeGameTime()
    {
        playTimeText.text = "Play Time: " + playTime.value.ToString("0.00");

        PlayerPrefs.SetFloat("playTime", playTime.value);
        Debug.Log("Game Time changed to " + PlayerPrefs.GetFloat("playTime", 0f));

        PlayerPrefs.Save();
    }
}
