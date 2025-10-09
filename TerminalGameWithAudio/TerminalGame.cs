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
        //test
        string lastInput = string.Empty;
        // point score 
        public int pointTotal;
        // bool to check if the current wave is over 
        public bool waveOver;

        static List<string> PASSWORDS = new List<string>() { "Cardstock", "bookworm", "Chessecake", "Passwords", "pass123", "glowShift", "mintLeaf", "H@ppy" };
        List<string> Passwords = new List<string>() {};

        //List<ByteClass> Bytes = new List<ByteClass> {};
        ByteClass[] Bytes = new ByteClass[3];
        // Place your variables here

        public ColoredText background = new(@"O", ConsoleColor.DarkGray, ConsoleColor.Black);
        //ByteClass byte1 = new ByteClass(15, 8);
        TerminalGridWithColor map;
        ColoredText texttt = new("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒≤▒≡▒x▒  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▌                      ▐  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│                          \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b│+                        ", ConsoleColor.Green, ConsoleColor.Black);
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
        ColoredText refresh = new ColoredText(@"                                                                           ");
        ColoredText refresh2 = new ColoredText(@"                                    ");
        //ColoredText
        bool rann = false;
        string lasttxt = "";
        int lastTime = 0;
        string lastTyped = null;

        /// Run once before Execute begins
        public void Setup()
        {
            // Program configuration
            //Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteLoop;
            Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteTime;
            Program.TerminalInputMode = TerminalInputMode.EnableInputDisableReadLine;
            Program.TargetFPS = 30;
            map = new(80, 25, background);
            // Hide raylib console output
            map.ClearWrite();
            rann = false;
            Input.OnCharacterTyped += OnCharacterPressed;
            Input.OnEnterPressed += OnEnterPressed;

            Passwords = PASSWORDS;
        }
        // Execute() runs based on Program.TerminalExecuteMode (assign to it in Setup).
        //  ExecuteOnce: runs only once. Once Execute() is done, program closes.
        //  ExecuteLoop: runs in infinite loop. Next iteration starts at the top of Execute().
        //  ExecuteTime: runs at timed intervals (eg. "FPS"). Code tries to run at Program.TargetFPS.
        //               Code must finish within the alloted time frame for this to work well.
        bool gameStart = false;
        public void Execute()
        {
            
            // don't forget to remove.
            if (!gameStart)
            {
                map.Poke(0, 0, intro);
                Terminal.CursorVisible = false;
                while (!gameStart)
                {
                    
                    if (lastTyped != null)
                    {
                        gameStart = true;
                    }
                }
                Terminal.CursorVisible = true;
                Time.Start();

            }
            if (rann == false)
            {
                map.Poke(0, 0, Ui);
                Terminal.SetCursorPosition(3, 23);
                //Terminal.ForegroundColor = ConsoleColor.Green;
            }
            
            if (lastTime < Time.ElapsedSecondsWhole)
            { // timer
                
                int termtemp = Terminal.CursorLeft;
                lastTime = Time.ElapsedSecondsWhole;
                
                for (int i = 0;i < Bytes.Length; i++)
                {
                    if (Bytes[i] != null)
                    {

                        string fuck = Bytes[i].timerstuff(); 
                        if (fuck == "KILLNOW") 
                        {
                            map.Poke(Bytes[i].xPos - 2, 2, texttt);
                            map.Poke(Bytes[i].xPos - 3, 17, refresh2);
                            Bytes[i] = null;
                            Terminal.SetCursorPosition(termtemp, 23);
                            //(Bytes[i].byteType)
                        }
                        else
                        {
                            ColoredText stupidTimer = new ColoredText(fuck);
                            map.Poke(Bytes[i].xPos-1, 11, stupidTimer);
                            Terminal.SetCursorPosition(termtemp, 23);
                        }

                    }

                }
                
            }
            
            
            int term = Terminal.CursorLeft;
            Terminal.ForegroundColor = ConsoleColor.Green;
            
            // make backspace work

            if (lastInput != null)
            { // input
                map.Poke(3, 23, refresh);
                Terminal.SetCursorPosition(3, 23);
                int termtemp = Terminal.CursorLeft;
                for (int i = 0; i< Bytes.Length; i++)
                {
                    if (Bytes[i]!= null)
                    {
                        if (Bytes[i].password == lastInput)
                        {
                            map.Poke(Bytes[i].xPos - 2, 2, texttt);
                            map.Poke(Bytes[i].xPos - 3, 17, refresh2);
                            Bytes[i] = null;
                            Terminal.SetCursorPosition(termtemp, 23); // FIX
                        }
                    }
                }

                if (lastInput == "add")
                { // debugging, remove later.
                    bool canGo = false;
                    foreach(ByteClass bitt in Bytes)
                    {
                        if (bitt == null)
                        {
                            canGo = true;
                        }
                    }
                    if (canGo)
                    {
                        ByteAdd();
                    }
                    
                }
                lastInput = null;
            }
            if (Terminal.CursorLeft > 77)
            {
                // to do, reset input
                map.Poke(3, 23, refresh);
                Terminal.SetCursorPosition(3, 23);
            }

            rann = true;

        }

        void ByteAdd()
        {
            // this sets a random type for the byte and chooses a free window.
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

            Bytes[window] = new ByteClass(type, window, tempPass);
            //sets colour
            Terminal.ForegroundColor = Bytes[window].newcol;
            Bytes[window].byte1.fgColor = Bytes[window].newcol;

            //drawbyte
            map.Poke(Bytes[window].xPos, 3, Bytes[window].byte1);

            Terminal.ForegroundColor = ConsoleColor.Green;

            Terminal.SetCursorPosition(Bytes[window].xPos - 3, 17);
            Console.WriteLine("heyy write this: " + Bytes[window].password);
            Terminal.SetCursorPosition(termtemp, 23);

            Terminal.ForegroundColor = ConsoleColor.Green;
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
