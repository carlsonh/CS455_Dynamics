using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{

    public SteeringOutput getSteering()
    {
        //Calc target to delegate to align
        Vector3 direction = target.transform.position - character.transform.position;

        if(direction.magnitude == 0)
        {
            return null;
        }
        Align.target = target;//?? explicitTarget existence n/a
        Align.target.transform.eulerAngles.y = Mathf.Atan2(-direction.x, direction.z);
        return Align.getSteering();
    }


}
