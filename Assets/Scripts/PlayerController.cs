using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController character_controller;

    public int health = 5;

    private Vector3 move_Direction;

    private int score = 0;

    public float speed = 5f;
    public float gravity = 20f;

    private float vertical_Velocity;

    void Start() {
        character_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        MoveThePlayer();
    }

    void MoveThePlayer() {
        move_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        character_controller.Move(move_Direction);
    } // move player

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Pickup")
        {
            score += 1;
            Debug.Log("Score: " + score);
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    void Update() {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
