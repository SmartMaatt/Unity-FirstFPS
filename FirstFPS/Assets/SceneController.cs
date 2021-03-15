using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;    //Zserializowana zmienna prywatna na prefabrykat wroga
    private GameObject _enemy;    //Zmienna prywatna na obiekt wroga  

    void Update(){
        if (_enemy == null) {
            _enemy = Instantiate(enemyPrefab) as GameObject;    //Spawnowanie z prefabrykatu i rzytowanie z Object na GameObject

            _enemy.transform.position = new Vector3(Random.Range(-15,15), 1, Random.Range(-15, 15));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
