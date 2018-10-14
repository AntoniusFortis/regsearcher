using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegSearcher
{
    /*
     * Решить баг с поиском в hklm
     */
    public class Searcher
    {
        private static Searcher _instance;
        
        public static Searcher GetInstance() => _instance ?? (_instance = new Searcher());

        /// <summary>Список найденных разделов</summary>
        public readonly List<string> FoundRoots = new List<string>();

        /// <summary>Флаг прекращение поиска</summary>
        public bool StopSearch;

        /// <summary>Значение для поиска (берётся из TargetTbox)</summary>
        public string Target;

        /// <summary>Перечисление всех доступных типов поиска</summary>
        public enum SearchModes
        {
            Variables,
            Roots,
            Values
        }
        /// <summary>Текущий режим поиска</summary>
        public SearchModes CurrentSearchMode = SearchModes.Roots;

        /// <summary>Целая строка или составная часть строки</summary>
        public bool IsUnitString;

        /// <summary>Чувствительность к регистру </summary>
        public StringComparison ComparisonType = StringComparison.OrdinalIgnoreCase;

        /// <summary>Коллекция путей реестра, где осуществляется поиск</summary>
        public List<Hive> HivesList { get; private set; }

        public void AddHive(RegistryKey registryKey, bool selected = false)
        {
            if (HivesList == null)
                HivesList = new List<Hive>();

            HivesList.Add(new Hive
            {
                RegKey = registryKey,
                IsSelected = selected
            });
        }

        public void SearchVariables(RegistryKey key)
        {
            if (StopSearch)
                return;

            string keyName = key.Name;
            string[] subKeys = key.GetSubKeyNames(), values = key.GetValueNames();

            Parallel.ForEach(values, (val, loopState) =>
            {
                if (StopSearch)
                    loopState.Stop();

                if (IsSuitable(val))
                    FoundRoots.Add($"{keyName}\\{val}");
            });

            Parallel.ForEach(subKeys, (subkey, loopState) =>
            {
                if (StopSearch)
                    loopState.Stop();

                SearchValues(key.OpenSubKey(subkey));
            });
        }

        public void SearchValues(RegistryKey key)
        {
            if (StopSearch)
                return;

            string keyName = key.Name;
            string[] subKeys = key.GetSubKeyNames(), values = key.GetValueNames();

            Parallel.ForEach(values, (val, loopState) =>
            {
                if (StopSearch)
                    loopState.Stop();

                if (IsSuitable(key.GetValue(val).ToString()))
                    FoundRoots.Add($"{keyName}\\{val}");
            });

            Parallel.ForEach(subKeys, (subkey, loopState) =>
            {
                if (StopSearch)
                    loopState.Stop();

                SearchValues(key.OpenSubKey(subkey));
            });
        }

        public void SearchRoots(RegistryKey key)
        {
            if (StopSearch)
                return;

            string keyName = key.Name;
            string[] subKeys = key.GetSubKeyNames();

            Parallel.ForEach(subKeys, (subkey, loopState) =>
            {
                if (StopSearch)
                    loopState.Stop();

                if (IsSuitable(subkey))
                    FoundRoots.Add($"{keyName}\\{subkey}");

                SearchRoots(key.OpenSubKey(subkey));
            });
        }

        private bool IsSuitable(string str)
        {
            var suitable = IsUnitString ? str.Equals(Target, ComparisonType)
                : str.Contains(Target, ComparisonType);
            return suitable;
        }
    }
}