using System;
using System.Collections.Generic;
using System.Linq;

namespace SolastaLevel20.Models
{
    class ClassPicker
    {
        private static int selectedClass = 0;
        private static readonly List<string> heroClasses = new List<string>() { };

        public static void CollectHeroClasses(RulesetCharacterHero hero)
        {
            var classesHistory = hero.ClassesHistory.Distinct();

            selectedClass = 0;
            heroClasses.Clear();
            foreach (var characterClassDefinition in classesHistory)
            {
                heroClasses.Add(characterClassDefinition.Name);
            }
        }

        public static string GetSelectedClassSearchTerm(string contains)
        {
            return contains; // + heroClasses[selectedClass];
        }

        public static void PickPreviousClass()
        {
            selectedClass = selectedClass > 0 ? selectedClass - 1 : heroClasses.Count - 1;
        }

        public static void PickNextClass()
        {
            selectedClass = selectedClass < heroClasses.Count - 1 ? selectedClass + 1 : 0;
        }
    }
}