using RolePlayDemoAug24.Models.Repos;

namespace RolePlayDemoAug24.Models.State;

/// <summary>
/// Interface for the state of a Game session. An implementation of this 
/// interface will be made available as a service to clients.
/// The game state consists of:
/// 1) All repositories.
/// 2) A reference to a chosen Hero and Beast.
/// 3) A game log.
/// In addition to this, the interface also contains methods for letting
/// the Hero/Beast attack, and for resetting the entire battle.
/// </summary>
public interface IGameState
{
    ArmorRepository ArmorRepository { get; }
    BeastRepository BeastRepository { get; }
    HeroRepository HeroRepository { get; }
    WeaponRepository WeaponRepository { get; }

    Hero ChosenHero { get; set; }
    Beast ChosenBeast { get; set; }
    string Log { get; }

    void HeroAttacks();
    void BeastAttacks();
    void ResetBattle();
}
