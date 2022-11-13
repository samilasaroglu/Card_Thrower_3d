using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private float rotateSpeed;

    void Start()
    {
        rotateSpeed = 250;
    }

    void Update()
    {
        CardRotation();
    }


    void CardRotation()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
