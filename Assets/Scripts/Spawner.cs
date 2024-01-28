using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Road rd;
    public GameObject obst;
    public int ID;

    public int[] pos;
    public GameObject[] obsts;
    Transform trs;
    bool spawn = true;
    float timer;

    private void Start()
    {
        trs = this.gameObject.transform;        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rd.SwitchPlaces(ID);
        }
    }*/

    private void FixedUpdate()
    {
        if (spawn && timer <= 0)
        {
            //trs.position = new Vector3(transform.position.x, transform.position.y, Random.Range(-7, 7));
            Vector3 aux = new Vector3(transform.position.x, transform.position.y, Random.Range(pos[0], pos[1]));
            Instantiate(obsts[Random.Range(0, obsts.Length - 1)], aux, transform.rotation, this.gameObject.transform);
            spawn = false;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Restart()
    {
        timer = 3;
        spawn = true;
    }
}
