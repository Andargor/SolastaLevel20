using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using I2.Loc;
using ModKit;

namespace SolastaLevel20
{
    public class Core
    {

    }

    public class Settings : UnityModManager.ModSettings
    {
        public int version = 1;

        public const int MOD_MIN_LEVEL = 1;
        public const int MOD_MAX_LEVEL = 20;
        public const int GAME_MAX_LEVEL = 10;
        public const int MAX_CHARACTER_EXPERIENCE = 1000000;
    }

    public class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod;
        internal static MenuManager Menu;

        internal static void LoadTranslations()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(MOD_FOLDER);
            FileInfo[] files = directoryInfo.GetFiles($"Translations-??.txt");

            foreach (var file in files)
            {
                var filename = Path.Combine(MOD_FOLDER, file.Name);
                var code = file.Name.Substring(13, 2);
                var languageSourceData = LocalizationManager.Sources[0];
                var languageIndex = languageSourceData.GetLanguageIndexFromCode(code);

                if (languageIndex < 0)
                    Error($"language {code} not currently loaded.");
                else
                    using (var sr = new StreamReader(filename))
                    {
                        string line, term, text;
                        while ((line = sr.ReadLine()) != null)
                        {
                            try
                            {
                                var splitted = line.Split(new[] { '\t', ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                term = splitted[0];
                                text = splitted[1];
                            }
                            catch
                            {
                                Error($"invalid translation line \"{line}\".");
                                continue;
                            }
                            if (languageSourceData.ContainsTerm(term))
                            {
                                languageSourceData.RemoveTerm(term);
                                Warning($"official game term {term} was overwritten with \"{text}\"");
                            }
                            languageSourceData.AddTerm(term).Languages[languageIndex] = text;
                        }
                    }
            }
        }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                Logger = modEntry.Logger;

                LoadTranslations();

                Mod = new ModManager<Core, Settings>();
                Mod.Enable(modEntry, assembly);
                Menu = new MenuManager();
                Menu.Enable(modEntry, assembly);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }
    }
}