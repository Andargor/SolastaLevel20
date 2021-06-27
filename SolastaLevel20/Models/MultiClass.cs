using System.Collections.Generic;
using SolastaModApi.Extensions;

namespace SolastaLevel20.Models
{
    class MultiClass
    {
        private static readonly List<RulesetCharacterHero> poolHeroes = new List<RulesetCharacterHero>();
        private static readonly List<CharacterClassDefinition> solastaClassDefinitions = new List<CharacterClassDefinition>();

        public static readonly List<string> ClassNames = new List<string>();

        public static readonly Dictionary<RulesetCharacterHero, CharacterClassDefinition> NextHeroClass = new Dictionary<RulesetCharacterHero, CharacterClassDefinition> { };

        public static List<CharacterClassDefinition> GetClassDefinitions()
        {
            if (solastaClassDefinitions.Count == 0)
            {
                var characterClassDefinitionDatabase = DatabaseRepository.GetDatabase<CharacterClassDefinition>();
                if (characterClassDefinitionDatabase != null)
                {
                    foreach (var characterClassDefinition in characterClassDefinitionDatabase.GetAllElements())
                    {
                        characterClassDefinition.SetRequiresDeity(true);
                        solastaClassDefinitions.Add(characterClassDefinition);
                        ClassNames.Add(characterClassDefinition.FormatTitle());
                    }
                    solastaClassDefinitions.Sort((a, b) => a.FormatTitle().CompareTo(b.FormatTitle()));
                    ClassNames.Sort((a, b) => a.CompareTo(b));
                }
            }
            return solastaClassDefinitions;
        }

        public static List<RulesetCharacterHero> GetPoolHeroes()
        {
            if (poolHeroes.Count == 0)
            {
                var characterPoolService = ServiceRepository.GetService<ICharacterPoolService>();
                if (characterPoolService != null)
                {
                    foreach (var name in characterPoolService.Pool.Keys)
                    {
                        characterPoolService.LoadCharacter(
                            characterPoolService.BuildCharacterFilename(name.Substring(0, name.Length - 4)),
                            out RulesetCharacterHero hero,
                            out RulesetCharacterHero.Snapshot snapshot);
                        poolHeroes.Add(hero);
                    }
                    poolHeroes.Sort((a, b) =>
                    {
                        var compareName = a.Name.CompareTo(b.Name);
                        if (compareName == 0)
                            compareName = a.SurName.CompareTo(b.SurName);
                        return compareName;
                    });
                }
            }

            return poolHeroes;
        }

        public static List<RulesetCharacterHero> GetGameHeroes()
        {
            var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();
            var heroes = new List<RulesetCharacterHero>();

            if (gameLocationCharacterService != null)
            {
                foreach(var gameLocationCharacter in gameLocationCharacterService.PartyCharacters)
                {
                    heroes.Add((RulesetCharacterHero)gameLocationCharacter.RulesetCharacter);
                }
            }

            return heroes;
        }

        public static bool InGame()
        {
            var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();
            return gameLocationCharacterService != null && gameLocationCharacterService.PartyCharacters.Count > 0;
        }
    }
}