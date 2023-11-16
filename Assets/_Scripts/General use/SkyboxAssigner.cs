using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxAssigner : MonoBehaviour
{
    [SerializeField]
    private Material skyboxMat;

    private void Awake()
    {
        RenderSettings.skybox = skyboxMat;
    }
}