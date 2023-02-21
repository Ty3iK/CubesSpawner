using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _cube;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var cube = Instantiate(_cube);
            cube.transform.position = new Vector3(Random.Range(-15, 15), 13, Random.Range(-5, 20));
        }
    }
}
