using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GummyBearRotation : MonoBehaviour
{
    private Rigidbody2D rb;

    public float rotationSpeed = 200f;

    private bool rotateClockwise = true;

    private OnClick onClick;

    public GameObject smallGummy;

    private void Start()
    {
        RotateObject();
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        onClick = playerObject.GetComponent<OnClick>();
    }

    private void Update()
    {
        RotateObject();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rotateClockwise = !rotateClockwise;
            if (onClick != null)
            {
                onClick.SpawnPrefab(smallGummy);
            }
        }
    }

    private void RotateObject()
    {
        float rotationDirection = rotateClockwise ? 1f : -1f;
        transform.Rotate(Vector3.forward * rotationDirection * rotationSpeed * Time.deltaTime);
    }
    public void ToggleRotation()
    {
        rotateClockwise = !rotateClockwise;
    }
}
