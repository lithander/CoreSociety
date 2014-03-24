using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoreSociety
{
    public enum Opcode
    {
        NOP = 0x0000,
        //Group 0x1 - Basic Memory Operations
        INC = 0x1000,
        DEC = 0x1200,
        NOT = 0x1400,
        RND = 0x1600,
        SQT = 0x1800,
        //Group 0x2 - Copy
        SET = 0x2000,
        RDW = 0x2400,
        STW = 0x2800,
        //Group 0x3	- Basic Arithmetic
        ADD = 0x3000,
        SUB = 0x3400,
        MUL = 0x3800,
        DIV = 0x3C00,
        //Group 0x4	- Additional Arithmetic
        MOD = 0x4000,
        MAX = 0x4400,
        MIN = 0x4800,
        //Group 0x5	- Basic Logical
        AND = 0x5000,
        IOR = 0x5400,
        XOR = 0x5800,
        //Group 0x6 - Basic Conditional
        IFZ = 0x6000,
        IFS = 0x6200,
        IFR = 0x6400,
        //Group 0x7 - Conditional
        IFE = 0x7000,
        IFN = 0x7400,
        IFG = 0x7800,
        IFL = 0x7C00,
        //Group 0x8 - Jump & Goto
        JMP = 0x8000,
        NXT = 0x8200,
        SIP = 0x8400,
        //Group 0x9 - Query
        QIP = 0x9000,
        QUE = 0x9200,
        QSE = 0x9400,
        QCE = 0x9600,
        QTC = 0x9800,
        //Group 0xA - Modes
        TGT = 0xA000,
        //Group 0xB - Energy
        RSV = 0xB000,
        ISE = 0xB200,
        DSE = 0xB400,
        BST = 0xB600,
        WKN = 0xB800,
        //GROUP 0xC - Score
        ISC = 0xC000,
        DSC = 0xC200
    }

    public class Instruction
    {
        public static Dictionary<string, Opcode> Mnemonics = new Dictionary<string, Opcode>()
        {
            {"NOP", Opcode.NOP},
            {"INC", Opcode.INC},
            {"DEC", Opcode.DEC},
            {"NOT", Opcode.NOT},
            {"RND", Opcode.RND},
            {"SQT", Opcode.SQT},
            {"SET", Opcode.SET},
            {"RDW", Opcode.RDW},
            {"STW", Opcode.STW},
            {"ADD", Opcode.ADD},
            {"SUB", Opcode.SUB},
            {"MUL", Opcode.MUL},
            {"DIV", Opcode.DIV},
            {"MOD", Opcode.MOD},
            {"MAX", Opcode.MAX},
            {"MIN", Opcode.MIN},
            {"AND", Opcode.AND},
            {"OR" , Opcode.IOR},
            {"IOR", Opcode.IOR},
            {"XOR", Opcode.XOR},
            {"IFZ", Opcode.IFZ},
            {"IFS", Opcode.IFS},
            {"IFR", Opcode.IFR},
            {"IFE", Opcode.IFE},
            {"IFN", Opcode.IFN},
            {"IFG", Opcode.IFG},
            {"IFL", Opcode.IFL},
            {"JMP", Opcode.JMP},
            {"NXT", Opcode.NXT},
            {"SIP", Opcode.SIP},
            {"QIP", Opcode.QIP},
            {"QUE", Opcode.QUE},
            {"QSE", Opcode.QSE},
            {"QCE", Opcode.QCE},
            {"QTC", Opcode.QTC},
            {"TGT", Opcode.TGT},
            {"RSV", Opcode.RSV},
            {"ISE", Opcode.ISE},
            {"DSE", Opcode.DSE},
            {"BST", Opcode.BST},
            {"WKN", Opcode.WKN},
            {"ISC", Opcode.ISC},
            {"DSC", Opcode.DSC},
        };

        public static string GetMnemonic(Opcode opcode)
        {
            return Mnemonics.Where(kvp => kvp.Value == opcode).First().Key;
        }

        public static ushort TARGET_NO_ADDRESS = 0x0100;
        public static ushort PARAM_NO_NUMERAL = 0x0200;

        public int LineNumber = -1;
        public ushort InstructionWord = (ushort)Opcode.NOP;
        public ushort ParamWord = 0;
        public bool HasParam = false;
        public Opcode OpCode = Opcode.NOP;
    }
}
