using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConaLuk.Honey
{


    public class SpawnManager : MonoBehaviour
    {
        public GameObject beetleEnemy;
        private Vector2 beetleSpawnPosition;

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
            beetleSpawnPosition = Random.insideUnitCircle * Random.Range(12, 12);
        }


    }
}