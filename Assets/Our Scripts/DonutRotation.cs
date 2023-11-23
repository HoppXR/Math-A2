using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutRotation : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool isRotating = false;

    [SerializeField] private float RotationSpeed = -200f;

    public GameObject smallDonut;

    private OnClick onClick;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        onClick = playerObject.GetComponent<OnClick>();
    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRotating = !isRotating;
            if (onClick != null)
            {
                onClick.SpawnPrefab(smallDonut);
            }
        }
    }
    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}
