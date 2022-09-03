using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Graph : MonoBehaviour
{
    [SerializeField]
    private Transform pointPrefab;

    [SerializeField, Range(10, 100)] 
    private int resolution = 10;

    private Transform[] points;
    private Vector3 position;
    private bool flag;

    private void Awake()
    {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point =points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }

    }

    public void OnButtonClick()
    {
        flag = true;
    }

    private Action<float> formula;
    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            if (flag)
            {
                
                flag = false;
                int randomNumber1 = Random.Range(0,1);
                if (randomNumber1 == 0)
                {
                    int randomNumber2 = Random.Range(0, 3);
                    int randomNumber3 = Random.Range(0, 3);
                    position.y += Mathf.Pow(Mathf.Sin(randomNumber2 * Mathf.PI * (position.x + time)),randomNumber3);
                }
                else
                {
                    int randomNumber2 = Random.Range(0, 3);
                    int randomNumber3 = Random.Range(0, 3);
                    position.y += Mathf.Pow(Mathf.Cos(randomNumber2 * Mathf.PI * (position.x + time)),randomNumber3);
                }
            }
            //position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            /* position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            position.y += Mathf.Sin(2 * Mathf.PI * (position.x + time));
            position.y += Mathf.Cos(Mathf.PI * (position.x + time));
            position.y = position.y / 3; */
            point.localPosition = position;
            
            Debug.Log(position.y);
        }
    }
    
}
