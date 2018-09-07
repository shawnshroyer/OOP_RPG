using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }

        public Game Game { get; set; }

        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }

        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionBag { get; set; }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero(Game game) {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionBag = new List<Potion>();
            this.EquippedWeapon = new Weapon();
            this.EquippedArmor = new Armor();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 100;

            this.Game = game;
        }
        
        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Gold: " + this.Gold);
        }
        
        public void ShowInventory() {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach(var w in this.WeaponsBag){
                Console.WriteLine($"{w.Name} of {w.Strength} Strength");
            }
            Console.WriteLine("Armor: ");
            foreach(var a in this.ArmorsBag){
                Console.WriteLine($"{a.Name} of {a.Defense} Defense");
            }
            Console.WriteLine("Potion: ");
            foreach (var p in this.PotionBag)
            {
                Console.WriteLine($"{p.Name} of {p.Hp} Healing");
            }
        }

        public void HeroMenu()
        {
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Equip Weapon");
            Console.WriteLine("4. Equip Armor");
            Console.WriteLine("5. Unequip Weapon");
            Console.WriteLine("6. unequip Armor");
            Console.WriteLine("7. Drink Potion");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    this.ShowStats();
                    break;
                case "2":
                    this.ShowInventory();
                    break;
                case "3":
                    this.EquipWeapon();
                    break;
                case "4":
                    this.EquipArmor();
                    break;
                case "5": //TODO add Remove Weapon
                case "6": //TODO add Remove Armor
                case "7":
                    this.DrinkPotion();
                    break;
                default:
                    Game.MainMenu();
                    break;
            }
        }

        public void EquipWeapon() {
            if (!(this.EquippedWeapon is null))
            {

                if (WeaponsBag.Any())
                {
                    var count = 1;

                    foreach (var w in this.WeaponsBag)
                    {
                        Console.WriteLine($"{count}. {w.Name} of {w.Strength} Strength");
                        count++;
                    }
                    Console.WriteLine($"Which weapon would you like to equip?");

                    var select = Console.ReadLine();
                    var bagLocation = 0;

                    if (Int32.TryParse(select, out bagLocation))
                    {
                        if (this.WeaponsBag[bagLocation - 1] != null)
                        {
                            this.EquippedWeapon = this.WeaponsBag[bagLocation - 1];
                        }
                        else
                        {
                            Console.WriteLine($"There was an error!");
                            Game.MainMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There was an error!");
                        Game.MainMenu();
                    }

    ;
                }
                else
                {
                    Console.WriteLine($"You currently have no Weapons in your inventroy\nTime to get some gold and go to the store.");
                    this.HeroMenu();
                }
            } else
            {
                Console.WriteLine($"You currently have {EquippedWeapon.Name} equipped and will have to remove it to equip new weapon.");
                this.HeroMenu();
            }
        }
        
        public void EquipArmor() {

            //TODO: Add ability to equip armor

            if(ArmorsBag.Any()) {
                this.EquippedArmor = this.ArmorsBag[0];
            }
        }

        public void DrinkPotion()
        {
            //TODO: Add ability to drink potion.
        }
        
        //TODO: Add ability to remove weapon
        //TODO: Add ability to remove armor
    }
}