using System;
using System.Collections.Generic;
using System.Threading;

namespace MohawkTerminalGame
{
    /// <summary>
    ///     Input related functions.
    /// </summary>
    public static class Input
    {
        private readonly static Thread InputThread;
        public static string CurrentText { get; private set; } = string.Empty;

        public static event Action<string> OnCharacterTyped;
        public static event Action<string> OnEnterPressed;
        private readonly static List<ConsoleKey> CurrentFrameKeys = [];
        private readonly static List<ConsoleKey> LastFrameKeys = [];

        /// <summary>
        ///     Called to reset current frame inputs.
        ///     Don't call this unless you have a reason to.
        /// </summary>
        internal static void PreparePollNextInput()
        {
            LastFrameKeys.Clear();
            LastFrameKeys.AddRange(CurrentFrameKeys);
            CurrentFrameKeys.Clear();
        }

        /// <summary>
        ///     Called to reset current frame inputs.
        ///     Don't call this unless you have a reason to.
        /// </summary>

        public static bool IsKeyPressed(ConsoleKey key)
        {
            // Pressed if currently pressed down but was previously unpressed
            bool state = CurrentFrameKeys.Contains(key) && !LastFrameKeys.Contains(key);
            return state;
        }
        public static void TextKiller()
        {
            CurrentText = string.Empty;
        }

        /// <summary>
        ///     Initialize background input thread.
        /// </summary>
        internal static void InitInputThread()
        {
            // Only run once
            if (InputThread != null)
                return;

            CreateInputThread();
        }

        private static Thread CreateInputThread()
        {
            if (InputThread != null)
            {
                string msg = "Input thread already exists!";
                throw new Exception(msg);
            }

            static void ThreadPollKeyboard()
            {
                while (true)
                {
                    if (Program.TerminalInputMode != TerminalInputMode.EnableInputDisableReadLine)
                        continue;

                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                    if (consoleKeyInfo.Key != ConsoleKey.None)
                    {
                        CurrentFrameKeys.Add(consoleKeyInfo.Key);
                    }

                    char c = consoleKeyInfo.KeyChar;

                    if (c == '\r')
                    {
                        OnEnterPressed?.Invoke(CurrentText);
                        CurrentText = string.Empty;
                    }
                    else if (c == '\b' && CurrentText.Length > 0)
                    {
                        CurrentText = CurrentText[..^1];
                        OnCharacterTyped?.Invoke(CurrentText);
                    }
                    else if (char.IsAscii(c))
                    {
                        CurrentText += c;
                        OnCharacterTyped?.Invoke(CurrentText);
                    }

                }
            }

            Thread inputThread = new(ThreadPollKeyboard);
            inputThread.Priority = ThreadPriority.Highest;
            inputThread.Start();
            return inputThread;
        }
    }
}