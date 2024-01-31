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
    ParticleSystem ps;

    private void Start()
    {
        this.gameObject.SetActive(false);
        ps = GetComponent<ParticleSystem>();
        GetComponent<SpriteRenderer>().flipX = flip;
        ps.Stop();
    }

    private void FixedUpdate()
    {
        if (!stop)
        {
            transform.Rotate(0, 0, Rspeed * Time.deltaTime);
            transform.Translate(Vector3.forward * Fspeed * Time.deltaTime);
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
        ps.Simulate(1);
        ps.Play();
        stop = true;
    }
}
