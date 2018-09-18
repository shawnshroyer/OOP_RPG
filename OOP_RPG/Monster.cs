using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Speed { get; set; }
        public int Gold { get; set; }

        public Monster() {
            this.Name = "Gizzmo";
            this.Strength = 5;
            this.Defense = 5;
            this.OriginalHP = 10;
            this.CurrentHP = 10;
            this.Speed = 10;
            this.Gold = 5;

            //TODO: Remove monsters from fight and move logic here.
            //TODO: Generate Random monster list to use in fight
        }

        public Monster(string name, int strength, int defense, int hp, int speed) {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHP = hp;
            this.CurrentHP = hp;
            this.Speed = speed;
            this.Gold = 5;
        }
    }
}