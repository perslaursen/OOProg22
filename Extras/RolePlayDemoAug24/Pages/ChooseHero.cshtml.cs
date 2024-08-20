using Microsoft.AspNetCore.Mvc.RazorPages;
using RolePlayDemoAug24.Models.State;
using RolePlayDemoAug24.Models;
using Microsoft.AspNetCore.Mvc;
#nullable disable

namespace RolePlayDemoAug24.Pages
{
    public class ChooseHeroModel : PageModel
    {
        private IGameState _gameState;

        public List<Hero> Heroes { get; private set; }

        public ChooseHeroModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void OnGet()
        {
            Heroes = _gameState.HeroRepository.GetAll();

            foreach (Hero hero in Heroes)
            {
                hero.Reset();
            }
        }

        /// <summary>
        /// Handler for the Select button, sets the chosen Hero
        /// as the ChosenHero in the game state, and then redirects
        /// to the "Choose Weapon" page.
        /// </summary>
        public IActionResult OnGetSetHero(int id)
        {
            _gameState.ChosenHero = _gameState.HeroRepository.Get(id);
            return RedirectToPage("ChooseWeapon");
        }
    }
}
