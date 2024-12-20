using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 5f;      // Movement speed
    [SerializeField] private float mouseSensitivity = 2f; // Mouse sensitivity for rotation
    [SerializeField] private string victoryTag;       // Win condition  

    void Start()
    {
        // Lock cursor to the game window and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)     // Check for win condition
    {
        if (other.CompareTag(victoryTag))
            Debug.Log("You win!");
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal"); //  Left/Right
        float moveZ = Input.GetAxis("Vertical");   //  Forward/Backward

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Mouse Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Rotate the player
        transform.Rotate(Vector3.up * mouseX);
    }
}
        


