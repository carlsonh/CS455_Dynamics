using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathDemo : Seek
{
    public GameObject[] path;
    float targetRadius = 1f;
    int currentPathIndex = 0;


    public override SteeringOutput getSteering()
    {
        if(target == null)
        {
            currentPathIndex = 0;
            target = path[currentPathIndex];
        }

        float distToTarget = (target.transform.position - character.transform.position).magnitude;
        if (distToTarget < targetRadius)
        {
            currentPathIndex++;
            if (currentIndex > path.Length - 1)
            {
                currentPathIndex = 0;
            }
            target = path[currentPathIndex];
        }


        return base.getSteering();
    }

}
