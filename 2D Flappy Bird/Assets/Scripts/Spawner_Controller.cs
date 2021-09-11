using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    [SerializeField] private Game_Manager game_Manager;
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _duration;
    [SerializeField] private float _minY, _maxY;

    void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(game_Manager._isDead == false) {
            yield return new WaitForSeconds(_duration);

            GameObject _newPipe = Instantiate(_pipePrefab);
            _newPipe.transform.position =  new Vector2(
                transform.position.x,
                Random.Range(_minY, _maxY)
            );

            _newPipe.transform.SetParent(transform);
        }
    }
}
