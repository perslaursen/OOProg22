using Microsoft.AspNetCore.Mvc.RazorPages;
using RolePlayDemoAug24.Models;
using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.State;
#nullable disable

namespace RolePlayDemoAug24.Pages
{
    public class BattleManagerModel : PageModel
    {
        private IGameState _gameState;

        public Hero ChosenHero { get; private set; }
        public Beast ChosenBeast { get; private set; }
        public bool HeroToAttack { get; private set; }
        public string Log { get { return _gameState.Log; } }

        public BattleManagerModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void OnGet()
        {
            ChosenHero = _gameState.ChosenHero;
            ChosenBeast = _gameState.ChosenBeast;
            HeroToAttack = true;
        }

        /// <summary>
        /// Handler for the "Hero Attacks" button
        /// </summary>
        public void OnGetHeroAttack()
        {
            ChosenHero = _gameState.ChosenHero;
            ChosenBeast = _gameState.ChosenBeast;
            
            _gameState.HeroAttacks();
            HeroToAttack = false;
        }

        /// <summary>
        /// Handler for the "Beast Attacks" button
        /// </summary>
        public void OnGetBeastAttack()
        {
            ChosenHero = _gameState.ChosenHero;
            ChosenBeast = _gameState.ChosenBeast;
            
            _gameState.BeastAttacks();
            HeroToAttack = true;
        }

        /// <summary>
        /// Handler for the "Reset" button
        /// </summary>
        public void OnGetReset()
        {
            ChosenHero = _gameState.ChosenHero;
            ChosenBeast = _gameState.ChosenBeast;

            _gameState.ResetBattle();
            HeroToAttack = true;
        }

        public string GetDamageResistancePercent(DamageType damageType)
        {
            return ChosenHero.DamageResistance.GetPercentage(damageType).ToString("0");
        }
    }
}
