using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_manager : MonoBehaviour {

    private static Ball_manager _instance;

    public GameObject _ball_prefab;

    private GameObject _ball_gameobject;

    public static Ball_manager Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
        Initialize_ball();
    }


    public GameObject Get_ball_gameobject() {
        return _ball_gameobject;
    }

    public Ball Get_ball() {
        return _ball_gameobject.GetComponentInChildren<Ball>();
    }

    private void Initialize_ball() {
        _ball_gameobject = Instantiate(_ball_prefab);
        _ball_gameobject.transform.parent = this.transform;
    }

    public void Reset_ball() {
        Get_ball().Reset_ball();
    }

}
