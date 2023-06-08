using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class TutorialSprites : MonoBehaviour
{
    public Sprite Sprite;
    public Sprite spriteA;
    public Sprite spriteD;

    public Image myImageComponent;

    void Start() 
    {
        myImageComponent = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
           myImageComponent.sprite = Sprite;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            myImageComponent.sprite = Sprite;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            myImageComponent.sprite = spriteA;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            myImageComponent.sprite = spriteD;
        }
    }

    //[SerializeField] private Image allKeys;
    //[SerializeField] private Image _dKey;
    //[SerializeField] private Image _aKey;

    //private void Start()
    //{
    //    _aKey.SetActive(false);


    //}

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.A))
    //    {

    //    }
    //}



}
