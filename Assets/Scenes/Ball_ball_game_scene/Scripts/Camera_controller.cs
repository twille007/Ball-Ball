using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    private static Camera_controller _instance;

    public Transform _ball_transform;

    private Vector3 _camera_offset;

    private bool _initialized = false;

    public static Camera_controller Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
    }

    void Start() {
        Init_camera();
    }

    // Update is called once per frame
    void Update() {
        if(_ball_transform != null) {
            Vector3 new_position = _ball_transform.position + _camera_offset;
            transform.position = new_position;
        }
    }

    public void Init_camera() {
        if(!_initialized) {
            _ball_transform = Ball_manager.Get_instance().Get_ball_gameobject().transform.GetChild(0);
            _camera_offset = transform.position - _ball_transform.position;
            _initialized = true;
        }
    }
}