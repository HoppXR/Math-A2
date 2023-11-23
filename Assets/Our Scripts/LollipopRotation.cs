using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopRotation : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool isRotating = false;

    private OnClick onClick;

    public GameObject smallLollipop;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        onClick = playerObject.GetComponent<OnClick>();
    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = !isRotating;
            if (onClick != null)
            {
                onClick.SpawnPrefab(smallLollipop);
            }
        }
    }
    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}

