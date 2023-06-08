using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ConaLuk.Honey
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 3f;
        public SoundManager soundManager;
        //time.deltatime & speed variable
        [SerializeField] private GameObject gameManager;
        [SerializeField] private GameObject beeCharacter;
        [SerializeField] private KeyCode rotateClockwise;
        [SerializeField] private KeyCode rotateAntiClockwise;

        private void Start()
        {
            rotationSpeed = 250f;
            soundManager.Play("Buzz");
            soundManager.Play("Theme");
        }

        void Update()
        {

            if (Input.GetKey(rotateAntiClockwise))
            {

                Debug.Log("Pressed A");
                gameManager.transform.Rotate(0, 0, 1 * Time.deltaTime * rotationSpeed);
                beeCharacter.transform.Rotate(0, 0, 1);
            }
            else if (Input.GetKeyUp(rotateAntiClockwise))
            {
                Debug.Log("Released A");
                return;

            }

            if(Input.GetKey(rotateClockwise))
            {
                Debug.Log("Pressed D");
                gameManager.transform.Rotate(0, 0, -1 * Time.deltaTime * rotationSpeed);
                beeCharacter.transform.Rotate(0, 0, -1);

            }
            else if (Input.GetKeyUp(rotateClockwise))
            {
                Debug.Log("Released D");

                return;
            }
        }
    }
}