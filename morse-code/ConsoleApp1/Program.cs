using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ABER ABER";

            string morseCode = "";

            morseCode = TextToMorseCode(s);

            Console.WriteLine(s);
            Console.WriteLine(morseCode);

            MorseCodeToLamp(morseCode, 50);

            Console.ReadLine();
        }

        static string TextToMorseCode(string text)
        {
            string morse = "";

            for (int i = 0; i < text.Length; i++)
            {
                morse = morse + CharToMorseString(text[i]);

                if(text[i] == ' ')
                {
                    morse = morse + "/";
                }
                else
                {
                    morse = morse + "_";
                }
            }

            return morse;
        }

        static string CharToMorseString(char c)
        {
            if (c == 'A')
            {
                return ".-";
            }
            if (c == 'B')
            {
                return "- . . .";
            }
            if (c == 'E')
            {
                return ".";
            }
            if (c == 'R')
            {
                return ". - .";
            }

            return "";
        }

        static void MorseCodeToSpeaker(string morseText, int freq, int time)
        {
            //Console.Beep(300, 50);

            for (int i = 0; i < morseText.Length; i++)
            {
                if(morseText[i] == '.')
                {
                    Console.Beep(freq, time);
                }
                if (morseText[i] == '-')
                {
                    Console.Beep(freq, time*3);
                }
                if (morseText[i] == ' ')
                {
                    System.Threading.Thread.Sleep(time);
                }
                if (morseText[i] == '_')
                {
                    System.Threading.Thread.Sleep(time*3);
                }
                if (morseText[i] == '/')
                {
                    System.Threading.Thread.Sleep(time*7);
                }
            }

            static void MorseCodeToLamp(string morseText, int time)
            {
                Console.CursorVisible = false;

                for (int i = 0; i < morseText.Length; i++)
                {
                    Console.SetCursorPosition(5, 5);
                    Console.Write("███");

                    if (morseText[i] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Threading.Thread.Sleep(time);
                    }
                    if (morseText[i] == '-')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Threading.Thread.Sleep(time*3);
                    }
                }
            }
        }
    }
}
