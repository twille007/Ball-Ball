using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public GameObject _goal_left_prefab;
    public GameObject _goal_right_prefab;

    private Vector3 _position_goal_left = new Vector3();
    private Vector3 _position_goal_right = new Vector3();

    void Awake() {
        Instantiate(_goal_left_prefab, _position_goal_left, Quaternion.identity);
        Instantiate(_goal_right_prefab, _position_goal_right, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {

    }

}
