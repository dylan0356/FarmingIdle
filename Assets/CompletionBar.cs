using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CompletionBar : MonoBehaviour
{
    public Slider completionBar;

    public float maxCompletion = 250;
    public float currentCompletion;

    public static CompletionBar instance;



    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentCompletion = 0f;
        completionBar.maxValue = maxCompletion;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //change the completion bar value based on the absolute value of player Y position
        currentCompletion = Math.Abs(GameObject.FindGameObjectWithTag("Player").transform.position.y);
        completionBar.value = currentCompletion;
    }
}
