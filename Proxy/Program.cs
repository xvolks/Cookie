using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program
{
    private static int GLOBAL_INSTANCE_ID = 0;
    private static int Tester = 0;
    static void Main(string[] args)
    {
        //byte[] vs = { 0x00, 0x2D, 0xDE, 0x9B, 0x01, 0x00 };
        //FastBigEndianReader r = new FastBigEndianReader(vs);
        //MemoryStream m = new MemoryStream(vs);
        //ushort header = r.ReadUShort();
        //Debug.WriteLine("MessageId[{0}]", header >> 2 );
        //Debug.WriteLine("HeaderType[{0}]", header & 3 );
        //int Lenght = 0;
        //for (int i = (header & 3) - 1; i >= 0; i--)
        //    Lenght |= m.ReadByte() << (i * 8);
        //Debug.WriteLine("MessageLenght[{0}]", Lenght);

        //ushort test = (ushort)0x00;
        //Debug.WriteLine(ushort.MaxValue);
        //byte Type = unchecked((byte)-1);
        Console.Write(sizeof(byte));
        Console.ReadLine();
    }
    static void Test()
    {
        Tester = ++GLOBAL_INSTANCE_ID;
    }
}