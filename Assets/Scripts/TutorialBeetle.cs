using ConaLuk.Honey;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBeetle : MonoBehaviour
{
    [SerializeField] private GameObject beetleEnemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bee")
        {
            Destroy(beetleEnemy);

        }
    }


}
