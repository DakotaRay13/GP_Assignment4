using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;
    public float DifficultyTweak = 50f;

    private void Start()
    {
        speed = PlayerPrefs.GetFloat("rotSpeed", 100f);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }

    public void IncreaseDifficulty()
    {
        speed += DifficultyTweak;
    }
}
