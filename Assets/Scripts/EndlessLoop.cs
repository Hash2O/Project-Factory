using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLoop : MonoBehaviour
{

    [SerializeField] GameObject[] _items;
    [SerializeField] Transform _spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var item in _items)
        {
            if(item.transform.position.y <= 0.5f)
            {
                item.transform.position = new Vector3(Random.Range(0, 3.0f), _spawnPoint.position.y, _spawnPoint.position.z);
            }
        }
    }
}
