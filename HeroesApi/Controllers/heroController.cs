using HeroesApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class heroController : ControllerBase
    {
        public IHeroRepo herorepo { get; }

        public heroController(IHeroRepo hrepo)
        {
            herorepo = hrepo;
        }

        // GET: api/<heroeController>
        [HttpGet]
        public async Task<List<Hero>>  Get()
        {
            //Icollection is no different from List except its readonly
            //return Ok(herorepo.GetHeroes());
            //List<Hero> heroes = await herorepo.GetHeroes();
            return await herorepo.GetHeroes();
        }

        // GET api/<heroeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var CurrentHero = await herorepo.GetHeroById(id);
            if (CurrentHero != null)
            {
                return Ok(CurrentHero);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<heroeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hero hero)
        {
            var addedHero = await herorepo.AddHero(hero);
            if (addedHero != null)
            {
                return Ok(addedHero);
            }
            else return NotFound();
        }

        // PUT api/<heroeController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hero hero)
        {
            var modifiedHero = await  herorepo.UpdateHero(hero);
            if(modifiedHero != null)
            {
                return Ok(modifiedHero);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<heroeController>/5
        [HttpDelete("{id}")]
        //[HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deltedhero = await herorepo.RemoveHero(id);
            if (deltedhero != null)
            {
                return Ok(deltedhero);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
