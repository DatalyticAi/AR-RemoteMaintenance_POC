using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class UIMenu : MonoBehaviour
{
    public GameObject popupWindow;
    public ARSession aRSession;

    private void Awake()
    {
        ClosePopupWindow();
    }
    public void ScanImage()
    {
        SceneManager.LoadSceneAsync("image_scan");
    }

    public void CheckMachine()
    {
        SceneManager.LoadSceneAsync("check_machine");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("main_menu");
        aRSession.Reset();
    }
    public void OpenPopupWindow()
    {
        popupWindow.SetActive(true);
    }

    public void ResetButton()
    {
        aRSession.Reset();
    }

    public void ClosePopupWindow()
    {
        popupWindow.SetActive(false);
    }

    

}
