using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Controller : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
