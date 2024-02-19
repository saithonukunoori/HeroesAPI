using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Model
{
    public class Herorepo : IHeroRepo
    {
        public datacontext _datacontext { get; }
        public Herorepo(datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public Herorepo()
        {
        }

        public Task<List<Hero>> GetHeroes()
        {
            return _datacontext.Heroes.ToListAsync();
        }

        public async Task<Hero?> GetHeroById(int id)
        {
            return await _datacontext.Heroes.FindAsync(id);
        }

        public async Task<Hero> AddHero(Hero hero)
        {
            await _datacontext.Heroes.AddAsync(hero);
            await _datacontext.SaveChangesAsync();
            return hero;
        }

        public async  Task<Hero?> UpdateHero(Hero hero)
        {
            var currHero =  await _datacontext.Heroes.FindAsync(hero.Id);
            if (currHero != null)
            {
                currHero.Name = hero.Name;
                await _datacontext.SaveChangesAsync();
                return currHero; 
            }
            else
            {
                return null;
            }
        }

        public async Task<Hero?> RemoveHero(int id)
        {
            var currHero = await _datacontext.Heroes.FindAsync(id);
            if (currHero != null)
            {
                _datacontext.Heroes.Remove(currHero);
                await _datacontext.SaveChangesAsync();
                return currHero;
            }
            else
            {
                return null;
            }
        }

    }
}
