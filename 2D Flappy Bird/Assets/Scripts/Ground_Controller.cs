using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Controller : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _moveSpeed = 0;
    void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime, 0f, 0f);


        if(transform.position.x + 6.7375f <= _cam.position.y) {
            transform.position = new Vector2(
                _cam.position.x + 6.7375f,
                transform.position.y
            );
        }
    }
}
