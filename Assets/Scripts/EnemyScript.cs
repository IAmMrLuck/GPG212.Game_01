using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ConaLuk.Honey
{

    public class EnemyScript : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 0.1f;

        [SerializeField] private GameObject beeCharacter;
        [SerializeField] private GameObject honeyGoal;
        [SerializeField] private GameObject beetleEnemy;
        private Transform _target;

        void Start()
        {
            _target = honeyGoal.transform;
                      

        }


        void Update()
        {

            transform.position = Vector3.MoveTowards(transform.position, _target.position, movementSpeed);

        }
    }
}
