using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnimation : MonoBehaviour
{
    public GameObject PuzzleElevator;
    public bool isActive = false;
    
    void Update()
    {
        if(isActive) {
            StartCoroutine(MoveElevator());
        }
    }

    IEnumerator MoveElevator()
    {
        isActive = false;
        PuzzleElevator.GetComponent<Animator>().Play("Elevator");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(20f);
        PuzzleElevator.GetComponent<Animator>().Play("New State");
        PuzzleElevator.GetComponent<Animator>().enabled = false;
    }
}