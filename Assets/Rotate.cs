using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TreeEditor;
using UnityEditor.SearchService;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class Rotate : MonoBehaviour
{
    float speed = 189.243f;
    //float speed = 84.8f;
    bool spin = false;
    public GameObject result;
    public Text txtResult;
    int degreeRandom;
    int round = 0;
    bool check = false;
    public void Awake()
    {
    }
    public void Start()
    {
        degreeRandom = Random.Range(0, 359);
        Debug.Log(degreeRandom);
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Spin")
                {
                    spin = true;
                }
            }
        }
        if (spin == true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            float degree = (transform.eulerAngles.y);
            if (degree >= degreeRandom && degree <= degreeRandom + 5)
            //if (degree > degreeRandom)
            {
                round = round + 1;
            }
            if (round > 2)
            {
                speed -= 1.0f;
            }
            if (speed <= 0)
            {
                speed = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (30 * i < degree && degree < 30 + 30*i)
                    {
                        txtResult.text = value()[i];
                        result.SetActive(true);
                    }
                }
            }
        }
    }
    void Update()
    {

    }
    public void spinAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    string[] value()
    {
        string[] gift = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        return gift;
    }
}
