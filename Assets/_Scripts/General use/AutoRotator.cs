using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotator : MonoBehaviour
{
    [SerializeField]
    private RotationDirector rotateDirector;

    private void Update()
    {
        rotateDirector.Rotate(transform);
        if (Input.GetMouseButtonDown(0))
        {
            rotateDirector.RandomizeDirection();
        }
    }
}

[System.Serializable]
public class RotationDirector
{
    [SerializeField]
    private bool isActive;

    [SerializeField]
    private float rotationValuePerFrame;

    [SerializeField]
    private Axis rotationAxis;

    public void Rotate(Transform target)
    {
        if (isActive)
        {
            var rotationDirection = Vector3.zero;
            switch (rotationAxis)
            {
                case Axis.X:
                    rotationDirection = Vector3.right;
                    break;

                case Axis.Y:
                    rotationDirection = Vector3.up;
                    break;

                case Axis.Z:
                    rotationDirection = Vector3.forward;
                    break;
            }
            target.Rotate(rotationDirection * rotationValuePerFrame * Time.deltaTime);
        }
    }

    public void RandomizeDirection()
    {
        var randomValue = Random.Range(1, 4);
        var newRotationAxis = Axis.X;
        switch (randomValue)
        {
            case 1:
                newRotationAxis = Axis.X;
                break;

            case 2:
                newRotationAxis = Axis.Y;

                break;

            case 3:
                newRotationAxis = Axis.Z;
                break;
        }
        if (rotationAxis == newRotationAxis)
        {
            RandomizeDirection();
        }
        rotationAxis = newRotationAxis;
    }
}

public enum Axis
{
    X = 1, Y = 2, Z = 3
}