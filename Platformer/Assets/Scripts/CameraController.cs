using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float widthPlayField = 7f;

    public GameObject player;
    private float xPosCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        xPosCamera = Mathf.Clamp(player.transform.position.x, -widthPlayField, widthPlayField);

        transform.position = new Vector2(xPosCamera, 0f);
    }
}