using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private int leftScore;
    private int rightScore;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * 1000, ForceMode.Force);
        SetLeftText();
        SetRightText();
    }

    void SetLeftText()
    {
        leftText.text = leftScore.ToString();
    }

    void SetRightText()
    {
        rightText.text = rightScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Transform t = GetComponent<Transform>();
        t.position = new Vector3(0f, 0.5f, 0f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        if(leftScore < 11 && rightScore < 11){
            if(collision.gameObject.name == "Left Goal"){
                rightScore += 1;
                rb.AddForce(Vector3.left * 1000, ForceMode.Force);
                Debug.Log($"Right Scored! {leftScore}:{rightScore}");
                SetRightText();
            } else if(collision.gameObject.name == "Right Goal"){
                leftScore += 1;
                rb.AddForce(Vector3.right * 1000, ForceMode.Force);
                Debug.Log($"Left Scored! {leftScore}:{rightScore}");
                SetLeftText();
            }
            Debug.Log($"Left-to-Right = {leftScore}:{rightScore}");
        } else {
            if(leftScore == 11){
                Debug.Log("Game Over, Left Paddle Wins");
            } else if(rightScore == 11){
                Debug.Log("Game Over, Right Paddle Wins");
            }
        }
    }
}
