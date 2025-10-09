using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Xml.Serialization;

namespace MohawkTerminalGame
{
    
    public class TerminalGame
    {
        // point score 
        public int pointTotal;
        // bool to check if the current wave is over 
        public bool waveOver;
        // Place your variables here
        ByteClass[] Bytes = new ByteClass[3];

        TerminalGridWithColor map;

        public ColoredText background = new(@"O", ConsoleColor.DarkGray, ConsoleColor.Black);
        ColoredText texttt = new("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒≤▒≡▒x▒ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ▐ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                       \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b                      ", ConsoleColor.Green, ConsoleColor.Black);
        //ColoredText texttt = new("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒≤▒≡▒x▒  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│                          \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│+                        ", ConsoleColor.Green, ConsoleColor.Black);

        /*ColoredText Ui = new ColoredText(@"
╒══════════════════════════════════════════════════════════════════════════════╕
│                                                                              │
│                                                                              │
│                                                                              │
│                                                                              │
│                                                                              │
│ ┌▓────────────────────▓┐  ████████████████████████  ████████████████████████ │
│ ▌                      ▐  █                      █  █                      █ │
│ ▌                      ▐  █                      █  █                      █ │
│ ▌                      ▐  █                      █  █                      █ │
│ ▌                      ▐  █                      █  █                      █ │
│ ▌                      ▐  █                      █  █                      █ │
│ ▌                      ▐  █                      █  █                      █ │
│ ▌                      ▐  █                      █  █                      █ │
│ └▓────────────────────▓┘  ████████████████████████  ████████████████████████ │
│                                                                              │
│Text Example Here                                                             │
│Text Example Here                                                             │
│Text Example Here                                                             │
│Text Example Here                                                             │
│Text Example Here                                                             │
│                                                                              │
╞══════════════════════════════════════════════════════════════════════════════╡
│≥/                                                                            │
╘══════════════════════════════════════════════════════════════════════════════╛
");
        /
        */
        ColoredText intro = new(@"    │         │          │           │           │           │           │      
   ││  ──    ││         ││           │           ││          ││          │      
   │         ││      │  │││          │       ──   │          ││         ││    │ 
───│││────────│─────│────││──────────││──────────││──────────│───────────││─────
    ││        │          │       ──   │           │          │           ││     
    │      ─  │          ██████╗     █████╗ ████████╗    ─   │           │      
  ─││    ─    ││         ██╔══██╗   ██╔══██╗╚══██╔══╝        │       │   ││     
   │      │    │         ██████╔╝   ███████║   ██║│          ││           │  ─  
   │          ││         ██╔══██╗   ██╔══██║   ██║│     │    ││          ││     
───││─────────│ ─────────██║──██║██╗██║──██║██╗██║│──────────││──────────│──────
   │          ││         ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝╚═╝╚═╝│        │││        ─  │      
   │          ││          │           │          │           │           │      
   ││         █████╗ ████████╗████████╗ █████╗  ██████╗██╗  ██╗     ││    │     
─   │        ██╔══██╗╚══██╔══╝╚══██╔══╝██╔══██╗██╔════╝██║ ██╔╝          ││     
────│────────███████║───██║──────██║──│███████║██║─────█████╔╝│──────────│──────
     │       ██╔══██║   ██║      ██║  │██╔══██║██║     ██╔═██╗│          │  ──  
     │       ██║  ██║   ██║      ██║ ││██║  ██║╚██████╗██║  ██╗          │      
    ││  ──   ╚═╝  ╚═╝   ╚═╝  ──  ╚═╝ │ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝          │      
    ││        ││          │          │            │          │           ││     
─────│────────│───────────Press Any Button To Start──────────│────────────│─────
     │        ││         ││     ││    │           ││        │││           │     
 │  ││         │     ─   │││          │          │││         ││          ││     
    │          │         ││          ││          ││          ││  │       ││     
    │     ─   ││          │          │         │ ││          │            │   ─ 
────│─────────│───────────│──────────│────────────│──────────│────────────│─────", ConsoleColor.Green, ConsoleColor.Black);
        ColoredText Ui = new(@"┌──────────────────────────────/ F I R E W A L L /─────────────────────────────┐
│+Score:                             Wave:                          Lives:    +│
│ ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒≤▒≡▒x▒  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒≤▒≡▒x▒  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒≤▒≡▒x▒ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▌                      ▐  ▌                      ▐  ▌                      ▐ │
│ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ │
│                                                                              │
│+                                                                            +│
└──────────────────────────────────────────────────────────────────────────────┘
┌───────────────────────────────/ C O N S O L E /──────────────────────────────┐
│+                                                                            +│
│                                                                              │
│                                                                              │
│                                                                              │
│                                                                              │
│+                                                                            +│
└──────────────────────────────────────────────────────────────────────────────┘
┌───────────────────────/ C O M M A N D _ P R O M P T /────────────────────────┐
│≥/                                                                           +│
└──────────────────────────────────────────────────────────────────────────────┘", ConsoleColor.Green, ConsoleColor.Black);
        ColoredText refresh = new ColoredText(@"/                                                                           ");
        ColoredText refresh2 = new ColoredText(@"                                    ", ConsoleColor.Green, ConsoleColor.Black);
        
        bool gameStart = false;

        List<string> PASSWORDS = new List<string>() { "Cardstock", "bookworm", "Cheesecake", "Passwords", "pass123", "glowShift", "mintLeaf", "H@ppy", "Temporary", "12345678910", "bweh", ":3" };
        List<string> Passwords = new List<string>() { };
        string lastTyped = null;
        string lasttxt = "";
        string lastInput = string.Empty;

        int lastTime = 0;
        int wave = 0;
        int waveProgress;
        int waveMax = 6;

        float lastByteTime = 0;
        /// Run once before Execute begins
        public void Setup()
        {
            // Program configuration
            Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteTime;
            Program.TerminalInputMode = TerminalInputMode.EnableInputDisableReadLine;
            Program.TargetFPS = 30;

            map = new(80, 25, background);
            map.ClearWrite();

            Input.OnCharacterTyped += OnCharacterPressed;
            Input.OnEnterPressed += OnEnterPressed;

            Passwords = PASSWORDS;
        }
        // Execute() runs based on Program.TerminalExecuteMode (assign to it in Setup).
        //  ExecuteOnce: runs only once. Once Execute() is done, program closes.
        //  ExecuteLoop: runs in infinite loop. Next iteration starts at the top of Execute().
        //  ExecuteTime: runs at timed intervals (eg. "FPS"). Code tries to run at Program.TargetFPS.
        //               Code must finish within the alloted time frame for this to work well.
        
        public void Execute()
        {
            if (!gameStart)
            {
                GameSetup();
            }

            if (lastTime < Time.ElapsedSecondsWhole)
            { // timer
                TimerJunk();
            }

            
            if (Input.IsKeyPressed(ConsoleKey.Backspace) == true)
            {
                map.Poke(Console.CursorLeft, 23, new ColoredText("   \b\b\b"));
            }
            
            int term = Terminal.CursorLeft;
            Terminal.ForegroundColor = ConsoleColor.Green;

            if (lastInput != null)
            { // input
                InputLogic();
            }

            if (Terminal.CursorLeft > 77 || Terminal.CursorLeft < 3)
            {
                Terminal.ForegroundColor = ConsoleColor.Green;
                map.Poke(2, 23, refresh);
                Terminal.SetCursorPosition(3, 23);
                Input.TextKiller();
            }

        }

        void InputLogic()
        {
            Terminal.ForegroundColor = ConsoleColor.Green;
            map.Poke(2, 23, refresh);
            Terminal.SetCursorPosition(3, 23);
            int termtemp = Terminal.CursorLeft;
            for (int i = 0; i < Bytes.Length; i++)
            {
                if (Bytes[i] != null)
                {
                    if (Bytes[i].password == lastInput)
                    { // password input
                        map.Poke(Bytes[i].xPos - 2, 2, texttt);
                        map.Poke(Bytes[i].xPos - 3, 17, refresh2);
                        Bytes[i] = null;
                        Terminal.SetCursorPosition(termtemp, 23); // FIX
                    }
                }
            }

            if (lastInput == "add")
            { // debugging, remove later.
                ByteAdd();
            }
            lastInput = null;
        }
        

        void TimerJunk()
        {
            int termtemp = Terminal.CursorLeft;
            lastTime = Time.ElapsedSecondsWhole;
            // byte spawn code 
            
            if (lastByteTime + (10.0 - (0.3 * wave)) < Time.ElapsedSeconds)
            {
                
                ByteAdd();
                lastByteTime = Time.ElapsedSeconds;
                waveProgress++;
                
                if (waveProgress > waveMax) // Spawn time will start at 10 second intervals, decreases by 0.33 seconds each round (Wave 30 is when there's absolutely no cooldown)
                {
                    waveMax = 6 + wave * Random.Integer(1, 4);
                    wave++;
                    Terminal.SetCursorPosition(43, 1);
                    Terminal.Write(wave + 1);
                    Terminal.SetCursorPosition(termtemp, 23);

                }
            }

            // byte timer logic

            for (int i = 0; i < Bytes.Length; i++)
            { 
                if (Bytes[i] != null)
                {

                    string fuck = Bytes[i].timerstuff();
                    if (fuck == "KILLNOW")
                    { // this gets rid of the byte
                        map.Poke(Bytes[i].xPos - 2, 2, texttt);
                        map.Poke(Bytes[i].xPos - 3, 17, refresh2);
                        Bytes[i] = null;
                    }
                    else
                    { // this lowers the timer
                        ColoredText stupidTimer = new ColoredText(fuck);
                        map.Poke(Bytes[i].xPos - 1, 11, stupidTimer);
                    }
                    Terminal.SetCursorPosition(termtemp, 23);

                }

            }
        }

        void GameSetup()
        {
            map.Poke(0, 0, intro);
            Terminal.CursorVisible = false;
            while (!gameStart)
            {

                if (lastTyped != null)
                {
                    Terminal.ClearLine();
                    gameStart = true;
                }

            }
            Terminal.CursorVisible = true;
            Time.Start();
            map.Poke(0, 0, Ui);
            Terminal.SetCursorPosition(43, 1);
            Terminal.Write(wave + 1);
            Terminal.SetCursorPosition(3, 23);
            Input.TextKiller();
            refresh.fgColor = ConsoleColor.Green;
            waveMax = 6 + wave * Random.Integer(1, 4);
        }

        void ByteAdd()
        {
            // this sets a random type for the byte and chooses a free window.
            bool canGo = false;
            foreach (ByteClass bitt in Bytes)
            {
                if (bitt == null)
                {
                    canGo = true;
                }
            }
            if (canGo)
            {
                int termtemp = Terminal.CursorLeft;
                int type = Random.Integer(0, 3);
                int window = Random.Integer(0, 3);
                do
                {
                    if (Bytes[window] != null)
                    {
                        window = Random.Integer(0, 3);
                    }
                } while (Bytes[window] != null);

                int tempnum = Random.Integer(0, Passwords.Count);
                string tempPass = Passwords[tempnum];
                Passwords.RemoveAt(tempnum);

                if (Passwords.Count < 2)
                {
                    Passwords = PASSWORDS;
                }

                Bytes[window] = new ByteClass(type, window, tempPass);
                //sets colour
                Terminal.ForegroundColor = Bytes[window].newcol;
                Bytes[window].byte1.fgColor = Bytes[window].newcol;

                //drawbyte
                map.Poke(Bytes[window].xPos, 3, Bytes[window].byte1);

                Terminal.ForegroundColor = ConsoleColor.Green;

                Terminal.SetCursorPosition(Bytes[window].xPos - 3, 17);
                Console.WriteLine("Incoming byte: " + Bytes[window].password);
                Terminal.SetCursorPosition(termtemp, 23);

                Terminal.ForegroundColor = ConsoleColor.Green;
            }
            
        }

        

        void OnCharacterPressed(string currentText)
        {
            lastTyped = currentText;
        }

        void OnEnterPressed(string currentText)
        {
            lastInput = currentText;
        }
        
        
    }
}
