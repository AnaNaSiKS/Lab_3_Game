using Lab_3_C.Medicines;
using Lab_3_C.Monsters;

namespace Lab_3_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Santa_Claus santa_Claus = new Santa_Claus();
            santa_Claus.Show();

            Hero hero = new Hero();
            hero.Show();


            santa_Claus.Show();

            hero.Inventory.Add(new Bandage());
            hero.Inventory.Add(new Chocolate());
            hero.Inventory.Add(new PowerEngineer());
            hero.Show();
        }
    }
}