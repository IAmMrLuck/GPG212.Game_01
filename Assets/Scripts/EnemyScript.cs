using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ConaLuk.Honey
{

    public class EnemyScript : MonoBehaviour
    {
        private float spawnPoint = Random.Range(0,8);

        [SerializeField] private float movementSpeed = 0.1f;

        [SerializeField] private GameObject beeCharacter;
        [SerializeField] private GameObject honeyGoal;
        [SerializeField] private GameObject beetleEnemy;
        private Transform _target;

        void Start()
        {
            _target = honeyGoal.transform;
            Invoke("SpawnBeetle", 3);

        }


        void Update()
        {

            transform.position = Vector3.MoveTowards(transform.position, _target.position, movementSpeed * Time.deltaTime);

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Honey")
            {
                SceneManager.LoadScene("Game Over");
            }

            if (collision.gameObject.tag == "Bee")
            {
                Destroy(beetleEnemy);
                SpawnBeetle();
            }
        }

        public void SpawnBeetle()
        {


            transform.position = Vector3.MoveTowards(transform.position, _target.position, movementSpeed * Time.deltaTime);
            Instantiate(beetleEnemy);

        }

    }
}
