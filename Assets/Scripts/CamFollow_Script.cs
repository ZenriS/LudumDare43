using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow_Script : MonoBehaviour
{
    public Transform Player;
    public float Smoothing;
    Vector3 _vector3Zero = Vector3.zero;
    public float Offset;

    void Start()
    {
        
    }

	void FixedUpdate ()
	{
	    Vector3 offsetPos = new Vector3(Player.position.x + Offset, Player.position.y, Player.position.z);
	    transform.position = Vector3.SmoothDamp(transform.position, offsetPos, ref _vector3Zero, Smoothing * Time.deltaTime);
	}
}
