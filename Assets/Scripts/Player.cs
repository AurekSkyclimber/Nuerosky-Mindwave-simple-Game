using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    // Use this for initialization


    AudioSource audioSource;
    SerialPort stream = new SerialPort("COM7", 57600);
    public float leftLimit;
    public float rightLimit;
    public float upLimit;
    public float downLimit;
    char[] commaSplitter = { ',' };

    void Awake()
    {
        stream.Open(); //Open the Serial Stream.
        stream.ReadTimeout = 100; //Give a Timeout to Serial Stream Reading


    }


	
	// Update is called once per frame
	void Update () {

        try
        {
            //Debug.Log("Before read");
            string value = stream.ReadLine(); //Read the information
            Debug.Log(value);
            //Debug.Log("After read");
            string[] values = value.Split(commaSplitter);

            float attention = (float.Parse(values[0]) - 60f) / 20f;
            float meditation = (float.Parse(values[1]) - 60f) / 20f;
            Debug.Log(attention + ", " + meditation);
            transform.Translate(attention, meditation, 0f);
            Vector3 nextPosition = transform.position;
            Debug.Log(nextPosition);
            if (nextPosition.x <= leftLimit)
            {
                nextPosition.x = leftLimit;
            }
            if (nextPosition.x >= rightLimit)
            {
                nextPosition.x = rightLimit;
            }
            if (nextPosition.y >= upLimit)
            {
                nextPosition.y = upLimit;
            }
            if (nextPosition.y <= downLimit)
            {
                nextPosition.y = downLimit;
            }

            transform.position = nextPosition;

            stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.

        }  catch (System.Exception e)
        {
            //Debug.Log("Error: " + e);
        }
    }


    
    void OnCollisionEnter(Collision col)
    {


        audioSource.PlayOneShot(Resources.Load<AudioClip>("Sounds/gunshot"));

        if (col.gameObject.tag=="1")
        {
            int increment = 1;
            GameObject.Find("ScoreKeeper").GetComponent<Scores>().update_score(increment);
            
          
        }
        if (col.gameObject.tag == "2")
        {
            int increment = 2;
            GameObject.Find("ScoreKeeper").GetComponent<Scores>().update_score(increment);
            

        }
        if (col.gameObject.tag == "3")
        {
            int increment = 3;
            GameObject.Find("ScoreKeeper").GetComponent<Scores>().update_score(increment);
            

        }
        if (col.gameObject.tag == "4")
        {
            int increment = 4;
            GameObject.Find("ScoreKeeper").GetComponent<Scores>().update_score(increment);
            

        }
        if (col.gameObject.tag == "5")
        {
            int increment = 5;
            GameObject.Find("ScoreKeeper").GetComponent<Scores>().update_score(increment);
            

        }


    }
}
