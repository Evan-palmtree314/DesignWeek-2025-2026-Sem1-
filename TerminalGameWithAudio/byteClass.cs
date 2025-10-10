using MohawkTerminalGame;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

public class ByteClass
{
    public ColoredText byte1 = new("░  ░  ▄ ░  ░      \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b░  ░▓▒  ▒▓▓█▒ ░▓▒  ░  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b  ░  ░ ░▓████▓  ░ ▓▒  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ░▒▓   ▒▌ ▓ ▐▓ ▓▒░    \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b  ▓   ░ ██▄██   ▓    ░\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b░    ▒ ░▄■■■▄▓    ░   \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ▒      ▀▒▓█▀      ▒░ ");

    ColoredText byte2 =new(" ░ ░    ▄▓██▄ ░▒░     \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b   ▒█  ░▒▓███▓ ▓  ░   \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ░  ▓  ░▌ ▒ ▐▓  ░ █▓ ░\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ░▓▒  ░ ██▄██  ░░▓    \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b  █  ░ ▐▄■■■▄▌  ▓█  ░ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ░    ░ ▀▒▓█▀      ░▒ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b▓            ░      ▓");

    ColoredText byteDeathanim = new("\\  ▄  /\v\b\b\b\b\b\b\b\b \\███/ \v\b\b\b\b\b\b\b\b██\\█/██\v\b\b\b\b\b\b\b\b█▌ \\ ▐█\v\b\b\b\b\b\b\b\b █/▄\\█ \v\b\b\b\b\b\b\b\b█/■■■\\█");
    string timer10 = "╔▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀╝";

    string timer9 = "╔▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄──╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀──╝";

    string timer8 = "╔▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀────╝";

    string timer7 = "╔▄▄▄▄▄▄▄▄▄▄▄▄▄▄──────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀▀▀▀▀▀▀──────╝";

    string timer6 = "╔▄▄▄▄▄▄▄▄▄▄▄▄────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀▀▀▀▀────────╝";

    string timer5 = "╔▄▄▄▄▄▄▄▄▄▄──────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀▀▀──────────╝";

    string timer4 = "╔▄▄▄▄▄▄▄▄────────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀▀▀────────────╝";

    string timer3 = "╔▄▄▄▄▄▄──────────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀▀▀──────────────╝";

    string timer2 = "╔▄▄▄▄────────────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀▀▀────────────────╝";

    string timer1 = "╔▄▄──────────────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚▀▀──────────────────╝";

    string timer0 = "╔────────────────────╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚────────────────────╝";

    string timerAtt = "╔╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╥╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╨╝";

    string timerDeath = "╔\\/\\/\\/\\/\\/\\/\\/\\/\\/\\/╗\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b╚/\\/\\/\\/\\/\\/\\/\\/\\/\\/\\╝";

    

    string[] timers;
    public int xPos;
    int yPos = 2;
    bool byteDeath = false;

    float timeleft;
    public int byteType; // can be red, blue, yellow
    public int byteWindow;
    public ConsoleColor newcol = ConsoleColor.White;
    float timee;
    int timeCounter = 10;
    public string password;

    //string consolewords = "";
    public int consoleorder = 0;

    //public int TimeBorn = 0;

    public void ConsoleWriter()
    {
        //consoleorder++;

        int FUCK = Terminal.CursorLeft;
        Terminal.SetCursorPosition(3, 16 + byteWindow);
        int bittenWindow = byteWindow + 1;
        Terminal.Write("Window " + bittenWindow + " incoming byte: " + password);

        Terminal.SetCursorPosition(FUCK, 23);
    }
    
    public void stupidFunctionThatIHate()
    {
        int FUCK = Terminal.CursorLeft;
        Terminal.SetCursorPosition(3, 16 + byteWindow);
        int bittenWindow = byteWindow + 1;
        Terminal.Write("Window "+bittenWindow+" incoming byte: " + password);

        Terminal.SetCursorPosition(FUCK, 23);
        

    }


    public ByteClass(int type, int window, string pass, int consoleshit)
	{
        /// import timer sprites.
        //Time.ElapsedSeconds()
        timers = new string[] {timer0, timer1, timer2, timer3, timer4, timer5, timer6, timer7, timer8, timer9, timer10, timerDeath, timerAtt};
        this.byteType = type;
        this.byteWindow = window;
        this.password = pass;
        this.consoleorder = consoleshit;
        switch (byteWindow)
        {
            case 0:
                xPos = 4;
                break;
            case 1:
                xPos = 30;
                break;
            case 2:
                xPos = 56;
                break;
        }
        switch (byteType)
        {
            case 0:
                newcol = ConsoleColor.Red;
                break;
            case 1:
                newcol = ConsoleColor.Blue;
                break;
            case 2:
                newcol = ConsoleColor.Yellow;
                break;
        }
    }
    public string timerstuff()
    {
        string timerGui = timers[timeCounter];
        timeCounter -= 1;
        if (byteDeath)
        {
            return ("KILLNOW");
        }
        if (timeCounter == -1)
        {
            timeCounter = 11;
            byteDeath = true;
        }
        return (timerGui);
    }
    
}
