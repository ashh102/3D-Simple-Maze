// Author: Ashley Maynez
// Date: 10/9/19
// Class: CS 3410 - Fall 2019
// HW3


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    public float timeLeft = 60.0f;
    public Text startText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = "Time left: " + (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            winText.text = "GAMEOVER";
            startText.text = "Time left: 0";
            countText.text = "GAMEOVER";
            Application.Quit();
            
        }
        if (count >= 12 && timeLeft > 0)
        {
            startText.text = "Time left: 0";
            winText.text = "You win!";
            Application.Quit();

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
            if (count >= 12)
            {
                winText.text = "You win!";
            }
        }
    }
}
