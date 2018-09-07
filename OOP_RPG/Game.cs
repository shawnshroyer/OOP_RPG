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
            Console.WriteLine("Hello " + Hero.Name);
            this.MainMenu();
        }
        
        public void MainMenu() {
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Hero Menu");
            Console.WriteLine("5. Shop");
            var input = Console.ReadLine();

            //if (input == "1") {
            //    this.Stats();
            //}
            //else if (input == "2") {
            //    this.Inventory();
            //}
            //else if (input == "3") {
            //    this.Fight();
            //}
            //else {
            //    return;
            //}

            switch (input)
            {
                case "1":
                    this.Stats();
                    break;
                case "2":
                    this.Inventory();
                    break;
                case "3":
                    this.Fight();
                    break;
                case "4":
                    Hero.HeroMenu();
                    break;
                case "5":
                    Shop.ShopMenu();
                    break;
                default:
                    this.MainMenu();
                    break;
            }
            this.MainMenu();
        }
        
        public void Stats() {
            Hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.MainMenu();
        }
        
        public void Inventory() {
            Hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.MainMenu();
        }
        
        public void Fight() {
            var fight = new Fight(this.Hero, this, this.Monster);
            fight.Start();
        }
    }
}