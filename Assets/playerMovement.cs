using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // public Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private float movement;

    public float lastPlayerYPos = 0f;
    [SerializeField] float defaultDrag;
    [SerializeField] float slowedDrag;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        //set default drag to the drag calculation from the default gravity and mass of the player
        defaultDrag = GetDragFromAcceleration(Physics.gravity.magnitude, 10);

        //set the drag to defaultDrag
        rb.drag = defaultDrag;

        //set the slowedDrag to defaultDrag + 2
        slowedDrag = defaultDrag + 2;
        Debug.Log("defaultDrag: " + defaultDrag + " slowedDrag: " + slowedDrag);
    }

    void Update() {
        movement = Input.GetAxisRaw("Horizontal");
        // animator.SetFloat("speed", (Mathf.Abs(movement.x)+Mathf.Abs(movement.y)));

        //add drag to the player when space is pressed
        if(Input.GetKeyDown(KeyCode.Space)) {
            //check if the player has enough stamina to use the ability
            if(StaminaBar.instance.currentStamina > 0) {
                //use stamina every 0.1 seconds while space is held down
                InvokeRepeating("UseStamina", 0, 0.1f);
                rb.drag = slowedDrag;
            }
            
        } else if(Input.GetKeyUp(KeyCode.Space)){
            rb.drag = defaultDrag;
        }

        //stop using stamina when space is released
        if(Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("UseStamina");
        }

        //set the drag back to defaultDrag when stamina is empty
        if(StaminaBar.instance.currentStamina <= 0) {
            rb.drag = defaultDrag;
        }

        //set the lastPlayerYPos to the current player y position
        lastPlayerYPos = transform.position.y;
    }


    

    void UseStamina() {
        //use 1 stamina every second while space is held down
        StaminaBar.instance.UseStamina(2);
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
