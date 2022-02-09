using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayersController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float mouseSensitivityX = 4f;
    [SerializeField] private float mouseSensitivityY = 4f;

    private PlayerMotor motor;

    private void Start() {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update() {
        // Calculer la vitesse du joueur
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        // On calcule la rotation du joueur
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivityX;

        motor.Rotate(rotation); 

        // On calcule la rotation de la camera
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * mouseSensitivityY;

        motor.RotateCamera(cameraRotation);
    }
}
