using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using MohawkTerminalGame;

public class scoreSystem
{
    // varibles 
    public int pointTotal;
    public bool waveOver;
    

   // score systyem
   // pardon my lack of spelling anbd common sense

    // 3 seperate score types for killing enemy  
    public scoreSystem()
    {
        pointTotal = 0;
    }
    public void ScoreAdd(ByteClass steve)
    {
        switch (steve.byteType)
        {
            case 0: //yellow
                {
                    int addedScore = 100;
                    pointTotal += addedScore;
                    return;
                }
            case 1:
                {
                    int addedScore = 200;
                    pointTotal += addedScore;
                    return;
                }
            case 2:
                {
                    int addedScore = 200;
                    pointTotal += addedScore;
                    return;
                }
        }
    }


    // special ability point

    public void speicalScoreSystem()
     {
        pointTotal += 500;
     }
   
    // time based wave points 
    // ever
    public void WavePoints()// a clock function is needed)
    {
        pointTotal += 1000;
    }



}
