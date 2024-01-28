using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Car[] car;
    public Road[] rd;
    int i = 0;
    public float[] s;
    public Text[] txt;
    public Text[] spd;
    public float[] points;
    

    void Start()
    {
        //car = GameObject.FindObjectOfType<Car>();
        //rd = GameObject.FindObjectOfType<Road>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Text text in txt)
        {
            if (car[i].drive && car[i].speed > 0)
            {
                points[i] += Time.deltaTime;
            }
            txt[i].text = points[i].ToString("F0") + "M";
            i++;
        } i = 0;
        /*if (car.drive && car.speed > 0)
        {
            points += Time.deltaTime;
        }
        txt.text = points.ToString("F0") + "M";*/

        foreach (Text text in spd)
        {
            s[i] = rd[i].speed * -100;
            spd[i].text = s[i].ToString("F0");
            i++;
        } i = 0;
        /*s = rd.speed * -100;
        spd.text = s.ToString("F0");*/
    }
}
