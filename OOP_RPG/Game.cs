using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }
        public Shop Shop { get; set; }

        public Game() {
            this.Hero = new Hero(this);
            this.Monster = new Monster();
            this.Shop = new Shop(this);
        }
            
        public void Start() {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");
            this.Hero.Name = Console.ReadLine();
            Console.WriteLine($"\nHello {Hero.Name}");
            this.MainMenu();
        }
        
        public void MainMenu() {
            Console.WriteLine("\nPlease choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Hero Menu");
            Console.WriteLine("5. Shop");
            Console.WriteLine("6. Exit Game");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    this.Stats();
                    break;
                case "2":
                    Console.Clear();
                    this.Inventory();
                    break;
                case "3":
                    Console.Clear();
                    this.Fight();
                    break;
                case "4":
                    Console.Clear();
                    Hero.HeroMenu();
                    break;
                case "5":
                    Console.Clear();
                    Shop.ShopMenu();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    this.MainMenu();
                    break;
            }
            Console.Clear();
            this.MainMenu();
        }
        
        public void Stats() {
            Hero.ShowStats();
            this.MainMenu();
        }
        
        public void Inventory() {
            Hero.ShowInventory();
            this.MainMenu();
        }
        
        public void Fight() {
            var fight = new Fight(this.Hero, this, this.Monster);
            fight.Start();
        }
    }
}