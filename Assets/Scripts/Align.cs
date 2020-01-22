using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align
{
    public Kinematic character;
    public GameObject target;


    float maxAngularAccel = 50f;
    float maxRotation = 20f;
    float targetRadius = 8f;
    float slowRadius = 6f;

    float timeToTarget = 0.1f;

    public SteeringOutput getSteering()
    {
      SteeringOutput result = new SteeringOutput();
      float targetRotation;

      



        ///This isn't fully working in this implementation, issues with negative rots sometimes
        float _rotation = Mathf.DeltaAngle(character.transform.eulerAngles.y, target.transform.eulerAngles.y);
        float _rotationSize = Mathf.Abs(_rotation);
        Debug.Log(_rotation);



        if(_rotationSize < targetRadius)
        {
            return null;
        }
        
        if(_rotationSize > slowRadius)
        {
            targetRotation = maxRotation;
        } 
        else
        {
            targetRotation = maxRotation * _rotationSize / slowRadius;
        }

    
        targetRotation *= _rotation / _rotationSize;

        result.angular = targetRotation - character.transform.eulerAngles.y;
        result.angular /= timeToTarget;

        float _angAccel = Mathf.Abs(result.angular);
        if(_angAccel > maxAngularAccel)
        {
            result.angular /= _angAccel;
            result.angular *= maxAngularAccel;
        }

      //Final target rot comb speed & dir
      

      result.linear = Vector3.zero;

      return result;
    }
}
