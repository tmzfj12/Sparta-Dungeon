using System.Reflection.Metadata.Ecma335;

namespace Sparta_Dungeon
{
    internal class Program
    {
        class Status // 상태
        {


            public int lv = 1;
            public int strength = 10;
            public int armor = 5;
            public int health = 100;
            public int hasgold = 1500;



            public void Nowstatus()
            {
                Console.WriteLine("Lv. " + lv);
                Console.WriteLine("Bruno ( 전사 )");
                Console.WriteLine("공격력 : " + strength);
                Console.WriteLine("방어력 : " + armor);
                Console.WriteLine("체력 : " + health);
                Console.WriteLine("Gold : " + hasgold);

            }
        }
        class Item //아이템 프로퍼티
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }

            public Item(string name, string description, int price)
            {
                Name = name;
                Description = description;
                Price = price;
            }
        }
        class WeaponItem : Item //무기
        {
            public int AttackBonus { get; set; } //추가공격력

            public WeaponItem(string name, string description, int price, int attackBonus)
                : base(name, description, price)
            { AttackBonus = attackBonus; }



        }

        class ArmorItem : Item //방어구
        {
            public int ArmorBonus { get; set; }
            public ArmorItem(string name, string description, int price, int armorBonus)
                : base(name, description, price)
            {
                ArmorBonus = armorBonus;
            }

        }


        class Inventory

        {
            public List<Item> Items = new List<Item>();
            public void ShowInventory()
            {



                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();
                Console.WriteLine("1.장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                int input = int.Parse(Console.ReadLine());
                while (Items.Count == 0)
                {

                    if (input == 0)
                    {
                        Console.Clear();

                        break;
                    }
                    else if (input == 1)
                    {
                        //장착관리 메서드

                    }
                }

                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine($"{Items[i].Name} {Items[i].Description}");
                    if (input == 0)
                    {
                        Console.Clear();

                        break;
                    }
                    else if (input == 1)
                    {
                        //장착관리 메서드

                    }
                }


            }

        }








        class Shop
        {
            public List<Item> itemForSale = new List<Item>();

            public Shop()
            {
                itemForSale.Add(new ArmorItem("수련자 갑옷    ", "| 방어력 +5 | 수련에 도움을 주는 갑옷입니다                     |", 1000, 5));
                itemForSale.Add(new ArmorItem("무쇠 갑옷     ", "| 방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다                  |", 2000, 9));
                itemForSale.Add(new ArmorItem("스파르타의 갑옷  ", "| 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다|", 3500, 15));
                itemForSale.Add(new WeaponItem("낡은 검      ", "| 공격력+2  | 쉽게 볼 수 있는 낡은 검 입니다.                  |", 600, 2));
                itemForSale.Add(new WeaponItem("청동 도끼     ", "| 공격력 +5 | 어디선가 사용됐던 것 같은 도끼입니다.             |", 1500, 5));
                itemForSale.Add(new WeaponItem("스파르타의 창 ", "| 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다    |", 3000, 7));

            }

            public void Shoplist(Status status)
            {
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.Write($"{status.hasgold} + G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");

                for (int i = 0; i < itemForSale.Count; i++)
                {
                    Console.WriteLine($"-{i + 1} {itemForSale[i].Name}{itemForSale[i].Description}{itemForSale[i].Price}G ");

                }
            }

            public void BuyItem(Status status, Inventory inventory, int itemIndex)
            {

                if (itemIndex >= 0 && itemIndex < itemForSale.Count)
                {
                    Item selectedItem = itemForSale[itemIndex];

                    if ((status.hasgold) >= (selectedItem.Price))
                    {
                        inventory.Items.Add(selectedItem);

                        status.hasgold -= selectedItem.Price;

                        Console.WriteLine("구매를 완료했습니다");
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                    }

                }



                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }










        static void Main(string[] args)
        {

            Status status = new Status();
            Shop shop = new Shop();
            Inventory inventory = new Inventory();


            int townAction;


            while (true)
            {

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                townAction = int.Parse(Console.ReadLine());

                if (townAction == 1)
                {

                    bool StatusMenu = true;
                    while (StatusMenu)
                    {

                        Console.WriteLine();
                        status.Nowstatus();
                        Console.WriteLine();
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine("원하시는 행동을 입력해주세요");
                        Console.Write(">> ");
                        int input = int.Parse(Console.ReadLine());
                        if (input == 0)
                        {
                            Console.Clear();

                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다");

                        }
                    }

                }
                else if (townAction == 2)
                {
                    inventory.ShowInventory();
                }
                else if (townAction == 3)
                {
                    bool ShopMenu = true;

                    while (ShopMenu)
                    {
                        Console.WriteLine();
                        shop.Shoplist(status);
                        Console.WriteLine();
                        Console.WriteLine("1. 아이템 구매");
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine();
                        Console.WriteLine("원하시는 행동을 입력해주세요");
                        Console.Write(">> ");
                        int input = int.Parse(Console.ReadLine());
                        if (input == 0)
                        {
                            Console.Clear();

                            break;
                        }
                        else if (input == 1) //상점 기능
                        {

                            bool Shopping = true;
                            while (Shopping)
                            {

                                shop.Shoplist(status);

                                Console.WriteLine();
                                Console.WriteLine("0. 나가기");
                                Console.WriteLine();
                                Console.WriteLine("원하시는 행동을 입력해주세요");
                                Console.Write(">> ");
                                int input2 = int.Parse(Console.ReadLine());

                                if (input == 0)
                                {
                                    Console.Clear();
                                    break;
                                }

                                else
                                {
                                    shop.BuyItem(status, inventory, input2 - 1);
                                    if (input2 == 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }


        }
    }

}
