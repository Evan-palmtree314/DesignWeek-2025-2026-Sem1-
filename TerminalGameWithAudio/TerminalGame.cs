using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Xml.Serialization;

namespace MohawkTerminalGame
{
    
    public class TerminalGame
    {
        // point score 
        public int pointTotal;
        string[,] highScores = new string[2, 10];
        scoreSystem scoreBor = new scoreSystem();
        // bool to check if the current wave is over 
        public bool waveOver;
        // Place your variables here
        ByteClass[] Bytes = new ByteClass[3];

        TerminalGridWithColor map;
        // fucking byte shit
        public ColoredText byte1 = new("░  ░  ▄ ░  ░      \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b░  ░▓▒  ▒▓▓█▒ ░▓▒  ░  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b  ░  ░ ░▓████▓  ░ ▓▒  \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ░▒▓   ▒▌ ▓ ▐▓ ▓▒░    \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b  ▓   ░ ██▄██   ▓    ░\v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b░    ▒ ░▄■■■▄▓    ░   \v\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b ▒      ▀▒▓█▀      ▒░ ");
        public ColoredText Gameoverrfucker = new ColoredText(@"FAILED TO CONNECT TO SERVER 1...                                          
FAILED TO CONNECT TO SERVER 2...                    ░░▒▒▒▒▒▒▒▒▒▒░░        
FAILED TO CONNECT TO SERVER 3...                ░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░    
R.A.T. FAILED TO INITIALIZE...                ░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒░░░  
TERMINATING PROGRAM...                       ░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░░ 
                                            ░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░
                                            ░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░
     ▄████  ▄▄▄       ███▄ ▄███▓▓█████      ░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░
    ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀      ░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░
   ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███        ░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░
   ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄      ░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░░
   ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒      ░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒░ 
    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░      ▓▓▓        ▓▓▓▓▓▓        ▓▓▓ 
    ▒█████   ██▒   █▓▓█████  ██▀███           ▓         ▓▓▓▓▓▓         ▓  
   ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒ ░      ▓▓         ▓▓▓▓▓▓         ▓▓ 
   ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒       ░▒▓░      ▓▓▓▓  ▓▓▓▓      ░▓▒░
   ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄         ░▒▒▓▓▓▓▓▓▓▓▓▓    ▓▓▓▓▓▓▓▓▓▓▒░░
   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒        ░░▒▒▓▓▓▓▓▓▓▓    ▓▓▓▓▓▓▓▓▒▒░░ 
   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░            ▒▒▓▓▓▓▓      ▓▓▓▓▓▒▒     
     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░               ▓▓▓▓▓▓▓▓▓▓▓▓▓▓        
   ░ ░ ░ ▒       ░░     ░     ░░   ░                ▓░▒▓▓▓▓▓▓▓▓▒░▓        
       ░ ░        ░     ░  ░   ░                    ▒░░▓░▓░░▓░▓░░▒        
                                                       ▒░▒░░▒░▒           ", ConsoleColor.DarkRed, ConsoleColor.Black);
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
│+   Score:                          Wave:                        Lives:      +│
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
        ColoredText refresh2 = new ColoredText("                                    ", ConsoleColor.Green, ConsoleColor.Black);
        ColoredText instructions = new ColoredText(@"  ██╗  ██╗ ██████╗ ██╗    ██╗    ██████╗     ██████╗ ██╗      █████╗ ██╗   ██╗│ 
  ██║  ██║██╔═══██╗██║    ██║    ╚════██╗    ██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝│ 
 │███████║██║   ██║██║ █╗ ██║     █████╔╝    ██████╔╝██║     ███████║ ╚████╔╝   
 │██╔══██║██║   ██║██║███╗██║    ██╔═══╝     ██╔═══╝ ██║     ██╔══██║  ╚██╔╝    
─│██║  ██║╚██████╔╝╚███╔███╔╝    ███████╗    ██║     ███████╗██║  ██║   ██║   ──
 │╚═╝  ╚═╝ ╚═════╝  ╚══╝╚══╝     ╚══════╝    ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝     
 │            │             │           ││          │           │           ││  
 │   ╔═══════════════════════════════════════════════════════════════════╗  ││  
││   ║   - Enter the correct passcode to destroy the bytes               ║   │  
│    ║                                                                   ║  ││  
│────║   - Your goal is to gain the highest score in the leaderboards    ║──││──
│    ║                                                                   ║  ││  
│    ║   - A Special Ability will appear on console every 10000 score    ║   │  
││   ║         ▄▓██▄                 ▄▓██▄                 ▄▓██▄         ║   │  
 │   ║        ░▒▓███▓               ░▒▓███▓               ░▒▓███▓        ║   ││ 
 │   ║        ░▌ ▒ ▐▓               ░▌ ▒ ▐▓               ░▌ ▒ ▐▓        ║   ││ 
─│───║         ██▄██                 ██▄██                 ██▄██         ║───││─
 │   ║        ▐▄■■■▄▌               ▐▄■■■▄▌               ▐▄■■■▄▌        ║   ││ 
 │   ║         ▀▒▓█▀                 ▀▒▓█▀                 ▀▒▓█▀         ║   │  
 │   ║  10 seconds to Attack  5 seconds to Attack   10 seconds to lock   ║   │  
 │   ║                                            keyboard for 2 seconds ║   │  
 │   ║ [Press any button to Start]                                       ║   │  
─│───╚═══════════════════════════════════════════════════════════════════╝───│──
 │            │             │           │           │           │           ││  
 │            │             │           ││          │           │           ││  ", ConsoleColor.Green, ConsoleColor.Black);
        ColoredText credits = new ColoredText(@"   ││  ──    ││         ││           │           ││          ││          │      
   │         ││      │  █▀█  █▀█  █▀▀  █▀▄  █  ▀█▀  ▄▀▀      ││         ││    │ 
───│││────────│─────│───█    █▀▄  █■   █ █  █   █   ▀■▄──────│───────────││─────
    ││        │         █▄█  █ █  █▄▄  █▄▀  █   █   ▄▄▀      │           ││     
 ┌────────────────────────────────────────────────────────────────────────────┐ 
 │       Alice Bellefeuille  Grace Hundertmark  Diogo C.  Riley Kitchen       │ 
 │              Evan Arsenault  Neil Mccuaig  Ari Urrahman                    │ 
 │                                                                            │ 
 │                    Special Thanks to Raphael Tetreault                     │ 
 └────────────────────────────────────────────────────────────────────────────┘ 
    │         │          │                                │           │         
   ││  ──    ││         │││──  ▓▓▓▓▓  ▒▒▒▒▒  ░░░░         ││          │         
   │         ││      │  │││    ▓▓▓▓▓  ▒▒▒▒▒  ░░░░░        ││         ││    │    
───│││────────│─────│────│───  ▓▓▓▓▓  ▒▒▒▒▒  ░░░░░  ──────│───────────││────────
    ││        │          │     ▓▓▓▓▓  ▒▒▒▒▒  ░░░░░        │           ││        
    │      ─  │          │     ▓▓▓▓▓  ▒▒▒▒▒  ░░░░░    ─   │           │         
  ─││    ─    ││         │     ▓▓▓▓▓  ▒▒▒▒▒  ░░░░░        │       │   ││        
   │      │    │         ││                               ││           │  ─     
                                                                                
     ███████████    ███████   █      █   ▀▀▀▀▀▀▀█▄  █▌   █▌   ▐█   █    ▄█▀     
     █▌   ▐█   ▐█  █▌     ▐█  █▄▄▄▄▄▄█   ▄▄▄▄▄▄▄██  █▌   █▌   ▐█   █  ▄█▀       
     █▌   ▐█   ▐█  █▌     ▐█  █▀▀▀▀▀▀█  █▀      ██  █▌   █▌   ▐█   █▄█▀▀▄       
     █▌   ▐█   ▐█   ███████   █      █  ▀█▄▄▄▄▄▄██   ███████████   █▀    █▄     
                                                                                
                                                              C O L L E G E     ", ConsoleColor.Green, ConsoleColor.Black);
        ColoredText scoreboard = new ColoredText(@" │  ██╗  ██╗██╗ ██████╗ ██╗ │██╗    ███████╗ ██████╗ ██████╗ ██████╗ ███████╗│  
 │  ██║  ██║██║██╔════╝ ██║ │██║    ██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝││ 
 │  ███████║██║██║  ███╗███████║    ███████╗██║     ██║   ██║██████╔╝█████╗  ││ 
 │  ██╔══██║██║██║   ██║██╔══██║    ╚════██║██║     ██║   ██║██╔══██╗██╔══╝  │  
─│──██║──██║██║╚██████╔╝██║─│██║────███████║╚██████╗╚██████╔╝██║│─██║███████╗│──
 │  ╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝ │╚═╝    ╚══════╝ ╚═════╝│╚═════╝ ╚═╝│ ╚═╝╚══════╝│  
 │           ││             │           │           │           │            │  
 │           │        ╔════════════════════════════════╗       ││           ││  
││           │        ║                                ║       ││            │  
│            │        ║     00000            00000     ║       ││           ││  
│────────────│────────║                                ║ ──────││───────────││──
│            │        ║     00000            00000     ║        │           ││  
│            │        ║                                ║        │            │  
││           ││       ║     00000            00000     ║        │            │  
 │            │       ║                                ║        │            ││ 
 │            │       ║     00000            00000     ║        │            ││ 
─│────────────│───────║                                ║ ───────│────────────││─
 │           ││       ║     00000            00000     ║        │            ││ 
 │           │        ║                                ║        ││           │  
 │           ││       ╚════════════════════════════════╝         │           │  
 │            │            ││           │           ││          ││           │  
 │            │            ││           │           ││          ││           │  
─│────────────│────────────││───────────│───────────│───────────│────────────│──
 │            │             │           │           │           │           ││  
 │            │             │           ││          │           │           ││  ", ConsoleColor.DarkGray, ConsoleColor.Black);
        ColoredText heart = new ColoredText("❤",ConsoleColor.Red,ConsoleColor.Black);
        bool gameStart = false;
        bool gameStart2 = false;

        bool gameover1 = false;
        bool gameover2 =  false;
        //List<string> PASSWORDS = new List<string>() { "Cardstock", "bookworm", "Cheesecake", "Passwords", "pass123", "glowShift", "mintLeaf", "H@ppy", "Temporary", "12345678910", "bweh", ":3" };
        List<string> Passwords = new List<string>() { };

        List<List<List<List<string>>>> BeyondGodsSight = new List<List<List<List<string>>>>(); // why the fuck would they let me do this

        List<List<string>> PasswordsMasterList = new List<List<string>>(){
            new List<string>() {"@BCD3", "Flashlight!234", "Flower@-pedal", "red-machine", "Mock?up", "Money$", "w-w-wgo", "#blessed","$h@z@m"},//special
        new List<string>() {"mineBlocks", "winterSeason", "pizzaSlice", "theMaker", "glowDust", "tomCruise", "tomHanks", "greenLight", "monsterJam", "raceTrack" },//camelcase
        new List<string>() {"Elephant", "Pineapple", "Harmony", "Boat", "Ghost", "Diamond", "Obsidian", "Tools", "Free", "Planet", "Security", "Clothes", "Championship", "Organization", "Combination", "Nature", "Soupman" },//uppercase
        new List<string>() {"rainbow", "coffee", "pizza", "pasta", "power", "game", "sky", "terminator", "wolf", "dog", "manner", "sphere", "investigate", "demonstrate", "acknowledge", "communicate", "characterize"},//lowercase
        new List<string>() {"815", "18984", "7585", "1954", "29857", "720", "10587", "7536", "1234", "2005", "3078", "7510", "8213","3","6789","01134"}//numerical
        };

        string lastTyped = null; // last thing typed in keyboard
        string lasttxt = "";
        string lastInput = string.Empty;

        int lastTime = 0; // last time a byte was added
        int wave = 0;
        int waveProgress; // how far the waves have progressed
        int waveMax = 5; // max wave
        int lives = 3;
        int consoleToatal = 2;
        int consolenum = 0;
        int listNum = 5; // todo listnum tech
        float lastByteTime = 0;
        int listPhase = 0;
        int lastPassReset = 0;

        public void passwordReset()
        {
            lastPassReset = wave;
            Passwords.Clear();
            switch (listPhase)
            {
                case 0:
                    if (listNum > 1)
                    {
                        listNum = listNum - 1;
                    }
                    else
                    {
                        listPhase++;
                        listNum = 4;
                    }
                    foreach (string passworded in PasswordsMasterList[listNum])
                    {
                        Passwords.Add(passworded);
                    }
                    return;
                case 1:
                    if (listNum > 0)
                    {
                        listNum = listNum - 1;
                    }
                    else
                    {
                        listPhase++;
                        listNum = 3;
                    }
                    foreach (string passworded in PasswordsMasterList[4])
                    {
                        Passwords.Add(passworded);
                    }
                    foreach (string passworded in PasswordsMasterList[listNum])
                    {
                        Passwords.Add(passworded);
                    }
                    return;
                case 2:
                    foreach (string passworded in PasswordsMasterList[0])
                    {
                        Passwords.Add(passworded);
                    }
                    foreach (string passworded in PasswordsMasterList[1])
                    {
                        Passwords.Add(passworded);
                    }
                    foreach (string passworded in PasswordsMasterList[2])
                    {
                        Passwords.Add(passworded);
                    }
                    foreach (string passworded in PasswordsMasterList[3])
                    {
                        Passwords.Add(passworded);
                    }
                    foreach (string passworded in PasswordsMasterList[4])
                    {
                        Passwords.Add(passworded);
                    }
                    return;
            }
        }
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

            for(int y = 0; y < 10; y++)
            {
                highScores[0, y] = "00000";
                highScores[1, y] = "abc";
            }


 
            passwordReset();
        }
        // Execute() runs based on Program.TerminalExecuteMode (assign to it in Setup).
        //  ExecuteOnce: runs only once. Once Execute() is done, program closes.
        //  ExecuteLoop: runs in infinite loop. Next iteration starts at the top of Execute().
        //  ExecuteTime: runs at timed intervals (eg. "FPS"). Code tries to run at Program.TargetFPS.
        //               Code must finish within the alloted time frame for this to work well.
        
        public void Execute()
        {
            if (!gameover1)
            {

                if (!gameStart)
                { //setup
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
                { //offscreen
                    Terminal.ForegroundColor = ConsoleColor.Green;
                    map.Poke(2, 23, refresh);
                    Terminal.SetCursorPosition(3, 23);
                    Input.TextKiller();
                }

            }
            else if (!gameover2)
            {
                Terminal.CursorVisible = false;
                Console.Clear();
                map.Poke(0, 0, Gameoverrfucker);

                gameover2 = true;
                
                Thread.Sleep(4500);
                // scoreboard
                Terminal.CursorVisible = false;
                Console.Clear();
                map.Poke(0, 0, credits);

                gameover2 = true;
                /*
                Thread.Sleep(7000);
                // scoreboard
                
                Terminal.CursorVisible = false;
                Console.Clear();
                map.Poke(0, 0, scoreboard);

                gameover2 = true;
                */
            }
            else
            {
                
                //scoreboard shit

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
            Thread.Sleep(1);
            Input.TextKiller();
            lastTyped = null;
            map.Poke(0, 0, instructions);

            while (!gameStart2)
            {
                if (lastTyped != null)
                {
                    Terminal.ClearLine();
                    gameStart2 = true;
                }

            }
            Terminal.CursorVisible = true;
            Time.Start();
            map.Poke(0, 0, Ui);
            map.Poke(12, 1, new ColoredText(scoreBor.pointTotal.ToString(), ConsoleColor.Green, ConsoleColor.Black));
            heartdraw();
            Console.ForegroundColor = ConsoleColor.Green;
            Terminal.SetCursorPosition(43, 1);
            Terminal.Write(wave + 1);
            Terminal.SetCursorPosition(3, 23);
            Input.TextKiller();
            refresh.fgColor = ConsoleColor.Green;
            waveMax = 5 + wave * Random.Integer(1, 3);
            lastByteTime = Time.ElapsedSeconds;
        }
        void heartdraw()
        {
            map.Poke(72, 1, new ColoredText("     "));
            for (int i = 0; i < lives; i++)
            {
                
                map.Poke(72 + i * 2, 1, heart);
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
                        
                        consoleToatal++;

                        scoreBor.ScoreAdd(Bytes[i]);
                        map.Poke(12, 1, new ColoredText(scoreBor.pointTotal.ToString(), ConsoleColor.Green, ConsoleColor.Black));
                        if (Bytes[i].byteWindow == 0)
                        {
                            map.Poke(3, 16, refresh2);
                        }
                        else if (Bytes[i].byteWindow == 1)
                        {
                            map.Poke(3, 17, refresh2);
                        }
                        else
                        {
                            map.Poke(3, 18, refresh2);
                        }
                        Bytes[i] = null;
                        /*
                        foreach (ByteClass bitt in Bytes)
                        {
                            if (bitt != null)
                            {
                                bitt.stupidFunctionThatIHate();

                            }


                        }
                        */
                        Terminal.SetCursorPosition(termtemp, 23); // FIX
                    }
                }
            }

            /*
            if (lastInput == "add")
            { // debugging, remove later.
                wave++;
                Terminal.SetCursorPosition(43, 1);
                Terminal.Write(wave + 1);
                if (wave < lastPassReset + 1)
                {
                    passwordReset();
                    lastPassReset = wave;
                }
                Terminal.SetCursorPosition(termtemp, 23);
                //ByteAdd();

            }
            */
            
            lastInput = null;
        }
        

        void TimerJunk()
        {
            int termtemp = Terminal.CursorLeft;
            lastTime = Time.ElapsedSecondsWhole;
            // byte spawn code 
            
            if (lastByteTime + (9.0 - (0.3 * wave)) < Time.ElapsedSeconds)
            {
                
                ByteAdd();
                lastByteTime = Time.ElapsedSeconds;
                waveProgress++;
                
                if (waveProgress > waveMax) // Spawn time will start at 10 second intervals, decreases by 0.33 seconds each round (Wave 30 is when there's absolutely no cooldown)
                {
                    waveMax = 5 + wave * Random.Integer(1, 3);
                    wave++;
                    waveProgress = 0;
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
                        if (Bytes[i].byteWindow == 0)
                        {
                            map.Poke(3, 16, refresh2);
                        }
                        else if (Bytes[i].byteWindow == 1)
                        {
                            map.Poke(3, 17, refresh2);
                        }
                        else
                        {
                            map.Poke(3, 18, refresh2);
                        }
                            lives -= 1;
                            consoleToatal++;
                        if (lives != 0)
                        {
                            heartdraw();

                            Bytes[i] = null;
                            

                            int[,] evilSort = new int[3, 2];
                            int[] evilSort2 = new int[3];
                            /*
                            for (int x = 0; x < 3; x++)
                            {
                                if (Bytes[x] != null)
                                {
                                    
                                    Bytes[x].stupidFunctionThatIHate();

                                }
                            }
                            */
                            

                            /*
                        for (int y = 0; y < 3; y++)
                        {
                            if (evilSort[x,0] > Bytes[y].TimeBorn)
                            {
                                //evilSort[x,1]
                            }
                        }
                            */


                        }
                        else //out of lives
                        {
                            gameover1 = true;
                        }
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
                
                if (wave> lastPassReset+1)
                {
                    passwordReset();
                }
                int tempConsole = consoleToatal-consolenum;
                consolenum++;
                Bytes[window] = new ByteClass(type, window, tempPass, tempConsole);
                //sets colour
                Terminal.ForegroundColor = Bytes[window].newcol;
                Bytes[window].byte1.fgColor = Bytes[window].newcol;

                //drawbyte
                map.Poke(Bytes[window].xPos, 3, Bytes[window].byte1);

                Terminal.ForegroundColor = ConsoleColor.Green;
                
                Terminal.SetCursorPosition(Bytes[window].xPos - 3, 17);

                foreach (ByteClass bitt in Bytes)
                {
                    if (bitt != null)
                    {
                        bitt.ConsoleWriter();
                    }
                    
                }
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
