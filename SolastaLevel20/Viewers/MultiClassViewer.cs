using System.Collections.Generic;
using UnityModManagerNet;
using ModKit;
using static SolastaLevel20.Models.MultiClass;

namespace SolastaLevel20.Viewers
{
    public class MultiClassViewer : IMenuSelectablePage
    {
        public string Name => "Multi Class Settings";

        public int Priority => 1;

        private static bool showStats = false;
        private static bool showAttributes = false;
        private static readonly Dictionary<RulesetCharacterHero, bool> showHeroClasses = new Dictionary<RulesetCharacterHero, bool> { };

        private static void DisplayClassSelector(RulesetCharacterHero hero)
        {
            var classes = GetFilteredClasses(hero).ToArray();
            var heroName = hero.Name + hero.SurName;            
            var selected = System.Array.IndexOf(classes, NextHeroClass[heroName]);

            if (UI.SelectionGrid(ref selected, classes, classes.Length, UI.Width(400)))
            {
                NextHeroClass[heroName] = classes[selected];
            }
        }

        private static void DisplayHeroStats(RulesetCharacterHero hero)
        {
            var flip = false;

            using (UI.HorizontalScope())
            {
                DisplayClassSelector(hero);

                UI.Label($"{hero.Name} {hero.SurName}".orange().bold(), UI.Width(240));

                UI.Label($"{hero.RaceDefinition.FormatTitle()}".white(), UI.Width(96));

                var attributesLabel = showAttributes ? "" : "Atributes";
                UI.DisclosureToggle(attributesLabel, ref showAttributes, attributesLabel.Length * 12);

                if (showAttributes)
                {
                    UI.Label($"Str: {hero.GetAttribute("Strength").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"Con: {hero.GetAttribute("Constitution").CurrentValue:0#}".yellow(), UI.Width(48));
                    UI.Label($"Dex: {hero.GetAttribute("Dexterity").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"Int: {hero.GetAttribute("Intelligence").CurrentValue:0#}".yellow(), UI.Width(48));
                    UI.Label($"Wis: {hero.GetAttribute("Wisdom").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"Cha: {hero.GetAttribute("Charisma").CurrentValue:0#}".yellow(), UI.Width(48));
                };

                var statsLabel = showStats ? "" : "Stats";
                UI.DisclosureToggle(statsLabel, ref showStats, statsLabel.Length * 12);

                if (showStats)
                {
                    UI.Label($"AC: {hero.GetAttribute("ArmorClass").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"HD: {hero.MaxHitDiceCount():0#}{hero.MainHitDie}".yellow(), UI.Width(72));
                    UI.Label($"XP: {hero.GetAttribute("Experience").CurrentValue}".white(), UI.Width(72));
                    UI.Label($"LV: {hero.GetAttribute("CharacterLevel").CurrentValue:0#}".white(), UI.Width(48));
                }

                showHeroClasses.TryGetValue(hero, out flip);
                if (UI.DisclosureToggle($"Classes", ref flip, 132))
                {
                    showHeroClasses.AddOrReplace<RulesetCharacterHero, bool>(hero, flip);
                }
            }

            showHeroClasses.TryGetValue(hero, out flip);
            if (flip)
                using (UI.VerticalScope())
                {
                    using (UI.HorizontalScope())
                    {
                        UI.Space(30);
                        UI.Label("Classes".bold().cyan());
                    }
                    for (var ix = 0; ix < hero.ClassesHistory.Count; ix++)
                        using (UI.HorizontalScope())
                        {
                            var classHistory = hero.ClassesHistory[ix];

                            UI.Space(60);
                            UI.Label($"{ix+1:0#}: {classHistory.FormatTitle()}", UI.Width(192));
                        }
                }

            UI.Div();
        }

        private static void DisplayHeroes()
        {
            using (UI.VerticalScope(UI.AutoWidth(), UI.AutoHeight()))
            {
                if (InGame())
                    foreach (var hero in GetHeroesInGame())
                    {
                        DisplayHeroStats(hero);
                    }
                else
                    foreach (var hero in GetHeroesPool())
                    {
                        DisplayHeroStats(hero);
                    }
            }
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Main.Mod == null) return;

            UI.Label("Welcome to Level 20 with Multi Class".yellow().bold());
            UI.Div();

            DisplayHeroes();
        }
    }
}