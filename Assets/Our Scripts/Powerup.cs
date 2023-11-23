using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject powerupPrefab; 
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the powerup!");

            GameObject smallPowerup = Instantiate(powerupPrefab, player.position + Vector3.up * 2f, Quaternion.identity);

            smallPowerup.transform.parent = player;
        }
    }
}
