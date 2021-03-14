using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool isPinned = false;

    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        speed = PlayerPrefs.GetFloat("pinSpeed", 20f);
    }

    private void Update()
    {
        if(!isPinned) rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Rotator")
        {
            transform.SetParent(collision.transform);
            isPinned = true;
            Score.PinCount++;

            if (Score.PinCount % 3f == 0)
                collision.GetComponent<Rotator>().IncreaseDifficulty();
        }

        else if (collision.tag == "Pin")
        {
            FindObjectOfType<GameManager>().EndGame();
            this.enabled = false;
            collision.GetComponent<Pin>().enabled = false;
        }
    }
}
