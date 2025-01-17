using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitnRunRetreatState : IHitnRunState
{
    float timeInState = 0.667f;
    bool triggeredDash = false;

    public IHitnRunState DoState(HitnRunStateMachine hitnRunStateMachine)
    {
        if (triggeredDash == false)
        {
            //trigger dash backwards
            hitnRunStateMachine.dashBehavior.dashInput.TriggerDash();
            hitnRunStateMachine.dashBehavior.Dashing();

            triggeredDash = true;
        }

        timeInState -= Time.deltaTime;

        if (timeInState <= 0)
        {
            timeInState = 0.667f;
            //timeInState = 0.5f;
            triggeredDash = false;
            hitnRunStateMachine.movementData.anim.SetBool("Retreat", false);
            return hitnRunStateMachine.chaseState;
        }

        /*        Debug.Log("Retreating");*/
        hitnRunStateMachine.movementData.anim.SetBool("Retreat", true);
        return hitnRunStateMachine.retreatState;
    }
}
