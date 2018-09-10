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
            Console.WriteLine("\n*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Gold: " + this.Gold);

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        
        public void ShowInventory() {
            Console.WriteLine("\n*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach(var w in this.WeaponsBag){
                Console.WriteLine($"{w.Name} of {w.Strength} Strength");
            }
            if (!(EquippedWeapon.Name is null)) { Console.WriteLine($"You currently have {EquippedWeapon.Name} of {EquippedWeapon.Strength} of Strength Equipped"); }
            Console.WriteLine("Armor: ");
            foreach(var a in this.ArmorsBag){
                Console.WriteLine($"{a.Name} of {a.Defense} Defense");
            }
            if (!(EquippedArmor.Name is null)) { Console.WriteLine($"You currently have {EquippedArmor.Name} of {EquippedArmor.Defense} of Defense Equipped"); }
            Console.WriteLine("Potion: ");
            foreach (var p in this.PotionBag)
            {
                Console.WriteLine($"{p.Name} of {p.Hp} Healing");
            }

            Console.WriteLine("\nPress any key to return to continue.");
            Console.ReadKey();
        }

        public void HeroMenu()
        {
            Console.WriteLine("\nPlease choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Equip Weapon");
            Console.WriteLine("4. Equip Armor");
            Console.WriteLine("5. Unequip Weapon");
            Console.WriteLine("6. unequip Armor");
            Console.WriteLine("7. Drink Potion");
            Console.WriteLine("8. Main Menu");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    this.ShowStats();
                    break;
                case "2":
                    Console.Clear();
                    this.ShowInventory();
                    break;
                case "3":
                    Console.Clear();
                    this.EquipWeapon();
                    break;
                case "4":
                    Console.Clear();
                    this.EquipArmor();
                    break;
                case "5":
                    Console.Clear();
                    this.RemoveWeapon();
                    break;
                case "6":
                    Console.Clear();
                    this.RemoveArmor();
                    break;
                case "7":
                    Console.Clear();
                    this.DrinkPotion();
                    break;
                case "8":
                    Console.Clear();
                    Game.MainMenu();
                    break;
                default:
                    Console.Clear();
                    Game.MainMenu();
                    break;
            }
            Console.Clear();
            HeroMenu();
        }

        public void EquipWeapon() {
            if (this.EquippedWeapon.Name is null)
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
                            this.WeaponsBag.Remove(this.WeaponsBag[bagLocation - 1]);
                            this.Strength += this.EquippedWeapon.Strength;
                        }
                        else
                        {
                            Console.WriteLine($"There is nothing in this part of your bag!");
                            this.HeroMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There was an error!");
                        this.HeroMenu();
                    }
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
        
        public void EquipArmor() { //TODO: make match weapon equip
            if (this.EquippedArmor.Name is null)
            {
                if (ArmorsBag.Any())
                {
                    var count = 1;

                    foreach (var a in this.ArmorsBag)
                    {
                        Console.WriteLine($"{count}. {a.Name} of {a.Defense} Defense");
                        count++;
                    }
                    Console.WriteLine($"Which Armor would you like to equip?");

                    var select = Console.ReadLine();
                    var bagLocation = 0;

                    if (Int32.TryParse(select, out bagLocation))
                    {
                        if (this.ArmorsBag[bagLocation - 1] != null)
                        {
                            this.EquippedArmor = this.ArmorsBag[bagLocation - 1];
                            this.ArmorsBag.Remove(this.ArmorsBag[bagLocation - 1]);
                            this.Defense += this.EquippedArmor.Defense;
                        }
                        else
                        {
                            Console.WriteLine($"There is nothing in this part of your bag!");
                            this.HeroMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There was an error!");
                        this.HeroMenu();
                    }
                }
                else
                {
                    Console.WriteLine($"You currently have {EquippedArmor.Name} equipped and will have to remove it to equip new armor.");
                    this.HeroMenu();
                }
            }
            else
            {
                Console.WriteLine($"You currently have no Armor in your inventroy\nTime to get some gold and go to the store.");
                this.HeroMenu();
            }
        }

        public void RemoveWeapon()
        {
            if (!(this.EquippedWeapon.Name is null))
            {
                Console.WriteLine($"You currently have {EquippedWeapon.Name} of {EquippedWeapon.Strength} strength equipped");
                Console.WriteLine($"Would you like to remove {EquippedWeapon.Name} of {EquippedWeapon.Strength} Strength?");

                Console.Write("Yes (y) or No (n): ");
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "yes":
                    case "y":
                        this.Strength -= EquippedWeapon.Strength;
                        WeaponsBag.Add(EquippedWeapon);
                        Console.WriteLine($"Your {EquippedWeapon.Name} of {EquippedWeapon.Strength} strength has been removed.");
                        Console.WriteLine($"You are now weaker, loosing {EquippedWeapon.Strength} strength, and now have a stgrength of {this.Strength}");
                        EquippedWeapon = new Weapon();
                        break;
                    case "no":
                    case "n":
                        break;
                    default:
                        Console.WriteLine($"You have chosen an invalid option try again");
                        this.RemoveWeapon();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"You currently have no Weapon equipped and strongly recommend you equip one.");
                this.HeroMenu();
            }
        }

        public void RemoveArmor() {
            if (!(this.EquippedArmor.Name is null))
            {
                Console.WriteLine($"You currently have {EquippedArmor.Name} of {EquippedArmor.Defense} Defense equipped");
                Console.WriteLine($"Would you like to remove {EquippedArmor.Name} of {EquippedArmor.Defense} Defense?");

                Console.Write("Yes or NO: ");
                var input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "yes":
                        this.Defense -= EquippedArmor.Defense;
                        ArmorsBag.Add(EquippedArmor);
                        Console.WriteLine($"Your {EquippedArmor.Name} of {EquippedArmor.Defense} Defense has been removed.");
                        Console.WriteLine($"You are now weaker, loosing {EquippedArmor.Defense} defense, and now have a defense of {this.Defense}");
                        EquippedArmor = null;
                        break;
                    case "no":
                        break;
                    default:
                        Console.WriteLine($"You have chosen an invalid option try again");
                        this.RemoveArmor();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"You currently have no Armor equipped and strongly recommend you equip one.");
                this.HeroMenu();
            }
        }

        public void DrinkPotion()
        {
            if (this.PotionBag.Any())
            {
                var count = 1;

                foreach (var p in this.PotionBag)
                {
                    Console.WriteLine($"{count}. {p.Name} of {p.Hp} healing");
                    count++;
                }
                Console.WriteLine($"Which potion would you like to drink?");

                var select = Console.ReadLine();
                var bagLocation = 0;
                var HpDifference = this.OriginalHP - this.CurrentHP;

                if (Int32.TryParse(select, out bagLocation))
                {
                    if (this.PotionBag[bagLocation - 1] != null)
                    {
                        if (HpDifference >= this.PotionBag[bagLocation - 1].Hp) {
                            this.CurrentHP += this.PotionBag[bagLocation - 1].Hp;
                            this.PotionBag.Remove(this.PotionBag[bagLocation - 1]);
                        } else
                        {
                            if (HpDifference <= this.PotionBag[bagLocation - 1].Hp) {
                                Console.WriteLine($"You are only missing {HpDifference} health points,\n" +
                                    $"do you really want to consume {this.PotionBag[bagLocation - 1].Name} of {this.PotionBag[bagLocation - 1].Hp} healing?");

                                Console.Write("Yes or NO: ");
                                var input = Console.ReadLine();

                                switch (input.ToLower())
                                {
                                    case "yes":
                                        this.CurrentHP = this.OriginalHP;
                                        Console.WriteLine($"You consumed {this.PotionBag[bagLocation - 1].Name} of {this.PotionBag[bagLocation - 1].Hp} healing.");
                                        Console.WriteLine($"You are now at {this.CurrentHP} of {this.OriginalHP} health.");
                                        this.PotionBag.Remove(this.PotionBag[bagLocation - 1]);
                                        break;
                                    case "no":
                                        this.HeroMenu();
                                        break;
                                    default:
                                        Console.WriteLine($"You have chosen an invalid option try again");
                                        this.DrinkPotion();
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is nothing in this part of your bag!");
                        this.HeroMenu();
                    }
                }
                else
                {
                    Console.WriteLine($"There was an error!");
                    this.HeroMenu();
                }
            }
            else
            {
                    Console.WriteLine($"You currently have no Potions in your inventroy\nTime to get some gold and go to the store.");
                    this.HeroMenu();
            }
        }
    }
}