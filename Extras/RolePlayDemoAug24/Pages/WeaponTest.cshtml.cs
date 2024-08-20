using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RolePlayDemoAug24.Models;
using RolePlayDemoAug24.Models.Damage;
using RolePlayDemoAug24.Models.Repos;
using RolePlayDemoAug24.Models.State;
#nullable disable

namespace RolePlayDemoAug24.Pages
{
	public class WeaponTestModel : PageModel
	{
		private IGameState _gameState;

		[BindProperty]
		public List<bool> ChosenWeapons { get; set; }

		[BindProperty]
		public List<bool> ChosenArmor { get; set; }

		[BindProperty]
		public List<bool> ChosenBeasts { get; set; }


		public List<Weapon> Weapons { get; set; }
		public List<Hero> Heroes { get; set; }
		public List<Beast> Beasts { get; set; }
		public List<Armor> ArmorList { get; set; }

		public WeaponTestModel(IGameState gameState)
		{
			_gameState = gameState;
		}

		public void OnGet()
		{
			//Heroes = _gameState.HeroRepository.GetAll();
			//Beasts = _gameState.BeastRepository.GetAll();
			//Weapons = _gameState.WeaponRepository.GetAll();	
			//ArmorList = _gameState.ArmorRepository.GetAll();

			//ChosenWeapons = _gameState.WeaponRepository.GetSelection();
			//ChosenArmor = _gameState.ArmorRepository.GetSelection();

			//_gameState.HeroRepository.UpdateWeaponForHeroes(Weapons[0]);
		}

		public IActionResult OnPost()
		{
			//Heroes = _gameState.HeroRepository.GetAll();
			//Beasts = _gameState.BeastRepository.GetAll();
			//Weapons = _gameState.WeaponRepository.GetAll();
			//ArmorList = _gameState.ArmorRepository.GetAll();

			//_gameState.WeaponRepository.SetSelection(ChosenWeapons);
			//_gameState.ArmorRepository.SetSelection(ChosenArmor);

			//_gameState.HeroRepository.UpdateArmorForHeroes(_gameState.ArmorRepository);

			//foreach (Hero h in Heroes)
			//{
			//	for (int wIndex = 0; wIndex < Weapons.Count; wIndex++)
			//	{
			//		DamageDealt wDamage = Weapons[wIndex].DealDamage();
			//		if (ChosenWeapons[wIndex])
			//			h.ReceiveDamage(wDamage);
			//	}

			//	for (int bIndex = 0; bIndex < Beasts.Count; bIndex++)
			//	{
			//		DamageDealt bDamage = Beasts[bIndex].DealDamage();
			//		if (ChosenBeasts[bIndex])
			//			h.ReceiveDamage(bDamage);
			//	}
			//}

			return Page();
		}
	}
}
