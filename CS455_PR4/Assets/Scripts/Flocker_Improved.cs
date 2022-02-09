using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker_Improved: Kinematic
{

    public GameObject oa_target_prefab;
    public GameObject target;

    PrioritySteering myMoveType;
    Face myRotateType;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new PrioritySteering();

        GameObject[] flock = GameObject.FindGameObjectsWithTag("Flocker");
       
        /* Group 1: Collision Avoidance */
        BlendedSteering g1 = new BlendedSteering();

            /* Behavior 1: Obstacle Avoidance */
            ObstacleAvoidance g1b1 = new ObstacleAvoidance( oa_target_prefab );
            g1b1.character = this;
            g1b1.target = target;
            g1b1.dummyTargetPF = oa_target_prefab;
            
            g1.behaviors = new BehaviorAndWeight[] { new BehaviorAndWeight(g1b1, 1) };

        /* Group 2: Separation and Seek */
        BlendedSteering g2 = new BlendedSteering();

            /* Behavior 1: Separation */ 
            Separation g2b1 = new Separation();
            g2b1.character = this;
            g2b1.targets = new Kinematic[ flock.Length ];
            for( int i=0; i<flock.Length; i++ )
                g2b1.targets[i] = flock[i].GetComponent<Kinematic>();

            /* Behavior 2: Matching */
            Matching g2b2 = new Matching();
            g2b2.character = this;
            g2b2.targets = g2b1.targets;

            /* Behavior 3: Cohesion */
            Cohesion g2b3 = new Cohesion(); 
            g2b3.character = this;
            g2b3.targets = g2b1.targets;

            /* Behavior 4: Seek */
            Seek g2b4 = new Seek();
            g2b4.character = this;
            g2b4.target = target;
            g2b4.flee = false;

            g2.behaviors = new BehaviorAndWeight[] { new BehaviorAndWeight(g2b1, 300),
                                                     new BehaviorAndWeight(g2b2, 1),
                                                     new BehaviorAndWeight(g2b3, 1),
                                                     new BehaviorAndWeight(g2b4, 1) };

        myMoveType.groups = new BlendedSteering[]{ g1, g2 };

        myRotateType = new Face();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
