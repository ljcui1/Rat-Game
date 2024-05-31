using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatFSM : MonoBehaviour
{
    public int hunger;
    public int thirst;
    public int happiness;

    public SpriteRenderer ratSprite;

    RatBaseState currentState;

    public RatRoamState roamState = new RatRoamState();
    public RatTreatState treatState = new RatTreatState();
    public RatHungryState hungryState = new RatHungryState();
    public RatThirstyState thirstyState = new RatThirstyState();
    public RatWantState wantState = new RatWantState();
    public RatTickleState tickleState = new RatTickleState();

    public UIManager manager;
    public Animator rat;
    

    // Start is called before the first frame update
    void Start()
    {
        ratSprite = GetComponent<SpriteRenderer>();
        hunger = 100;
        thirst = 100;
        happiness = 100;

        currentState = roamState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(happiness > 100)
        {
            rat.Play("bogglewalk");
        }
        else
        {
            rat.Play("walking");
        }
        currentState.UpdateState(this);
    }

    public void SwitchState(RatBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void StartRatCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
