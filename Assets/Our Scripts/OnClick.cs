using UnityEngine;
using System.Collections.Generic;

public class OnClick : MonoBehaviour
{
    public float raycastDistance = 10f;

    public float prefabSpace = 0.1f;

    public GameObject smallCookie;
    public GameObject smallDonut;
    public GameObject smallMushroom;
    public GameObject smallGummy;
    public GameObject smallLolipop;
    public GameObject smallLicorice;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, raycastDistance);

            if (hit.collider != null)
            {
                GameObject prefabToSpawn = null;

                if (hit.collider.CompareTag("Cookie"))
                {
                    prefabToSpawn = smallCookie;
                    CookieMovement cookieScript = hit.collider.GetComponent<CookieMovement>();
                    if (cookieScript != null)
                    {
                        cookieScript.ToggleTranslation();
                    }
                }
                else if (hit.collider.CompareTag("Donut"))
                {
                    prefabToSpawn = smallDonut;
                    DonutRotation donutRotationScript = hit.collider.GetComponent<DonutRotation>();
                    if (donutRotationScript != null)
                    {
                        donutRotationScript.ToggleRotation();
                    }
                }
                else if (hit.collider.CompareTag("Mushroom"))
                {
                    prefabToSpawn = smallMushroom;
                    MushroomGrow mushroomScript = hit.collider.GetComponent<MushroomGrow>();
                    if (mushroomScript != null)
                    {
                        mushroomScript.ScaleMushroom();
                    }
                }
                else if (hit.collider.CompareTag("Gummy"))
                {
                    prefabToSpawn = smallGummy;
                    GummyBearRotation gummieScript = hit.collider.GetComponent<GummyBearRotation>();
                    if (gummieScript != null)
                    {
                        gummieScript.ToggleRotation();
                    }
                }
                else if (hit.collider.CompareTag("Lolipop"))
                {
                    prefabToSpawn = smallLolipop;
                    LollipopRotation loliScript = hit.collider.GetComponent<LollipopRotation>();
                    if (loliScript != null)
                    {
                        loliScript.ToggleRotation();
                    }
                }
                else if (hit.collider.CompareTag("Licorice"))
                {
                    prefabToSpawn = smallLicorice;
                    LicoriceFire licoreecScript = hit.collider.GetComponent<LicoriceFire>();
                    if (licoreecScript != null)
                    {
                        licoreecScript.ToggleShoot();
                    }
                }

                if (prefabToSpawn != null)
                {
                    SpawnPrefab(prefabToSpawn);
                }
            }
        }

        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] != null)
            {
                float xOffset = i * prefabSpace;
                spawnedObjects[i].transform.position = transform.position - transform.right * xOffset;
            }
        }
    }

    public void SpawnPrefab(GameObject prefab)
    {
        GameObject spawnedObject = Instantiate(prefab, transform.position - transform.forward * 2f, Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }
}
