using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    public GameObject beetleEnemy;
    private Vector3 beetleSpawnPosition;

    private void Start()
    {
        Invoke("SpawnBeetle", 3);

    }

    public void SpawnBeetle()
    {

        RandomSpawnPosition();
        GameObject NewBeetle = Instantiate(beetleEnemy);
        NewBeetle.transform.position = beetleSpawnPosition;

    }

    public void RandomSpawnPosition()
    {
        beetleSpawnPosition = Random.onUnitSphere * Random.Range(10, 10);
    }


}
