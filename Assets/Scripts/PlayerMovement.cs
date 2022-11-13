using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;


    [SerializeField] private float _sensivity, _limit, _speed;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Update()
    {
        if (InputSystem.instance.GameStart)
        {
            MoveForward();
        }
    }


    void MoveForward()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void MoveHorizontal(Vector2 delta)
    {
        Vector3 tPos = transform.position;
        tPos.x = Mathf.Clamp(tPos.x + delta.x * _sensivity, -_limit, _limit);

        transform.position = tPos;
    }
}
