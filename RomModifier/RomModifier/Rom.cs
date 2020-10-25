using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomModifier
{
    public static class Rom
    {
        public static string filePath;
        public static long OFFSET_Poke;// = 0xF186E0;
        //public static long OFFSET_Skill_II = 0x1D52DDC;
        //public static long OFFSET_Skill_III = 0x1D58038;
        public static long OFFSET_Skill;// = OFFSET_Skill_III;

        public static void SetRomPath(string filePath)
        {
            Rom.filePath = filePath;
            OFFSET_Poke = 0xF186E0;
            //获取技能的地址
            byte[] addr = new byte[4];
            addr[0] = Util.ReadByte(filePath, 0x1cc);
            addr[1] = Util.ReadByte(filePath, 0x1cd);
            addr[2] = Util.ReadByte(filePath, 0x1ce);
            addr[3] = 0x01;
            OFFSET_Skill = BitConverter.ToInt32(addr, 0);
        }

        //读取种族值
        public static BreedValue ReadBreedValue(int num)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            BreedValue bv = new BreedValue();
            bv.HP = Util.ReadByte(Rom.filePath, offset + 00L);
            bv.ATK = Util.ReadByte(Rom.filePath, offset + 01L);
            bv.DEF = Util.ReadByte(Rom.filePath, offset + 02L);
            bv.SPEED = Util.ReadByte(Rom.filePath, offset + 03L);
            bv.SPATK = Util.ReadByte(Rom.filePath, offset + 04L);
            bv.SPDEF = Util.ReadByte(Rom.filePath, offset + 05L);
            return bv;
        }
        //读取属性
        public static Type ReadType(int num)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            Type type = new Type();
            type.type1 = Util.ReadByte(Rom.filePath, offset + 06L);
            type.type2 = Util.ReadByte(Rom.filePath, offset + 07L);
            return type;
        }
        //读取特性
        public static Ability ReadAbility(int num)
        {
            Ability ab = new Ability();
            long offset = OFFSET_Poke + 0x1C * num;
            ab.ab1 = Util.ReadByte(Rom.filePath, offset + 22L);
            ab.ab2 = Util.ReadByte(Rom.filePath, offset + 23L);
            ab.ab3 = Util.ReadByte(Rom.filePath, offset + 26L);
            return ab;
        }
        //读取其他
        public static Other ReadOther(int num)
        {
            Other other = new Other();
            long offset = OFFSET_Poke + 0x1C * num;
            other.levelUpSpeed = Util.ReadByte(Rom.filePath, offset + 19L); 
            other.eggGroup1 = Util.ReadByte(Rom.filePath, offset + 20L);
            other.eggGroup2 = Util.ReadByte(Rom.filePath, offset + 21L);
            other.sexRate = Util.ReadByte(Rom.filePath, offset + 16L);
            other.incubationCycle = Util.ReadByte(Rom.filePath, offset + 17L);
            other.initIntimate = Util.ReadByte(Rom.filePath, offset + 18L);
            other.catchRate = Util.ReadByte(Rom.filePath, offset + 08L);
            other.catchExp = Util.ReadByte(Rom.filePath, offset + 09L);
            return other;
        }

        //写入种族值
        public static void WriteBreedValue(int num,BreedValue bv)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            Util.WriteByte(Rom.filePath, offset + 00L, bv.HP);
            Util.WriteByte(Rom.filePath, offset + 01L, bv.ATK);
            Util.WriteByte(Rom.filePath, offset + 02L, bv.DEF);
            Util.WriteByte(Rom.filePath, offset + 03L, bv.SPEED);
            Util.WriteByte(Rom.filePath, offset + 04L, bv.SPATK);
            Util.WriteByte(Rom.filePath, offset + 05L, bv.SPDEF);
        }
        //写入属性
        public static void WriteType(int num,Type type)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            Util.WriteByte(Rom.filePath, offset + 06L, type.type1);
            Util.WriteByte(Rom.filePath, offset + 07L, type.type2);
        }
        //写入特性
        public static void WriteAbility(int num,Ability ab)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            Util.WriteByte(Rom.filePath, offset + 22L, ab.ab1);
            Util.WriteByte(Rom.filePath, offset + 23L, ab.ab2);
            Util.WriteByte(Rom.filePath, offset + 26L, ab.ab3);
        }
        //写入其他(带combo)
        public static void WriteOtherCombo(int num,Other other)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            Util.WriteByte(Rom.filePath,offset + 19L,other.levelUpSpeed);
            Util.WriteByte(Rom.filePath, offset + 20L, other.eggGroup1);
            Util.WriteByte(Rom.filePath, offset + 21L, other.eggGroup2);
        }
        //写入其他(无combo)
        public static void WriteOtherNoCombo(int num,Other other)
        {
            long offset = OFFSET_Poke + 0x1C * num;
            Util.WriteByte(Rom.filePath, offset + 16L, other.sexRate);
            Util.WriteByte(Rom.filePath, offset + 17L, other.incubationCycle);
            Util.WriteByte(Rom.filePath, offset + 18L, other.initIntimate);
            Util.WriteByte(Rom.filePath, offset + 08L, other.catchRate);
            Util.WriteByte(Rom.filePath, offset + 09L, other.catchExp);
        }

    }
}
