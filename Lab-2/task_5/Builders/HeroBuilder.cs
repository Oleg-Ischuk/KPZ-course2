using Models;

namespace Builders
{
    public class HeroBuilder
    {
        private readonly Character _hero;

        public HeroBuilder()
        {
            _hero = new Character();
        }

        public HeroBuilder SetName(string name)
        {
            _hero.Name = name;
            return this;
        }

        public HeroBuilder SetRace(string race)
        {
            _hero.Race = race;
            return this;
        }

        public HeroBuilder SetClass(string heroClass)
        {
            _hero.Class = heroClass;
            return this;
        }

        public HeroBuilder SetHP(int hp)
        {
            _hero.HP = hp;
            return this;
        }

        public HeroBuilder SetHairColor(string color)
        {
            _hero.HairColor = color;
            return this;
        }

        public HeroBuilder SetEyeColor(string color)
        {
            _hero.EyeColor = color;
            return this;
        }

        public HeroBuilder SetOutfit(string outfit)
        {
            _hero.Outfit = outfit;
            return this;
        }

        public HeroBuilder AddInventoryItem(string item)
        {
            _hero.Inventory.Add(item);
            return this;
        }

        public HeroBuilder AddGoodDeed(string deed)
        {
            _hero.GoodDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return _hero;
        }
    }
}
