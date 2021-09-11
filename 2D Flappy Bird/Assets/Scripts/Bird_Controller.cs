using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Game_Manager game_Manager;
    [SerializeField] private float _jumpPower;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && game_Manager._isStart == true) {
            rb.velocity = Vector2.up *_jumpPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Score Point")) {
            game_Manager._score++;
        }

        if(other.gameObject.CompareTag("Pipe")) {
            game_Manager.GameOver();
        }  
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            game_Manager.GameOver();
        }
    }
}
