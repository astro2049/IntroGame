using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;

    private void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

    private void FixedUpdate()
    {
        var movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You Win";
        }
    }

    private void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }
}