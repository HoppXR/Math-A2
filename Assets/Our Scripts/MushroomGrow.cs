using UnityEngine;

public class MushroomGrow : MonoBehaviour
{
    private Rigidbody2D rb;

    private int touchCount = 0;

    private OnClick onClick;

    public GameObject smallMushroom;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.Find("Player");
        onClick = playerObject.GetComponent<OnClick>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float scalingFactor = 1.2f * Mathf.Pow(1.2f, touchCount);
            transform.localScale *= scalingFactor;
            if (onClick != null)
            {
                onClick.SpawnPrefab(smallMushroom);
            }
            touchCount++;
        }
    }
    public void ScaleMushroom()
    {
        float scalingFactor = 1.2f * Mathf.Pow(1.2f, touchCount);
        transform.localScale *= scalingFactor;
        touchCount++;
    }
}