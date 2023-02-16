using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    [SerializeField] private Material[] skyMat;

    void Start()
    {
        int random = Random.Range(0,skyMat.Length);
        RenderSettings.skybox = skyMat[random];
    }
}
