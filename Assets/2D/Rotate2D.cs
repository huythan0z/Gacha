using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Rotate2D : MonoBehaviour
{
    //float speed = 189.243f;
    float speed = 84.8f;
    bool rotate = false;
    [SerializeField] Button btnSpin;
    public Text txtResult;
    int degreeRandom;
    int round = 0;
    void Start()
    {
        degreeRandom = Random.Range(0, 359);
        Debug.Log(degreeRandom);
        btnSpin.onClick.AddListener(spin);
    }
    public void spin()
    {
        rotate = true;
    }
    void Update()
    {

    }
    public void FixedUpdate()
    {
        int degree = Convert.ToInt32(transform.eulerAngles.z);
        if (rotate == true)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            if (degree >= degreeRandom && degree <= degreeRandom + 1)
            {
                round = round + 1;
            }
            if (round > 2)
            {
                speed -= 0.2f; 
            }
            if (speed <= 0)
            {
                speed = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (30 * i <= degree && degree < 30 + 30 * i)
                    {
                        txtResult.text = value()[i];
                    }
                }
                btnSpin.onClick.AddListener(spinAgain2D);
            }
        }
    }
    public void spinAgain2D()
    {
        SceneManager.LoadScene("2D");
    }
    string[] value()
    {
        string[] gift = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        return gift;
    }
}
