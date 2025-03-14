namespace Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int HP { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> GoodDeeds { get; set; } = new List<string>();
        public List<string> EvilDeeds { get; set; } = new List<string>();

        public void PrintStats()
        {
            Console.WriteLine($"Name: {Name}, Race: {Race}, Class: {Class}, HP: {HP}");
            Console.WriteLine($"Hair: {HairColor}, Eyes: {EyeColor}, Outfit: {Outfit}");
            Console.WriteLine($"Inventory: {string.Join(", ", Inventory)}");

            if (GoodDeeds.Any())
                Console.WriteLine($"Good Deeds: {string.Join(", ", GoodDeeds)}");

            if (EvilDeeds.Any())
                Console.WriteLine($"Evil Deeds: {string.Join(", ", EvilDeeds)}");
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
            Console.WriteLine($"{Name} takes {damage} damage. HP now: {HP}");
        }
    }
}
