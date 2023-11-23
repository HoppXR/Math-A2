using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicoriceFire : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject projectilePrefab;

    private int contactCount = 0;

    private int shotsFired = 0;

    private bool hasTouched = false;

    public GameObject smallLicorice;

    private OnClick onClick;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        onClick = playerObject.GetComponent<OnClick>();
    }

    private void Update()
    {
        if (hasTouched && Input.GetKeyDown(KeyCode.E) && shotsFired < contactCount + 1)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;

        shotsFired++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasTouched)
            {
                hasTouched = true;
            }
            else
            {
                shotsFired = 0;
                contactCount++;
            }
            if (onClick != null)
            {
                onClick.SpawnPrefab(smallLicorice);
            }
        }
    }

    public void ToggleShoot()
    {
        if (!hasTouched)
        {
            hasTouched = true;
        }
        else
        {
            shotsFired = 0;
            contactCount++;
        }
    }
}
