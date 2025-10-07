using MohawkTerminalGame;
using Raylib_cs;
using System;

public class ByteClass
{
    ColoredText bytee = new("------\v\b\b\b\b\b\b" +
            "| [] |\v\b\b\b\b\b\b" +
            "------", ConsoleColor.Gray, ConsoleColor.DarkGray);
    int[] byte1 = [];
    int[] byte2 = [35, 12];
    int[] byte3 = [56, 8];
    public ByteClass(int xPosition, int yPosition)
	{
		
	}
	public void byteDraw()
	{
        //map.Poke(byte1[0], byte1[1], bytee);
        //map.Poke(byte2[0], byte2[1], bytee);
        //map.Poke(byte3[0], byte3[1], bytee);
    }
}
