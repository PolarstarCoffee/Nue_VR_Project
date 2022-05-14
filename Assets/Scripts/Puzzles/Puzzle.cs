using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    public bool solved;

    public UnityEvent OnSolved;
    public UnityEvent OnReset;

    public void SolvePuzzle()
    {
        solved = true;

        OnSolved.Invoke();
    }
    public void Reset()
    {
        solved = false;
        OnReset.Invoke();
       
    }
}
