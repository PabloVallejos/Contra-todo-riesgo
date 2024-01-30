using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public Driver dr;
    public AudioClip[] clips;
    public AudioSource au2;
    public Button bot;
    public float speed;
    public bool player;
    Animator anima;
    public Road rd;
    ParticleSystem ps;
    AudioSource au;
    float timer;
    public bool drive = true;

    private void Start()
    {
        //rd = GameObject.FindObjectOfType<Road>();
        anima = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        au = GetComponent<AudioSource>();
        au.clip = clips[0];
        ps.Stop();
        bot.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        //transform.Translate(new Vector3(0,0,/*Input.GetAxis("Horizontal") */ speed * Time.deltaTime));

        if (Input.GetKey(KeyCode.D)/*Input.GetAxis("Horizontal") > 0*/ && transform.position.z < 10 && rd.speed != 0 && drive && !player)
        {
            transform.Translate(new Vector3(/*Input.GetAxis("Horizontal") */ -speed * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.A)/*Input.GetAxis("Horizontal") < 0*/ && transform.position.z > -10 && rd.speed != 0 && drive && !player)
        {
            transform.Translate(new Vector3(/*Input.GetAxis("Horizontal") */ speed * Time.deltaTime,0,0));
        }


        if (Input.GetKey(KeyCode.RightArrow) && transform.position.z < 138 && rd.speed != 0 && drive && player)
        {
            transform.Translate(new Vector3(/*Input.GetAxis("Horizontal") */ -speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.z > 128 && rd.speed != 0 && drive && player)
        {
            transform.Translate(new Vector3(/*Input.GetAxis("Horizontal") */ speed * Time.deltaTime, 0, 0));
        }


        if (speed > 0)
        {
            anima.SetBool("Moving", true);
        }   else { anima.SetBool("Moving", false); }
        //else { speed = 0; }
        speed = rd.speed * -3;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            au.Play();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            au.Stop();
        }

        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }
        if (drive == false && timer <= 0)
        {
            bot.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            anima.SetBool("Crash", true);
            drive = false;
            rd.drive = false;
            if (!ps.isPlaying)
            {
                ps.Play();
            }
            gameObject.transform.SetParent(rd.transform);
            GetComponent<Rigidbody>().isKinematic = true;
            au.Stop();
            au.clip = clips[1];
            au.loop = false;
            au.Play();
            au2.Stop();
            au2.loop = false;
            au2.clip = clips[Random.Range(2, 10)];
            au2.Play();
            GameOver();
            //Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spawner")
        {
            //rd.SwitchPlaces(other.GetComponent<Spawner>().ID, other.transform.position);
            other.GetComponent<Spawner>().Restart();
        }
    }

    void GameOver()
    {
        timer = 4;
        dr.gameObject.SetActive(true);
    }
}
