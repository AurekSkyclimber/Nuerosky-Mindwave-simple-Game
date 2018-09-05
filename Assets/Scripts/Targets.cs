using UnityEngine;
using System.Collections;

public class Targets : MonoBehaviour
{
    
    float currentRot = 0; 
    bool rotation = true; 

    float intensity = 15f;

    public Transform[] targets;

    private void Update()
    {
        if (rotation)
        {
            currentRot += Time.deltaTime * intensity;
        }
        else
        {
            currentRot -=  Time.deltaTime * intensity;
        }

        if (currentRot > 25f) { rotation = false; }
        if (currentRot < -25f) { rotation = true; }

        if (rotation)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].Rotate(0f, Time.deltaTime * intensity, 0f);
            }
        }
        else
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].Rotate(0f, -Time.deltaTime * intensity, 0f);
            }
        }


       
    }

    
}