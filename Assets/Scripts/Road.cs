using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float speed;
    public bool player;
    public bool drive = true;
    public Collider col;
    public GameObject[] obst;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,/*Input.GetAxis("Vertical") */ speed,0));
        if (!player)
        {
            if (Input.GetKey(KeyCode.W)/*Input.GetAxis("Vertical") > 0*/ && speed > -1 && drive)
            {
                speed -= Time.deltaTime/4;
            } 
            else if (speed < 0 && !player)
            {
                speed += Time.deltaTime;
            }
        }

        if (player)
        {
            if (Input.GetKey(KeyCode.UpArrow) && speed > -1 && drive)
            {
                speed -= Time.deltaTime / 4;
            }
            else if (speed < 0 && player)
            {
                speed += Time.deltaTime;
            }
        }
    }

    public void SwitchPlaces(int i, Vector3 vec)
    {
        vec.z = Random.Range(-7, 7);
        obst[i].transform.position = vec; //new Vector3(0,0,Random.Range(-10, 10));
        Debug.Log("Changed");
        //yield return new WaitForSeconds(0.1f);
    }
}
