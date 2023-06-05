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

        //public void SpawnBeetle()
        //{

        //    GameObject NewBeetle = Instantiate(beetleEnemy);
        //    Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //    float xPos = Random.Range(screenBounds.x + 1, screenBounds.x + 2);
        //    float yPos = Random.Range(screenBounds.y + 1, screenBounds.y + 2);
        //    NewBeetle.transform.position = new Vector2(xPos, yPos);
        //}

        //public void RandomSpawnPosition()
        //{


        //    beetleSpawnPosition = Random.insideUnitCircle * Random.Range(11, 12);
        //}


    }
}