using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    public Vector3 pointB;
    public Vector3 pointA;

    float currentPosition = 0; // Range from 0 to 5
    bool direction = true; // true = right, false = left

    private void Update()
    {
        //currentPosition += direction ? Time.deltaTime : -Time.deltaTime;
        if (direction) {
            currentPosition += 3 * Time.deltaTime;
        }
        else {
            currentPosition -= 3 * Time.deltaTime;
        }

        if (currentPosition > 5) { direction = false; }
        if(currentPosition < 0) { direction = true; }

        if (direction) {
            transform.Translate(3*Time.deltaTime ,0f,0f);
        }
        else {
            transform.Translate(-3* Time.deltaTime, 0f, 0f);
        }



    }

    
}