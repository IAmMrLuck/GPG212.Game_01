using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConaLuk.Honey
{


    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject beetleEnemy;
        [SerializeField] private GameObject waspEnemy;
        [SerializeField] private Transform[] spawnPoints;
        

        private void Start()
        {
            Invoke("SpawnBeetle", 3);

            Invoke("StartSpawnCountdown", 5f);

        }

        public void SpawnBeetle()
        {

            GameObject newBeetle = Instantiate(beetleEnemy);

            Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            float xPos, yPos;

            // Randomly determine which side of the screen to spawn the beetle
            int side = Random.Range(0, 4);

            // Randomly select position along the chosen side
            if (side == 0) // Top side
            {
                xPos = Random.Range(-screenBounds.x, screenBounds.x);
                yPos = screenBounds.y;
            }
            else if (side == 1) // Right side
            {
                xPos = screenBounds.x;
                yPos = Random.Range(-screenBounds.y, screenBounds.y);
            }
            else if (side == 2) // Bottom side
            {
                xPos = Random.Range(-screenBounds.x, screenBounds.x);
                yPos = -screenBounds.y;
            }
            else // Left side
            {
                xPos = -screenBounds.x;
                yPos = Random.Range(-screenBounds.y, screenBounds.y);
            }

            // Randomly offset the position along the chosen side
            float offset = Random.Range(1f, 2f);
            Vector3 spawnPosition = new Vector3(xPos, yPos, 0) * offset;
            newBeetle.transform.position = spawnPosition;

        }

        private void StartSpawnCountdown()
        {
            InvokeRepeating("SpawnWasp", 0f, 15f);
        }

        public void SpawnWasp()
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(waspEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }



    }
}