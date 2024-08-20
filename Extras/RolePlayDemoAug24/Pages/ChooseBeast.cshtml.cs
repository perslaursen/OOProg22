using Microsoft.AspNetCore.Mvc.RazorPages;
using RolePlayDemoAug24.Models.State;
using RolePlayDemoAug24.Models;
using Microsoft.AspNetCore.Mvc;
#nullable disable

namespace RolePlayDemoAug24.Pages
{
    public class ChooseBeastModel : PageModel
    {
        private IGameState _gameState;

        public List<Beast> Beasts { get; private set; }

        public ChooseBeastModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void OnGet()
        {
            Beasts = _gameState.BeastRepository.GetAll();

            foreach (Beast beast in Beasts)
            {
                beast.Reset();
            }
        }

        /// <summary>
        /// Handler for the Select button, sets the chosen Beast
        /// as the ChosenBeast in the game state, and then redirects
        /// to the "BattleManager" page.
        /// </summary>
        public IActionResult OnGetSetBeast(int id)
        {
            _gameState.ChosenBeast = _gameState.BeastRepository.Get(id);
            return RedirectToPage("BattleManager");
        }
    }
}
