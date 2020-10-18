using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private static Map _instance;

    public GameObject _stadium_prefab;

    private GameObject _stadium_gameobject;

    public static Map Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
        Initialize_map();
    }

    private void Initialize_map() {
        _stadium_gameobject = Instantiate(_stadium_prefab);
        _stadium_gameobject.transform.parent = this.transform;
    }

}
