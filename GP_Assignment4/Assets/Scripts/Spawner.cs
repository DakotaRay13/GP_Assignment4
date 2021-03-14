using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pinPrefab;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            SpawnPin();
        }

        Score.timeRemaining -= Time.deltaTime;
    }

    void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}
