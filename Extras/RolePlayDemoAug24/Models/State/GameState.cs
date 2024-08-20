using RolePlayDemoAug24.Models.Damage;
using RolePlayDemoAug24.Models.Repos;
using RolePlayDemoAug24.Models.Utils;
using RolePlayDemoAug24.Models.Base;
#nullable disable

namespace RolePlayDemoAug24.Models.State;

public class GameState : IGameState
{
	public ArmorRepository ArmorRepository { get;  } = new ArmorRepository();
	public WeaponRepository WeaponRepository { get; } = new WeaponRepository();
	public BeastRepository BeastRepository { get; } = new BeastRepository();
	public HeroRepository HeroRepository { get; } = new HeroRepository();

	public Hero ChosenHero { get; set; }
	public Beast ChosenBeast { get; set; }
	public string Log { get; private set; }

	public GameState()
	{
		ResetBattle();
	}

	public void HeroAttacks()
	{
		DoAttack(ChosenHero, ChosenBeast);
	}

	public void BeastAttacks()
	{
		DoAttack(ChosenBeast, ChosenHero);
	}

	/// <summary>
	/// Central method for managing a single attack.
	/// The given damageDealer dels Damage, which is recevied by the given damageReceiver.
	/// Information about the Damage dealt and received is added to the Log.
	/// </summary>
	private void DoAttack(Being damageDealer, Being damageReceiver)
	{
		Validation.CheckNotNull(damageDealer);
		Validation.CheckNotNull(damageReceiver);

		DamageDealt dd = damageDealer.DealDamage();

		double receivedDamage = damageReceiver.ReceiveDamage(dd);

		AddToLog($"{damageDealer.Name} dealt {FormatDamage(dd)}  -->  {damageReceiver.Name} took {FD(receivedDamage)} damage");

		if (damageDealer.IsDead)
		{
			AddToLog($"{damageDealer.Name} died...");
		}
	}

	/// <summary>
	/// Resets the battle, by resetting the Hero, Beast and the Log.
	/// </summary>
	public void ResetBattle()
	{
		ChosenHero?.Reset();
		ChosenBeast?.Reset();

		Log = "";
	}

	/// <summary>
	/// Adds the given line of text to the front of the Log
	/// </summary>
	private void AddToLog(string text)
	{
		Log = $"{text}\n" + Log;
	}

	private string FD(double val)
	{
		return val.ToString("0.00");
	}

	private string FormatDamage(DamageDealt dd)
	{
		return $"{FD(dd.GetDamage())} damage [Fire {FD(dd.GetDamage(DamageType.Fire))}] [Frost {FD(dd.GetDamage(DamageType.Frost))}] [Necro {FD(dd.GetDamage(DamageType.Necrotic))}] [Physical {FD(dd.GetDamage(DamageType.Physical))}]";
	}
}
