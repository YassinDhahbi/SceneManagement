using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotator : MonoBehaviour
{
    [SerializeField]
    private float windSpeed;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * windSpeed);
    }
}