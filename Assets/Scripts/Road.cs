using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public float offset = 0.71f;
    public Vector3 lastPosition;

    private int roadCount = 0;

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", .5f, .5f);
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPosition = Vector3.zero;

        float chance = Random.Range(0, 100);
        if (chance < 50)
            spawnPosition = new Vector3(lastPosition.x + offset, lastPosition.y, lastPosition.z + offset);
        else
            spawnPosition = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z + offset);

        GameObject g = Instantiate(roadPrefab, spawnPosition, Quaternion.Euler(0, 45, 0));

        lastPosition = g.transform.position;

        if (++roadCount % 5 == 0)
            g.transform.GetChild(0).gameObject.SetActive(true);
    }

}
