using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace ConaLuk.Honey
{

    public class EnemyScript : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private SceneLoader scene;
        private float movementSpeed = 1f;
        public SpawnManager spawnManager;
        [SerializeField] private GameObject gameManager;
        [SerializeField] private GameObject honeyGoal;
        [SerializeField] private GameObject beetleEnemy;
        private Transform _target;

        void Start()
        {
            _target = honeyGoal.transform;
        }


        private void Update()
        {

            if (Timer.elapsedTime >= 40)
            {
                movementSpeed = 3.2f;
            }
            if (Timer.elapsedTime >= 25)
            {
                movementSpeed = 3f;
            }
            else if (Timer.elapsedTime >= 20)
            {
                movementSpeed = 2.5f;
            }
            else if (Timer.elapsedTime >= 15)
            {
                movementSpeed = 2f;
            }
            else if (Timer.elapsedTime >= 10)
            {
                movementSpeed = 1.5f;
            }

            MoveObject();
        }

        private void MoveObject()
        {
            // Your movement logic using the movement speed
            transform.position = Vector3.MoveTowards(transform.position, _target.position, movementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Honey")
            {
                // SceneManager.LoadScene("Game Over");
                Debug.Log("Game Over");
                timer.StopTimer();

                scene.LoadScene();
            }

            if (collision.gameObject.tag == "Bee")
            {
                Destroy(beetleEnemy);
                FindObjectOfType<SoundManager>().Play("SOUND TO PLAY"); 
                spawnManager.SpawnBeetle();
 
            }
        }



    }
}
