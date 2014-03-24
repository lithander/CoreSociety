using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using CoreSociety.Properties;

namespace CoreSociety
{
    public class Core
    {
        public enum Focus
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3,
            Self = 4
        }
        //MEMORY
        public ushort[] Data = new ushort[256];
        public Indexer<ushort> Memory
        {
            get { return new Indexer<ushort>(Data, 16); }
        }
        //INSTRUCTION POINTER
        public byte InstructionPointer = 0;
        //FOCUS
        public Focus Target = Focus.Self;
        //ENERGY
        public byte Energy = 0;
        public byte Shield = 0;
        public byte Charge = 0;
    }

    public static class CoreTransform
    {
        public static void ClearMemory(this Core core)
        {
            for (short i = 0; i < 256; i++)
                core.Memory[i] = 0;
        }

        public static IEnumerable<byte> GetBytes(this Core core)
        {
            //data
            foreach (ushort word in core.Data)
                foreach(byte b in BitConverter.GetBytes(word))
                    yield return b;
            //ip
            yield return core.InstructionPointer;
            //focus target
            yield return (byte)core.Target;
            //energy
            yield return core.Energy;
            yield return core.Shield;
            yield return core.Charge;
        }
        public static void SetBytes(this Core core, byte[] data)
        {
            BinaryReader reader = new BinaryReader(new MemoryStream(data));
            //data
            for (int i = 0; i < core.Data.Length; i++)
                core.Data[i] = reader.ReadUInt16();
            //ip
            core.InstructionPointer = reader.ReadByte();
            //focus target
            core.Target = (Core.Focus)reader.ReadByte();
            //energy
            core.Energy = reader.ReadByte();
            core.Shield = reader.ReadByte();
            core.Charge = reader.ReadByte();
        }

        public static string Encode(this Core core)
        {
            return System.Convert.ToBase64String(GetBytes(core).ToArray());
        }

        public static void Decode(this Core target, string data)
        {
            SetBytes(target, System.Convert.FromBase64String(data));
        }
    }
}
