using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int PinCount = 0;
    public Text text;
    public Text timeText;

    public static float livesRemaining = 1;
    public static float timeRemaining = 60f;

    private void Start()
    {
        //PinCount = 0;
    }

    private void Update()
    {
        text.text = PinCount.ToString();
        timeText.text = "Time: " + timeRemaining.ToString("0.00");
        if(timeRemaining <= 0f)
        {
            timeText.text = "Time: 0.00";
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
