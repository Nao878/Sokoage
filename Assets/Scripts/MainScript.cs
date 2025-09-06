using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScript : MonoBehaviour
{
    // 0～100の値
    private float value = 0f;
    // 値の変動速度
    private float speed = 50f;
    // 値が固定されたか
    private bool isFixed = false;
    // 上昇中か下降中か
    private bool isIncreasing = true;
    // TextMeshProのテキストオブジェクト
    public TextMeshProUGUI valueText;
    // 移動させるゲームオブジェクト
    public Transform targetObject;
    // 最下部と最上部のY座標
    public float minY = -4f;
    public float maxY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        value = 0f;
        isFixed = false;
        isIncreasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFixed)
        {
            // 値を上下させる
            if (isIncreasing)
            {
                value += speed * Time.deltaTime;
                if (value >= 100f)
                {
                    value = 100f;
                    isIncreasing = false;
                }
            }
            else
            {
                value -= speed * Time.deltaTime;
                if (value <= 0f)
                {
                    value = 0f;
                    isIncreasing = true;
                }
            }

            // Enterキーで値を固定
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isFixed = true;
                Debug.Log($"固定値: {value:F1}");
                if (value >= 50f)
                {
                    Debug.Log("ばれた");
                }
                else if (value <= 40f)
                {
                    Debug.Log("もっと頑張れる");
                }
                else
                {
                    Debug.Log("最適");
                }
            }
        }
        // TextMeshProに値を表示
        if (valueText != null)
        {
            valueText.text = value.ToString("F1");
        }

        // Rキーでリトライ
        if (Input.GetKeyDown(KeyCode.R))
        {
            isFixed = false;
            value = 0f;
            isIncreasing = true;
        }

        // ゲームオブジェクトの上下移動
        if (targetObject != null)
        {
            float t = value / 100f;
            float newY = Mathf.Lerp(minY, maxY, t);
            Vector3 pos = targetObject.position;
            pos.y = newY;
            targetObject.position = pos;
        }
    }
}
