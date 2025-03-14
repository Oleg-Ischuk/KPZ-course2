using System;
using System.Collections.Generic;

namespace VirusLibrary
{
    public class Virus : ICloneable
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public double Size { get; private set; }
        public int Lifespan { get; private set; }
        public IReadOnlyList<Virus> Mutations => mutations;

        private readonly List<Virus> mutations;

        public Virus(string name, string category, double size, int lifespan)
        {
            Name = name;
            Category = category;
            Size = size;
            Lifespan = lifespan;
            mutations = new List<Virus>();
        }

        public void AddMutation(Virus mutation)
        {
            mutations.Add(mutation);
        }

        public object Clone()
        {
            var clone = new Virus(Name, Category, Size, Lifespan);
            foreach (var mutation in mutations)
            {
                clone.AddMutation((Virus)mutation.Clone());
            }
            return clone;
        }

        public void DisplayMutationTree(string indent = "")
        {
            Console.WriteLine($"{indent}{this}");
            foreach (var mutation in Mutations)
            {
                mutation.DisplayMutationTree(indent + "    ");
            }
        }

        public override string ToString() =>
            $"🦠 {Name}, Категорія: {Category}, Розмір: {Size:F3} мкм, Тривалість життя: {Lifespan} днів, Мутацій: {Mutations.Count}";
    }
}
