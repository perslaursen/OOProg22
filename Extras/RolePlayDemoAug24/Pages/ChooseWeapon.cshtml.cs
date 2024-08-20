using Microsoft.AspNetCore.Mvc.RazorPages;
using RolePlayDemoAug24.Models.State;
using RolePlayDemoAug24.Models;
using Microsoft.AspNetCore.Mvc;
#nullable disable

namespace RolePlayDemoAug24.Pages
{
    public class ChooseWeaponModel : PageModel
    {
        private IGameState _gameState;

        public List<Weapon> Weapons { get; private set; }
        public Hero ChosenHero { get; private set; }

        public ChooseWeaponModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void OnGet()
        {
            Weapons = _gameState.WeaponRepository.GetAll();
            ChosenHero = _gameState.ChosenHero;
        }

        /// <summary>
        /// Handler for the Select button, sets the chosen Weapon
        /// as Weapon for the ChosenHero in the game state, and then 
        /// redirects to the "Choose Armor" page.
        /// </summary>
        public IActionResult OnGetSetWeapon(int id)
        {
            _gameState.ChosenHero.Weapon = _gameState.WeaponRepository.Get(id);
            return RedirectToPage("ChooseArmor");
        }
    }
}
