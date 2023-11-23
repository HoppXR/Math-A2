using UnityEngine;

public class CookieMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool isMoving = false;

    private OnClick onClick;

    public GameObject smallCookie;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        onClick = playerObject.GetComponent<OnClick>();
    }

    void Update()
    {
        if (isMoving)
        {
            rb.velocity = new Vector2(1f, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = !isMoving;
            if (onClick != null)
            {
                onClick.SpawnPrefab(smallCookie);
            }
        }
    }

    public void ToggleTranslation()
    {
        isMoving = !isMoving;
    }
}