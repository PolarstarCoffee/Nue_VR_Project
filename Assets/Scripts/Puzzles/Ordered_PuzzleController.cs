using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordered_PuzzleController : PuzzleController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void CheckForPuzzlesSolved()
    {
        //base.CheckForPuzzlesSolved();\

        int numSolved = 0;

        for (int i = 0; i < puzzles.Length; i++)
        {
            Puzzle p = puzzles[i];
            if (p.solved == true)
            {
                numSolved += 1;
            }
            else
            {
                break;
            }
        }

        if (numSolved == puzzles.Length)
        {
            OnSolved.Invoke();
        }
        else
        {
            for (int i = numSolved; i < puzzles.Length; i++ )
            {
                Puzzle p = puzzles[i];
                p.Reset();
            }
        }


    }
}
