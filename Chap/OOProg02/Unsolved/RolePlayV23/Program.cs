
CharacterGroup redTeam = new CharacterGroup("Team Red");
redTeam.AddCharacter(new Character("Angor", 100, 15, 25));
redTeam.AddCharacter(new Character("Zurin", 85, 18, 30));

CharacterGroup greenTeam = new CharacterGroup("Team Green");
greenTeam.AddCharacter(new Character("Baldur", 120, 12, 18));
greenTeam.AddCharacter(new Character("Eliza", 80, 20, 35));

BattleHandler.DoBattle(redTeam, greenTeam);
