using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowValueScript : MonoBehaviour
{
    TextMeshProUGUI percentageText;

    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<TextMeshProUGUI>();
    }

    public void textUpdate (float value)
    {
        //convert the value to a percentage and round it to the nearest integer
        value = value / 2.5f;
        percentageText.text = Mathf.RoundToInt(value) + "%";
    }


}
