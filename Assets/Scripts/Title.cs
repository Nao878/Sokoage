using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // UI�{�^������Ăяo�����\�b�h
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }
}
