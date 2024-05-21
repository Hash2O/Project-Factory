using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, _speed * Time.deltaTime);
        
    }
}
