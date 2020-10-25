using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomModifier
{
    public class UsingClass
    {

    }
    public class BreedValue
    {
        public byte HP;
        public byte ATK;
        public byte DEF;
        public byte SPEED;
        public byte SPATK;
        public byte SPDEF;
        public BreedValue()
        {
            this.HP = this.ATK = this.DEF = this.SPATK = this.SPDEF = this.SPEED = 0x00;
        }
    }
    
    public class Type
    {
        public byte type1;
        public byte type2;
        public Type()
        {
            this.type1 = this.type2 = 0;
        }
    }

    public class Ability
    {
        public byte ab1;
        public byte ab2;
        public byte ab3;
        public Ability()
        {
            this.ab1 = this.ab2 = this.ab3 = 0;
        }
    }

    public class Other
    {
        public byte levelUpSpeed;
        public byte eggGroup1;
        public byte eggGroup2;
        public byte sexRate;
        public byte incubationCycle;
        public byte initIntimate;
        public byte catchRate;
        public byte catchExp;
        public Other()
        {
            this.levelUpSpeed = this.eggGroup1 = this.eggGroup2 = this.sexRate = this.incubationCycle = this.initIntimate = this.catchRate = this.catchExp = 0;
        }
    }

    public class Skill
    {
        public byte power;
        public byte type;
        public byte rate;
        public byte PP;
        public byte priority;
        public byte style;
        
        public Skill()
        {
            this.power = this.type = this.rate = this.PP = this.priority = this.style = 0;
        }
    }

}
