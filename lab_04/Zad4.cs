using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad4 : MonoBehaviour
{
    // ruch wokół osi Y będzie wykonywany na obiekcie gracza, więc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    private float xRotation = 0f;

    void Start()
    {
        // zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotację wokół osi Y
        player.Rotate(Vector3.up * mouseXMove);

        xRotation -= mouseYMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}