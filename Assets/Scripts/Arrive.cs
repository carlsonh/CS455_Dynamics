using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive
{
    public Kinematic character;
    public GameObject target;

    float maxAcceleration = 20f;
    float maxSpeed = 10f;

    float targetRadius = 5f;
    float slowRadius = 15f;
    float timeToTarget = 3f;

    float targetSpeed;
    Vector3 targetVel;

    public SteeringOutput getSteering()
    {
      SteeringOutput result = new SteeringOutput();
      Vector3 direction = target.transform.position - character.transform.position;
      float _dist = direction.magnitude;


      //If nearby to target, don't influence accels
      if (_dist < targetRadius)
      {
        return null;
      }
      //If not near target, max speed move towards it
      if(_dist > slowRadius)
      {
        targetSpeed = maxSpeed;
      } else //If near target, slow down accel
      {
        targetSpeed = maxSpeed * (_dist - targetRadius) / (slowRadius);
      }
      targetVel = direction;
      targetVel.Normalize();
      targetVel *= targetSpeed;

      result.linear = targetVel;
      result.linear /= timeToTarget;

      //Ceil acceleration
      if(result.linear.magnitude > maxAcceleration)
      {
        result.linear.Normalize();
        result.linear *= maxAcceleration;
      }

      return result;
    }




    //if(distance <= targetRadius)
      //  {
       // return null;
    //targetSpeed = -(maxSpeed * distance/slowRadius);
}
