using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // UIボタンから呼び出すメソッド
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }
}
