using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Potion : IItem
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Potion() { }

        public Potion(string name, int hp) {
            this.Name = name;
            this.Hp = hp;
        }

        public Potion(string name, int hp, int originalValue, int resellValue)
        {
            this.Name = name;
            this.Hp = hp;
            this.OriginalValue = originalValue;
            this.ResellValue = resellValue;
        }
    }
}
