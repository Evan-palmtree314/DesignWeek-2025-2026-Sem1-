using Raylib_cs;
using System;
using System.ComponentModel;
using System.Security.Principal;
using System.Xml.Serialization;

namespace MohawkTerminalGame
{
    public class TerminalGame
    {
        //test
        string lastInput = string.Empty;

        // Place your variables here

        public ColoredText background = new(@"O", ConsoleColor.DarkGray, ConsoleColor.Black);
        ByteClass byte1 = new ByteClass(15, 8);
        TerminalGridWithColor map;
        ColoredText Ui = new ColoredText(@"
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
        ColoredText refresh = new ColoredText(@"                                                                            ");

        //ColoredText
        bool rann = false;

        /// Run once before Execute begins
        public void Setup()
        {
            // Program configuration
            Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteTime;
            Program.TerminalInputMode = TerminalInputMode.EnableInputDisableReadLine;
            Program.TargetFPS = 30;
            map = new(80, 25, background);
            // Hide raylib console output
            map.ClearWrite();
            rann = false;
            Input.OnCharacterTyped += OnCharacterPressed;
            Input.OnEnterPressed += OnEnterPressed;

        }

        // Execute() runs based on Program.TerminalExecuteMode (assign to it in Setup).
        //  ExecuteOnce: runs only once. Once Execute() is done, program closes.
        //  ExecuteLoop: runs in infinite loop. Next iteration starts at the top of Execute().
        //  ExecuteTime: runs at timed intervals (eg. "FPS"). Code tries to run at Program.TargetFPS.
        //               Code must finish within the alloted time frame for this to work well.
        public void Execute()
        {
            if (rann == false)
            {
                //Terminal.WriteLine(Input.CurrentText);
                //Terminal.WriteLine($"Last input: {lastInput}");
                //Terminal.ForegroundColor = ConsoleColor.White;
                //Terminal.BackgroundColor = ConsoleColor.White;

                //byteDraw(map);

                map.Poke(0, 0, Ui);
                Terminal.SetCursorPosition(3, 24);
            }
            //Console.ReadLineAsync();
            int term = Terminal.CursorLeft;
            string test = Console.ReadLine();
            
            // todo: get propper input without pausing
            // make backspace work
            // 
            //var testtt = Console.ReadLine();
            //Console.keyinfo = 
            //Console.In.ReadLineAsync();
            //if (Console.KeyAvailable)
            //{
                //string test = Console.ReadKey(true).Key.ToString();
                //Console.WriteLine(test);
               // int x = 0;
                
            //}
            //if (Console.KeyAvailable)
            //{
                //ConsoleKeyInfo key = Console.ReadKey(true); // true to intercept key
                //if (key.Key == ConsoleKey.Q)

                    //System.Console.ReadKey(true);

            //Input.IsKeyPressed()
            //map.ClearWrite();

            if (test != null)
            {
                map.Poke(3, 24, refresh);
                Terminal.SetCursorPosition(3, 24);
                
            }
            if (Terminal.CursorLeft > 77)
            {
                map.Poke(3, 24, refresh);
                Terminal.SetCursorPosition(3, 24);
            }

            rann = true;

        }
        void OnCharacterPressed(string currentText)
        {
            // 
        }

        void OnEnterPressed(string currentText)
        {
            lastInput = currentText;
        }
    }
}
