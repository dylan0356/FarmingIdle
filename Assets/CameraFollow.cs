using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void FixedUpdate() {

        Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

            //clamp the camera so it doesn't go out of bounds
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

            //smooth the camera movement
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
    }
}
