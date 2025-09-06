using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScript : MonoBehaviour
{
    // 0�`100�̒l
    private float value = 0f;
    // �l�̕ϓ����x
    private float speed = 50f;
    // �l���Œ肳�ꂽ��
    private bool isFixed = false;
    // �㏸�������~����
    private bool isIncreasing = true;
    // TextMeshPro�̃e�L�X�g�I�u�W�F�N�g
    public TextMeshProUGUI valueText;
    // �ړ�������Q�[���I�u�W�F�N�g
    public Transform targetObject;
    // �ŉ����ƍŏ㕔��Y���W
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
            // �l���㉺������
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

            // Enter�L�[�Œl���Œ�
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isFixed = true;
                Debug.Log($"�Œ�l: {value:F1}");
                if (value >= 50f)
                {
                    Debug.Log("�΂ꂽ");
                }
                else if (value <= 40f)
                {
                    Debug.Log("�����Ɗ撣���");
                }
                else
                {
                    Debug.Log("�œK");
                }
            }
        }
        // TextMeshPro�ɒl��\��
        if (valueText != null)
        {
            valueText.text = value.ToString("F1");
        }

        // R�L�[�Ń��g���C
        if (Input.GetKeyDown(KeyCode.R))
        {
            isFixed = false;
            value = 0f;
            isIncreasing = true;
        }

        // �Q�[���I�u�W�F�N�g�̏㉺�ړ�
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
