using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering: SteeringBehavior
{
    public BlendedSteering[] groups;

   	float epsilon = 10.0f;

    public override SteeringOutput getSteering()
    {   
        SteeringOutput result = new SteeringOutput();
        result.linear = new Vector3(0, 0, 0);
        result.angular = 0.0f;

        foreach( BlendedSteering group in groups ){
            result = group.getSteering();

            /* Note: Ignoring angular accel. intentionally */
            if( result.linear.magnitude > epsilon )
                return result;
        }

        return result; 
    }
}
