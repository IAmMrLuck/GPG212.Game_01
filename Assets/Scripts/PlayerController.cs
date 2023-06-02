using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ConaLuk.Honey
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;

        //time.deltatime & speed variable
        [SerializeField] private GameObject _beeCharacter;
        [SerializeField] private KeyCode rotateClockwise;
        [SerializeField] private KeyCode rotateAntiClockwise;


        void Update()
        {
            if (Input.GetKey(rotateAntiClockwise))
            {
                Debug.Log("Pressed A");
                _beeCharacter.transform.Rotate(0, 0, 1);
            }
            else if (Input.GetKeyUp(rotateAntiClockwise))
            {
                Debug.Log("Released A");
                return;
            }

            if(Input.GetKey(rotateClockwise))
            {
                Debug.Log("Pressed D");
                _beeCharacter.transform.Rotate(0, 0, -1);
            }
            else if (Input.GetKeyUp(rotateClockwise))
            {
                Debug.Log("Released D");

                return;
            }
        }
    }
}