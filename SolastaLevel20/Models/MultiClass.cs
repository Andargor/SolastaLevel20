using System.Collections.Generic;
using System.Linq;
using SolastaModApi.Extensions;

namespace SolastaLevel20.Models
{
    class MultiClass
    {
        private static readonly List<string> classesName = new List<string>();
        private static readonly List<RulesetCharacterHero> heroesPool = new List<RulesetCharacterHero>();
        private static readonly Dictionary<string, string> heroesSelectedClass = new Dictionary<string, string> { };

        private static List<string> GetClassNames()
        {
            if (classesName.Count == 0)
            {
                var characterClassDefinitionDatabase = DatabaseRepository.GetDatabase<CharacterClassDefinition>();

                if (characterClassDefinitionDatabase != null)
                {
                    foreach (var characterClassDefinition in characterClassDefinitionDatabase.GetAllElements())
                    {
                        classesName.Add(characterClassDefinition.FormatTitle());
                    }
                    classesName.Sort((a, b) => a.CompareTo(b));
                }
            }
            return classesName;
        }

        private static bool ApproveMultiClassInOut(RulesetCharacterHero hero, string name)
        {
            var strength = hero.GetAttribute("Strength").CurrentValue;
            var dexterity = hero.GetAttribute("Dexterity").CurrentValue;
            var constitution = hero.GetAttribute("Constitution").CurrentValue;
            var intelligence = hero.GetAttribute("Intelligence").CurrentValue;
            var wisdom = hero.GetAttribute("Wisdom").CurrentValue;
            var charisma = hero.GetAttribute("Charisma").CurrentValue;

            switch (name)
            {
                case "Barbarian":
                    return strength >= 13;

                case "Bard":
                    return charisma >= 13;

                case "Cleric":
                    return wisdom >= 13;

                case "Fighter":
                    return strength >= 13 || dexterity >= 13;

                case "Paladin":
                    return strength >= 13 && charisma >= 13;

                case "Ranger":
                    return dexterity >= 13 && wisdom >= 13;

                case "Tinkerer":
                    return intelligence >= 13 && wisdom >= 13;

                case "Rogue":
                    return dexterity >= 13;

                case "Wizard":
                    return intelligence >= 13;

                default:
                    return false;
            }
        }

        public static string GetHeroFullName(RulesetCharacterHero hero)
        {
            return hero.Name + hero.SurName;
        }

        public static List<string> GetHeroAllowedClassNames(RulesetCharacterHero hero)
        {
            var allowedClasses = new List<string>() { };
            var classesHistory = hero.ClassesHistory.Distinct();
            var currentClass = hero.ClassesHistory[hero.ClassesHistory.Count - 1].FormatTitle();

            if (!ApproveMultiClassInOut(hero, currentClass))
            {
                allowedClasses.Add(currentClass);
            }
            else if (classesHistory.Count() >= Main.Settings.maxAllowedClasses)
            {
                foreach (var characterClassDefinition in classesHistory)
                {
                    var className = characterClassDefinition.FormatTitle();

                    if (ApproveMultiClassInOut(hero, className))
                    {
                        allowedClasses.Add(className);
                    }
                }
            } 
            else
            {
                foreach (var className in GetClassNames())
                {
                    if (ApproveMultiClassInOut(hero, className))
                    {
                        allowedClasses.Add(className);
                    }
                }
            }
            return allowedClasses;
        }

        public static void SetHeroSelectedClassName(RulesetCharacterHero hero, string className)
        {
            heroesSelectedClass.AddOrReplace(GetHeroFullName(hero), className);
        }

        public static string GetHeroSelectedClassName(RulesetCharacterHero hero)
        {
            var heroFullName = GetHeroFullName(hero);

            if (!heroesSelectedClass.ContainsKey(heroFullName))
            {
                heroesSelectedClass.Add(heroFullName, hero.ClassesHistory[hero.ClassesHistory.Count - 1].FormatTitle());
            }
            return heroesSelectedClass[heroFullName];
        }

        public static CharacterClassDefinition GetHeroSelectedClass(RulesetCharacterHero hero)
        {
            var characterClassDefinitionDatabase = DatabaseRepository.GetDatabase<CharacterClassDefinition>();

            if (characterClassDefinitionDatabase != null)
            {
                var selectedClassName = GetHeroSelectedClassName(hero);

                foreach (var characterClassDefinition in characterClassDefinitionDatabase.GetAllElements())
                {
                    if (characterClassDefinition.FormatTitle() == selectedClassName)
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

        public static List<RulesetCharacterHero> GetHeroesPool(bool isDirty = false)
        {
            if (isDirty)
            {
                heroesPool.Clear();
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
                    heroesPool.Sort((a, b) => GetHeroFullName(a).CompareTo(GetHeroFullName(b)));
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
                    var hero = (RulesetCharacterHero)gameLocationCharacter.RulesetCharacter;
                    heroes.Add(hero);
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