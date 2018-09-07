using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Monster Enemy { get; set; }
        public Game Game { get; set; }
        public Hero Hero { get; set; }
        
        public Fight(Hero hero, Game game, Monster enemy) {
            this.Monsters = new List<Monster>();
            this.Enemy = enemy;
            this.Hero = hero;
            this.Game = game;
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Goblin", 10, 10, 10);
            this.AddMonster("Ghost", 5, 2, 2);
            this.AddMonster("Ghoul", 15, 15, 8);
        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            //var monster = new Monster();
            //monster.Name = name;
            //monster.Strength = strength;
            //monster.Defense = defense;
            //monster.OriginalHP = hp;
            //monster.CurrentHP = hp;
            //this.Monsters.Add(monster);

            this.Monsters.Add(new Monster(name, strength, defense, hp));
        }
        
        public void Start() {
            //var enemy = this.Monsters[0];
            //var rnd = new Random();
            //var enemy = this.Monsters[new Random().Next(this.Monsters.Count)];
            Console.WriteLine("You've encountered a " + Enemy.Name + "! " + Enemy.Strength + " Strength/" + Enemy.Defense + " Defense/" +
            Enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn();
            }
            else { 
                this.Game.MainMenu();
            }
        }
        
        public void HeroTurn(){
            //var enemy = this.Enemy;
           var compare = Hero.Strength - Enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               Enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
                Enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(Enemy.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn() {
           var enemy = this.Enemy;
           int damage;
           var compare = enemy.Strength - Hero.Defense;
           if(compare <= 0) {
               damage = 1;
               Hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               Hero.CurrentHP -= damage;
           }
           Console.WriteLine(enemy.Name + " does " + damage + " damage!");
           if(Hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle!");
            Hero.Gold += Enemy.Gold;
            Console.WriteLine("You have won " + this.Enemy.Gold + " Gold in battle");
            Console.WriteLine("You now have " + this.Hero.Gold + " Gold in inventory");
            Game.MainMenu();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}




/*
 Currently under start, not sure I like this.

    first monster
    var enemy = this.Monsters[0];

    Fight last monster
    var enemy = this.Monsters[this.Monsters.Count -1];

    second monster
    var enemy = this.Monsters[1];

    fisrt monster with 20 hutpoints   Returns null on default
    var enemy = this.Monsters.FirstOrDefault(m => m.CurrentHP < 20);


 */
