using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathDemo : Seek
{
    public GameObject[] path;
    float targetRadius = 1f;


    public override SteeringOutput getSteering()
    {
        int currentIndex = 0;
        target = path[currentIndex];

        float distToTarget = (target.transform.position - character.transform.position).magnitude;
        if (distToTarget < targetRadius)
        {
            currentIndex++;
            if (currentIndex > path.Length - 1)
            {
                currentIndex = 0;
            }
            target = path[currentIndex];
        }


        return base.getSteering();
    }

}
