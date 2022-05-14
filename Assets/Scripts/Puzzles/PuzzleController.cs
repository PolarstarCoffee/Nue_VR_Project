using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour
{
    public Puzzle[] puzzles;

    public UnityEvent OnSolved;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // CheckForPuzzlesSolved();

    }

    public virtual void CheckForPuzzlesSolved()
    {
        int numSolved = 0;

        for (int i = 0; i < puzzles.Length; i++)
        {
            Puzzle p = puzzles[i];
            if (p.solved == true)
            {
                numSolved += 1;
            }
        }

        if (numSolved == puzzles.Length)
        {
            OnSolved.Invoke();
        }
    }
}
