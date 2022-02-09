using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    [Header("Location and Scale")]
    public Vector3 cubeLocation = new Vector3(3, 4, 1);
    public float cubeScale = 2;
    [Header("Rotation Angle and Speed")]
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = false;
    public float speedX = 50.0f;
    public float speedY = 50.0f;
    public float speedZ = 50.0f;

    [Header("Material color and opacity")]
    public Color color = new Color(0.5f, 1.0f, 0.3f);

    void Initialize()
    {
        transform.position = cubeLocation;
        transform.localScale = Vector3.one * cubeScale;

        Material material = Renderer.sharedMaterial;

        material.color = color;
    }

    void Start()
    {
        Initialize();
    }
    
    void Update()
    {
        transform.Rotate(
            Convert.ToInt32(rotateX) * speedX * Time.deltaTime,
            Convert.ToInt32(rotateY) * speedY * Time.deltaTime,
            Convert.ToInt32(rotateZ) * speedZ * Time.deltaTime);
    }

    void OnValidate()
    {
        Initialize();
    }
}
