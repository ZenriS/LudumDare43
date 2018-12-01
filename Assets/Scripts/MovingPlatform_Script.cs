using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_Script : MonoBehaviour
{

    private Transform _point0;
    private Transform _point1;
    public float MoveSpeed;
    public bool Active;

    void Start()
    {
        _point0 = transform.parent.GetChild(1).transform;
        _point1 = transform.parent.GetChild(2).transform;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Active)
        {
            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _point1.position, step);
        }
        else
        {
            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _point0.position, step);
        }
    }
}
