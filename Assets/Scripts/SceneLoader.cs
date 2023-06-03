using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ConaLuk.Honey
{

    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneToLoad;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}