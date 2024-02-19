namespace HeroesApi.Model
{
    public interface IHeroRepo
    {
        public Task<List<Hero>> GetHeroes();
        public Task<Hero?> GetHeroById(int id);
        public Task<Hero> AddHero(Hero hero);
        public Task<Hero?> UpdateHero(Hero hero);
        public Task<Hero?> RemoveHero(int id);

    }
}
