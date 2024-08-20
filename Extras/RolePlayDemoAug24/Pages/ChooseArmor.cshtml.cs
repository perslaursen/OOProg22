using Microsoft.AspNetCore.Mvc.RazorPages;
using RolePlayDemoAug24.Models.State;
using RolePlayDemoAug24.Models;
#nullable disable

namespace RolePlayDemoAug24.Pages
{
	public class ChooseArmorModel : PageModel
	{
		private IGameState _gameState;

		public List<Armor> ArmorList { get; private set; }
		public List<bool> ChosenArmor { get; private set; }
		public Hero ChosenHero { get; private set; }

		public ChooseArmorModel(IGameState gameState)
		{
			_gameState = gameState;
		}

		public void OnGet()
		{
			OnGetInit();
			ChosenHero.SetArmor(CalcChosenArmor());
		}

		/// <summary>
		/// Handler for the Select/Selected button, toggles the selection
		/// of the Armor identified by the id, and updates the Armor set
		/// for the ChosenHero accordingly.
		/// </summary>
		public void OnGetUpdateSelection(int id)
		{
			OnGetInit();

			ChosenArmor[id] = !ChosenArmor[id];
			_gameState.ArmorRepository.SetSelection(ChosenArmor);

			ChosenHero.SetArmor(CalcChosenArmor());
		}

		/// <summary>
		/// Calculates if it is currently possible to select the Armor identified by the id,
		/// given that only one piece of Armor of each Armor Type can be selected.
		/// </summary>
		public bool CanChooseArmor(int index)
		{
			return ChosenArmor[index] || CalcChosenArmor().FirstOrDefault(a => a.ArmorType == ArmorList[index].ArmorType) == null;
		}

		private void OnGetInit()
		{
			ChosenHero = _gameState.ChosenHero;
			ArmorList = _gameState.ArmorRepository.GetAll();
			ChosenArmor = new List<bool>(_gameState.ArmorRepository.GetSelection());
		}

		/// <summary>
		/// Calculates the actual Armor selection, based on the selection in the UI.
		/// </summary>
		private List<Armor> CalcChosenArmor()
		{
			List<Armor> chosenArmorList = new List<Armor>();

			for (int i = 0; i < ArmorList.Count; i++)
			{
				if (ChosenArmor[i])
					chosenArmorList.Add(ArmorList[i]);
			}

			return chosenArmorList;
		}
	}
}
