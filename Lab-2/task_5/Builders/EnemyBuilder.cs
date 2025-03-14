using Models;

namespace Builders
{
    public class EnemyBuilder
    {
        private readonly Character _enemy;

        public EnemyBuilder()
        {
            _enemy = new Character();
        }

        public EnemyBuilder SetName(string name)
        {
            _enemy.Name = name;
            return this;
        }

        public EnemyBuilder SetRace(string race)
        {
            _enemy.Race = race;
            return this;
        }

        public EnemyBuilder SetClass(string enemyClass)
        {
            _enemy.Class = enemyClass;
            return this;
        }

        public EnemyBuilder SetHP(int hp)
        {
            _enemy.HP = hp;
            return this;
        }

        public EnemyBuilder SetHairColor(string color)
        {
            _enemy.HairColor = color;
            return this;
        }

        public EnemyBuilder SetEyeColor(string color)
        {
            _enemy.EyeColor = color;
            return this;
        }

        public EnemyBuilder SetOutfit(string outfit)
        {
            _enemy.Outfit = outfit;
            return this;
        }

        public EnemyBuilder AddInventoryItem(string item)
        {
            _enemy.Inventory.Add(item);
            return this;
        }

        public EnemyBuilder AddEvilDeed(string deed)
        {
            _enemy.EvilDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return _enemy;
        }
    }
}
