using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Sprite hand;
    public Sprite treathand;
    public SpriteRenderer sr;
    private Vector3 mousePos;

    [SerializeField] private RatFSM rat;

    private IEnumerator pet;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.sprite = hand;

        pet = Tickle();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        this.transform.position = mousePos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("rat"))
        {
            rat.SwitchState(rat.tickleState);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("rat"))
        {
            StartCoroutine(pet);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("rat"))
        {
            rat.SwitchState(rat.roamState);
        }
    }

    private IEnumerator Tickle()
    {
        rat.happiness++;
        yield return new WaitForSeconds(2);
    }
}
