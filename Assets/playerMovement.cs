using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // public Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private float movement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = GetDragFromAcceleration(Physics.gravity.magnitude, 10);
    }

    void Update() {
        movement = Input.GetAxisRaw("Horizontal");
        // animator.SetFloat("speed", (Mathf.Abs(movement.x)+Mathf.Abs(movement.y)));
    }

    void FixedUpdate() {
        rb.transform.Translate(Vector2.right * movement * Time.deltaTime * moveSpeed);
    }

    public static float GetDrag(float aVelocityChange, float aFinalVelocity) {
        return aVelocityChange / ((aFinalVelocity + aVelocityChange) * Time.fixedDeltaTime);
    }

    public static float GetDragFromAcceleration(float aAcceleration, float aFinalVelocity) {
        return GetDrag(aAcceleration * Time.fixedDeltaTime, aFinalVelocity);
    }
}
