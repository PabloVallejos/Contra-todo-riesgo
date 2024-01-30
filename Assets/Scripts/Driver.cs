using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public float Rspeed;
    public float Fspeed;
    public bool flip;
    float timer = 2f;
    bool stop = false;

    private void Start()
    {
        this.gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().flipX = flip;
    }

    private void FixedUpdate()
    {
        if (!stop)
        {
            transform.Rotate(0, 0, Rspeed * Time.deltaTime);
            transform.Translate(Vector3.forward * Fspeed * Time.deltaTime);
            GetComponent<ParticleSystem>().Play();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            BlowUp();
        }
    }

    void BlowUp()
    {
        GetComponent<ParticleSystem>().Play();
        stop = true;
    }
}
