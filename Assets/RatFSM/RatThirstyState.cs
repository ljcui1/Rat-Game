using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RatThirstyState : RatBaseState
{
    Vector2 waterPosition;
    float time_passed = 0;
    bool finished = false;
    bool start = false;
    public override void EnterState(RatFSM rat)
    {
        if (start == false)
        {
            GameObject temp = GameObject.Find("bottle_0");
            Transform waterTransform = temp.GetComponent<Transform>();
            waterPosition = new Vector2(waterTransform.position.x, waterTransform.position.y);
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, waterPosition, 8f);
            //start the drinking animation
            start = true;
            finished = false;
        }
        time_passed += Time.deltaTime;
        if (time_passed >= 10)
        {
            //stop the drinking animation
            rat.thirst += 50;
            finished = true;
            start = false;
        }
    }

    public override void UpdateState(RatFSM rat)
    {
        if (finished == false)
        {
            rat.SwitchState(rat.thirstyState);
        }

        if (rat.manager.heldTreat == true)
        {
            rat.SwitchState(rat.treatState);
        }

        if (rat.hunger <= 50)
        {
            rat.SwitchState(rat.hungryState);
        }

        //The default
        rat.SwitchState(rat.roamState);
    }
}
