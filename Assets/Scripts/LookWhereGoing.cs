using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereGoing : Align
{

    public SteeringOutput getSteering()
    {
        Vector3 vel = character.linearVelocity;//This doesn't seem right

        if(vel.magnitude == 0)
        {
            return null;
        }
        target.transform.eulerAngles = new Vector3(0, Mathf.Atan2(-vel.x, vel.z), 0);

        return Align.getSteering();
    }

}
