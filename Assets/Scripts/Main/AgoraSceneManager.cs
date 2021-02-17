using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgoraSceneManager : MonoBehaviour
{
    public enum nombres : byte
    {
        Konrad = 3,
        Carla = 1,
        David = 2,
        Sergi = 0
    }
    public nombres chooseScene;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene((int)chooseScene, LoadSceneMode.Single);
    }
}


