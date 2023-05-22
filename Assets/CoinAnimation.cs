using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [SerializeField] float amplitude = 0.5f;
    [SerializeField] float frequency = 1f;
    Vector3 posOrigin = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOrigin;
        tempPos += transform.up * Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
