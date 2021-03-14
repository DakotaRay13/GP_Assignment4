using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    public Rotator rotator;
    public Spawner spawner;

    public Animator animator;

    public Text uiText;

    private void Start()
    {
        uiText.text = PlayerPrefs.GetString("playerName", "Player") + ": " + Score.livesRemaining.ToString();
    }

    public void EndGame()
    {
        if (gameHasEnded)
            return;
        
        Debug.Log("END GAME");
        gameHasEnded = true;
        rotator.enabled = false;
        spawner.enabled = false;

        animator.SetTrigger("EndGame");
    }

    public void RestartLevel()
    {
        Score.livesRemaining--;
        if (Score.livesRemaining <= 0 || Score.timeRemaining <= 0f)
        {
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
