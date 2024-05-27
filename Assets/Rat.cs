using System.Collections;
using System.Collections.Generic;
using RenownedGames.AITree;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] private UIManager manager;

    [SerializeField] private Cursor cursor;
    [SerializeField] private BehaviourRunner br;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(manager.heldTreat == true)
        {
            manager.dropTreat();
        }
        
    }
}
