using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_RPG
{
    public class Shop
    {
        public Hero Hero { get; set; }
        public Game Game { get; set; }
        public List<Weapon> WeaponList { get; set; }
        public List<Armor> ArmorList { get; set; }
        public List<Potion> PotionList { get; set; }

        private Dictionary<string, Weapon> WeaponCatalog { set; get; }
        private Dictionary<string, Armor> ArmorCatalog { set; get; }
        private Dictionary<string, Potion> PotionCatalog { set; get; }

        public Shop(Game game)
        {
            this.WeaponList = new List<Weapon>();
            this.ArmorList = new List<Armor>();
            this.PotionList = new List<Potion>();

            this.WeaponCatalog = new Dictionary<string, Weapon>();
            this.ArmorCatalog = new Dictionary<string, Armor>();
            this.PotionCatalog = new Dictionary<string, Potion>();

            this.Game = game;
            this.Hero = game.Hero;

            StockShop();
        }

        public void ShopMenu()
        {
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. Buy Item");
            Console.WriteLine("2. Sell Item");
            Console.WriteLine("3. View Hero Inventory");
            Console.WriteLine("4. Return to Main Menu");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    this.BuyGoods();
                    break;
                case "2":
                    this.SellGoods();
                    break;
                case "3":
                    Game.Hero.ShowInventory();
                    break;
                case "4":
                    Game.MainMenu();
                    break;
                default:
                    break;
            }
            this.ShopMenu();
        }

        public void BuyGoods()
        {
            Console.WriteLine("\n******** Buy Menu ********");
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Weapons");
            Console.WriteLine("2. View Armor");
            Console.WriteLine("3. View Potions");
            Console.WriteLine("4. View All");
            Console.WriteLine("5. Return to Shop Menu");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    this.ShowWeapons();
                    this.ExecutePuchase();
                    break;
                case "2":
                    Console.Clear();
                    this.ShowArmor();
                    this.ExecutePuchase();
                    break;
                case "3":
                    Console.Clear();
                    this.ShowPotions();
                    this.ExecutePuchase();
                    break;
                case "4":
                    Console.Clear();
                    this.ShopInventory();
                    this.ExecutePuchase();
                    break;
                case "5":
                    Console.Clear();
                    this.ShopMenu();
                    break;
                default:
                    Console.Clear();
                    this.ShopMenu();
                    break;
            }
            this.BuyGoods();
        }

        public void SellGoods()
        {
            Console.WriteLine("\n******** Sell Menu ********");
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Hero Weapons");
            Console.WriteLine("2. View Hero Armor");
            Console.WriteLine("3. View Hero Potions");
            Console.WriteLine("4. View All");
            Console.WriteLine("5. Return to Shop Menu");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    this.HeroWeaponSell();
                    this.ExecuteSell();
                    break;
                case "2":
                    Console.Clear();
                    this.HeroArmorSell();
                    this.ExecuteSell();
                    break;
                case "3":
                    Console.Clear();
                    this.HeroPotionSell();
                    this.ExecuteSell();
                    break;
                case "4":
                    Console.Clear();
                    this.HeroSellItems();
                    this.ExecuteSell();
                    break;
                case "5":
                    Console.Clear();
                    this.ShopMenu();
                    break;
                default:
                    Console.Clear();
                    this.ShopMenu();
                    break;
            }
        }

        private void ExecutePuchase() {
            var pick = "";

            do {
                Console.WriteLine($"Which item would you like to purchase?");
                pick = Console.ReadLine();
            } while (pick.Length <= 0);

            var weapon = new Weapon();
            var armor = new Armor();
            var potion = new Potion();

            switch (pick.Substring(0, 1).ToLower()) {
                case "w" :

                    if (WeaponCatalog.TryGetValue(pick.Substring(0, 2), out weapon)) {
                        if (Hero.Gold >= weapon.OriginalValue)
                        {
                            Hero.Gold -= weapon.OriginalValue;
                            Hero.WeaponsBag.Add(weapon);
                            WeaponList.Remove(weapon);
                            Console.WriteLine($"Hero just purchased {weapon.Name}!");
                        }
                        else {
                            Console.WriteLine($"You do not have enough Gold to purchase {weapon.Name}");
                            Console.WriteLine($"{weapon.Name} costs {weapon.OriginalValue}, you only have {Hero.Gold -4:C0}");
                        }
                    } else
                    {
                        Console.WriteLine($"Item {pick} does not exist...");
                    }

                    break;
                case "a":

                    if (ArmorCatalog.TryGetValue(pick.Substring(0, 2), out armor))
                    {
                        if (Hero.Gold >= armor.OriginalValue)
                        {
                            Hero.Gold -= armor.OriginalValue;
                            Hero.ArmorsBag.Add(armor);
                            ArmorList.Remove(armor);
                            Console.WriteLine($"Hero just purchased {armor.Name}!");
                        }
                        else
                        {
                            Console.WriteLine($"You do not have enough Gold to purchase {armor.Name}");
                            Console.WriteLine($"{armor.Name} costs {armor.OriginalValue}, you only have {Hero.Gold -4:C0}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Item {pick} does not exist...");
                    }

                    break;
                case "p":

                    if (PotionCatalog.TryGetValue(pick.Substring(0, 2), out potion))
                    {
                        if (Hero.Gold >= potion.OriginalValue)
                        {
                            Hero.Gold -= potion.OriginalValue;
                            Hero.PotionBag.Add(potion);
                            PotionList.Remove(potion);
                            Console.WriteLine($"Hero just purchased {potion.Name}!");
                        }
                        else
                        {
                            Console.WriteLine($"You do not have enough Gold to purchase {potion.Name}");
                            Console.WriteLine($"{potion.Name} costs {potion.OriginalValue}, you only have {Hero.Gold - 4:C0}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Item {pick} does not exist...");
                    }

                    break;
                default:
                    Console.WriteLine($"Item {pick} does not exist...");
                    break;

            }
        }

        private void ExecuteSell()
        {
            var pick = "";

            do
            {
                Console.WriteLine($"Which item would you like to sell?");
                pick = Console.ReadLine();
            } while (pick.Length <= 0);

            var weapon = new Weapon();
            var armor = new Armor();
            var potion = new Potion();

            switch (pick.Substring(0, 1).ToLower())
            {
                case "w":

                    if (WeaponCatalog.TryGetValue(pick.Substring(0, 2), out weapon))
                    {
                        Hero.WeaponsBag.Remove(weapon);
                        this.WeaponList.Add(weapon);
                        Hero.Gold += weapon.ResellValue;

                        Console.WriteLine($"Hero just sold {weapon.Name}, for {weapon.ResellValue}!");
                        Console.WriteLine($"Hero now has {Hero.Gold}!  Time to go shopping!");

                    }
                    else
                    {
                        Console.WriteLine($"Item {pick} does not exist...");
                    }

                    break;
                case "a":

                    if (ArmorCatalog.TryGetValue(pick.Substring(0, 2), out armor))
                    {
                        Hero.ArmorsBag.Remove(armor);
                        this.ArmorList.Add(armor);
                        Hero.Gold += armor.ResellValue;

                        Console.WriteLine($"Hero just sold {armor.Name}, for {armor.ResellValue}!");
                        Console.WriteLine($"Hero now has {Hero.Gold}!  Time to go shopping!");

                    }
                    else
                    {
                        Console.WriteLine($"Item {pick} does not exist...");
                    }

                    break;
                case "p":

                    if (PotionCatalog.TryGetValue(pick.Substring(0, 2), out potion))
                    {
                        Hero.PotionBag.Remove(potion);
                        this.PotionList.Add(potion);
                        Hero.Gold += potion.ResellValue;

                        Console.WriteLine($"Hero just sold {potion.Name}, for {potion.ResellValue}!");
                        Console.WriteLine($"Hero now has {Hero.Gold}!  Time to go shopping!");

                    }
                    else
                    {
                        Console.WriteLine($"Item {pick} does not exist...");
                    }

                    break;
                default:
                    Console.WriteLine($"Item {pick} does not exist...");
                    break;

            }
        }

        private void ShopInventory()
        {
            ShowWeapons();
            ShowArmor();
            ShowPotions();
        }

        private void StockShop()
        {
            LoadWeapons();
            LoadArmor();
            LoadPotions();
        }

        private void LoadWeapons()
        {
            WeaponList.Add(new Weapon("Sword", 3, 10, 2));
            WeaponList.Add(new Weapon("Axe", 4, 12, 3));
            WeaponList.Add(new Weapon("Longsword", 7, 20, 5));
        }

        private void LoadArmor()
        {
            ArmorList.Add(new Armor("Wooden Suit", 3, 10, 2));
            ArmorList.Add(new Armor("Metal Suit", 7, 20, 5));
        }

        private void LoadPotions()
        {
            PotionList.Add(new Potion("Healing Potion", 5, 5, 1));
        }

        private void ShowWeapons()
        {
            var count = 1;
            WeaponCatalog.Clear();

            Console.WriteLine("*** Weapons List ***");
            Console.WriteLine($"#   Weapon Name            S   OV    SV");
            if (WeaponList.Count <= 0) {
                Console.WriteLine($"Shop is currently out of weapons please try again later.");
            }
            else
            {
                foreach (var weapon in WeaponList.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"w{count}. {weapon.Name,-20} {weapon.Strength,3} {weapon.OriginalValue,4:C0} {weapon.ResellValue,4:C0}");
                    WeaponCatalog.Add($"w{count}", weapon);
                    count++;
                }
            }
        }

        private void ShowArmor()
        { 
            var count = 1;
            ArmorCatalog.Clear();

            Console.WriteLine("*** Armor List ***");
            Console.WriteLine($"#   Armor Name             D   OV    SV");
            foreach (var armor in ArmorList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"a{count}. {armor.Name, -20} {armor.Defense, 3} {armor.OriginalValue, 4:C0} {armor.ResellValue, 4:C0}");
                ArmorCatalog.Add($"a{count}", armor);
                count++;
            }
        }

        private void ShowPotions()
        {
            var count = 1;
            PotionCatalog.Clear();

            Console.WriteLine("*** Potions List ***");
            Console.WriteLine($"#   Potion Name            S    OV   SV");
            foreach (var potion in PotionList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"p{count}. {potion.Name, -20} {potion.Hp, 3} {potion.OriginalValue, 4:C0} {potion.ResellValue, 4:C0}");
                PotionCatalog.Add($"p{count}", potion);
            }
        }

        private void HeroSellItems()
        {
            HeroWeaponSell();
            HeroArmorSell();
            HeroPotionSell();
        }

        private void HeroWeaponSell()
        {
            var count = 1;
            ArmorCatalog.Clear();

            Console.WriteLine("*** Hero Weapon List ***");
            Console.WriteLine($"#   Weapon Name            S   OV    SV");

                if (this.Hero.WeaponsBag.Count == 0)
            {
                Console.WriteLine($"You have no Weapons to sell at this time.");
                this.ShopMenu();
            }
            else
            {
                foreach (var weapon in Hero.WeaponsBag.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"w{count}. {weapon.Name,-20} {weapon.Strength,3} {weapon.OriginalValue,4:C0} {weapon.ResellValue,4:C0}");
                    WeaponCatalog.Add($"w{count}", weapon);
                }
            }
        }

        private void HeroArmorSell()
        {
            var count = 1;
            ArmorCatalog.Clear();

            Console.WriteLine("*** Hero Armor List ***");
            Console.WriteLine($"#   Armor Name             D   OV    SV");
            if (this.Hero.ArmorsBag.Count == 0)
            {
                Console.WriteLine($"You have no Armor to sell at this time.");
                this.ShopMenu();
            }
            else
            {
                foreach (var armor in Hero.ArmorsBag.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"a{count}. {armor.Name,-20} {armor.Defense,3} {armor.OriginalValue,4:C0} {armor.ResellValue,4:C0}");
                    ArmorCatalog.Add($"a{count}", armor);
                }
            }
        }

        private void HeroPotionSell()
        {
            var count = 1;
            PotionCatalog.Clear();

            Console.WriteLine("*** Hero Potions List ***");
            Console.WriteLine($"#   Potion Name            S    OV   SV");
            if (this.Hero.PotionBag.Count == 0)
            {
                Console.WriteLine($"You have no postions to sell at this time.");
                this.ShopMenu();
            }
            else
            {
                foreach (var potion in Hero.PotionBag.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"p{count}. {potion.Name,-20} {potion.Hp,3} {potion.OriginalValue,4:C0} {potion.ResellValue,4:C0}");
                    PotionCatalog.Add($"p{count}", potion);
                }
            }
        }
    }
}