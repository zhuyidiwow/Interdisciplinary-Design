using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject[] UICameras;
    public GameObject[] UICanvas;
    /*
        0: Inventory
        1: Craft
     */

    void Update() {

        //toggle Inventory window
        if (Input.GetKeyDown(KeyCode.I)) {
            //disable
            if (UICameras[0].activeSelf == true) {
                UICameras[0].SetActive(false);
                Time.timeScale = 1;
                UICanvas[1].SetActive(true);
            }
            //enable
            else if (UICameras[0].activeSelf == false){
                UICameras[0].SetActive(true);
                Time.timeScale = 0;
                //deactive other canvas
                UICanvas[1].SetActive(false);
                //active this canvas
                UICanvas[0].SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            if (UICameras[1].activeSelf == true) { //disable
                UICameras[1].SetActive(false);
                Time.timeScale = 1;
                UICanvas[0].SetActive(true);
            }
            else if (UICameras[1].activeSelf == false){ //enable
                UICameras[1].SetActive(true);
                Time.timeScale = 0;
                //deactive other canvas
                UICanvas[0].SetActive(false);
                //active this canvas
                UICanvas[1].SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseAll();
        }


        //close all windows

    }

    public void CloseAll() {
            for (int i = 0; i < UICameras.Length; i++) {
                if (UICameras[i].activeSelf == true) {
                    UICameras[i].SetActive(false);
                    Time.timeScale = 1;
                    UICanvas[i].SetActive(true);
                }
            }

    }

}
