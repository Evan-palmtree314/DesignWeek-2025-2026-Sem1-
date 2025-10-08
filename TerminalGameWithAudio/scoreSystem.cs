using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using MohawkTerminalGame;
public class scoreboard
{
    // varibles 
    int pointTotal;



   // score systyem
   // pardon my lack of spelling anbd common sense

    // 3 seperate score types for killing enemy  
    public RegularPointScore(int currentPoints)
    {
        currentPoints + 100;

            return currentPoints;
    }
    public fastPointScore(int currentPoints)
    {
        currentPoints + 200;

        return currentPoints;
    }
    public frostPointScore(int currentPoints)
    {
        currentPoints + 150;

        return currentPoints;
    }

    // special ability point
    public SpecialScore(int currentPoints,bool speicalCircumstance)
    {
        if (speicalCircumstance=true)
        {
            currentPoints+500

        }
        return currentPoints;
    }
    // time based wave points 
    // every 
    public wavePointAdd(int currentPoints,bool waveOver)// a clock function is needed)
    {
        if (waveOver = true) 
        { 
        currentPoints+1000

        }
        return currentPoints;
    }



}
