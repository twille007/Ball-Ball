using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_UI : MonoBehaviour {

    private static Menu_UI _instance;

    public Canvas _menu_panel;

    public Button _exit_button;

    public Button _reload_button;


    public static Menu_UI Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
    }

    public void Activate_menu() {
        _menu_panel.transform.gameObject.SetActive(true);
    }

    public void Deactivate_menu() {
        _menu_panel.transform.gameObject.SetActive(false);
    }
}
