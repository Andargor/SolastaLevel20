using System.Collections.Generic;
using SolastaModApi.Extensions;

namespace SolastaLevel20.Models
{
    class MultiClass
    {
        private static readonly List<RulesetCharacterHero> heroesPool = new List<RulesetCharacterHero>();
        private static readonly List<string> classes = new List<string>();

        public static readonly Dictionary<string, string> NextHeroClass = new Dictionary<string, string> { };

        public static bool IsHeroesPoolDirty = true;

        private static List<string> GetClasses()
        {
            if (classes.Count == 0)
            {
                var characterClassDefinitionDatabase = DatabaseRepository.GetDatabase<CharacterClassDefinition>();

                if (characterClassDefinitionDatabase != null)
                {
                    foreach (var characterClassDefinition in characterClassDefinitionDatabase.GetAllElements())
                    {
                        classes.Add(characterClassDefinition.FormatTitle());
                    }
                    classes.Sort((a, b) => a.CompareTo(b));
                }
            }
            return classes;
        }

        internal static bool ApproveMultiClassInOut(RulesetCharacterHero hero, string name)
        {
            var strength = hero.GetAttribute("Strength").BaseValue;
            var dexterity = hero.GetAttribute("Dexterity").BaseValue;
            var constitution = hero.GetAttribute("Constitution").BaseValue;
            var intelligence = hero.GetAttribute("Intelligence").BaseValue;
            var wisdom = hero.GetAttribute("Wisdom").BaseValue;
            var charisma = hero.GetAttribute("Charisma").BaseValue;

            switch (name)
            {
                case "Barbarian":
                    return strength > 13;

                case "Bard":
                    return charisma > 13;

                case "Cleric":
                    return wisdom > 13;

                case "Fighter":
                    return strength > 13 || dexterity > 13;

                case "Paladin":
                    return strength > 13 && charisma > 13;

                case "Ranger":
                    return dexterity > 13 && wisdom > 13;

                case "Tinkerer":
                    return intelligence > 13 && wisdom > 13;

                case "Rogue":
                    return dexterity > 13;

                case "Wizard":
                    return intelligence > 13;

                default:
                    return false;
            }
        }

        public static List<string> GetFilteredClasses(RulesetCharacterHero hero)
        {
            var _classes = new List<string>() { };
            var currentClass = hero.ClassesHistory[hero.ClassesHistory.Count - 1].FormatTitle();

            if (!ApproveMultiClassInOut(hero, currentClass))
            {
                _classes.Add(currentClass);
            }
            else
            {
                foreach (var name in GetClasses())
                {
                    if (ApproveMultiClassInOut(hero, name))
                    {
                        _classes.Add(name);
                    }
                }
            }

            return _classes;
        }

        public static CharacterClassDefinition GetClassDefinition(string className)
        {
            var characterClassDefinitionDatabase = DatabaseRepository.GetDatabase<CharacterClassDefinition>();

            if (characterClassDefinitionDatabase != null)
            {
                foreach (var characterClassDefinition in characterClassDefinitionDatabase.GetAllElements())
                {
                    if (characterClassDefinition.FormatTitle() == className)
                        return characterClassDefinition;
                }
            }
            return null;
        }

        public static void ForceDeityOnAllClasses()
        {
            var characterClassDefinitionDatabase = DatabaseRepository.GetDatabase<CharacterClassDefinition>();
            if (characterClassDefinitionDatabase != null)
            {
                foreach (var characterClassDefinition in characterClassDefinitionDatabase.GetAllElements())
                {
                    characterClassDefinition.SetRequiresDeity(true);
                }
            }
        }

        public static List<RulesetCharacterHero> GetHeroesPool()
        {
            if (IsHeroesPoolDirty)
            {
                heroesPool.Clear();
                IsHeroesPoolDirty = false;
            }
            if (heroesPool.Count == 0)    
            {
                var characterPoolService = ServiceRepository.GetService<ICharacterPoolService>();

                if (characterPoolService != null)
                {
                    heroesPool.Clear();
                    foreach (var name in characterPoolService.Pool.Keys)
                    {
                        characterPoolService.LoadCharacter(
                            characterPoolService.BuildCharacterFilename(name.Substring(0, name.Length - 4)),
                            out RulesetCharacterHero hero,
                            out RulesetCharacterHero.Snapshot snapshot);
                        heroesPool.Add(hero);
                    }
                    heroesPool.Sort((a, b) =>
                    {
                        var compareName = a.Name.CompareTo(b.Name);
                        if (compareName == 0)
                            compareName = a.SurName.CompareTo(b.SurName);
                        return compareName;
                    });
                }
            }
            return heroesPool;
        }

        public static List<RulesetCharacterHero> GetHeroesInGame()
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