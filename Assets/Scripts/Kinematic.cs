using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{

    //pos comes from attached go tx

    public Vector3 linearVelocity;
    public float angularVelocity; //Deg
    public GameObject target;

    public bool bIsSeeking;
    private Seek mySeek;
    private SteeringOutput seekSteer;
    private Flee myFlee;
    private SteeringOutput fleeSteer;

    public bool bCanArrive;
    private Arrive myArrv;
    private SteeringOutput arrvSteer;

    public bool bDoesAlign;
    private Align myAlgn;
    private SteeringOutput algnSteer;


    // Start is called before the first frame update
    void Start()
    {

        mySeek = new Seek();
        mySeek.character = this;
        mySeek.target = target;
        myFlee = new Flee();
        myFlee.character = this;
        myFlee.target = target;

        myArrv = new Arrive();
        myArrv.character = this;
        myArrv.target = target;

        myAlgn = new Align();
        myAlgn.character = this;
        myAlgn.target = target;
    }


    // Update is called once per frame
    void Update()
    {
        //Update pos rot
        transform.position += linearVelocity * Time.deltaTime;
        Vector3 angularIncrement = new Vector3(0, angularVelocity * Time.deltaTime, 0);
        transform.eulerAngles += angularIncrement;

        SteeringOutput steering = new SteeringOutput();
        //Get Steerings
       /*if(bIsSeeking)
        {
            steering = mySeek.getSteering();
        } else
        {
            steering = myFlee.getSteering();
        }*/
        if(bCanArrive)
        {
            
            SteeringOutput _arrvSteering = myArrv.getSteering();
            if(_arrvSteering != null)
            {
                Debug.Log(_arrvSteering.linear);
                linearVelocity += _arrvSteering.linear * Time.deltaTime;
                angularVelocity += _arrvSteering.angular * Time.deltaTime;
            }
            else
            {
                linearVelocity = Vector3.zero;
            }
        }
        if(bDoesAlign)
        {
            SteeringOutput _algnSteering = myAlgn.getSteering();
            if(_algnSteering != null)
            {
                steering.angular += _algnSteering.angular * Time.deltaTime;
            }
            else
            {
                angularVelocity = 0f;
            }
        }

        //update lin ang vel
        
        linearVelocity += steering.linear * Time.deltaTime;
        angularVelocity += steering.angular * Time.deltaTime;

    }
}
