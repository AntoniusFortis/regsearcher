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
        public List<string> FoundRoots { get; }

        /// <summary>Флаг прекращение поиска</summary>
        private bool Running { get; set; }

        /// <summary>Значение для поиска</summary>
        public string Target { private get; set; }

        /// <summary>Перечисление всех доступных типов поиска</summary>
        public enum SearchModes { Variables, Roots, Values }

        /// <summary>Текущий режим поиска</summary>
        public SearchModes CurrentMode { get; set; }

        /// <summary>Целая строка или составная часть строки</summary>
        public bool IsUnitString { get; set; }

        /// <summary>Чувствительность к регистру </summary>
        public StringComparison ComparisonType { get; set; }

        /// <summary>Коллекция путей реестра, где осуществляется поиск</summary>
        public List<ValueTuple<RegistryKey, bool>> HivesList { get; }

        private Searcher()
        {
            FoundRoots = new List<string>();
            CurrentMode = SearchModes.Roots;
            ComparisonType = StringComparison.OrdinalIgnoreCase;
            HivesList = new List<ValueTuple<RegistryKey, bool>>();
        }

        public void AddHive(RegistryKey key, bool selected = false) => HivesList?.Add(new ValueTuple<RegistryKey, bool>(key, selected));

        public void Start(IEnumerable<ValueTuple<RegistryKey, bool>> hives)
        {
            Action<RegistryKey> action;

            switch (CurrentMode)
            {
                case SearchModes.Variables:
                {
                    action = SearchVariables;
                    break;
                }
                case SearchModes.Values:
                {
                    action = SearchValues;
                    break;
                }
                case SearchModes.Roots:
                {
                    action = SearchRoots;
                    break;
                }
                default:
                {
                    return;
                }
            }

            Running = true;

            Parallel.ForEach(hives, hive => action(hive.Item1));
        }

        public void Stop()
        {
            Running = false;
        }

        private void SearchVariables(RegistryKey key)
        {
            if (!Running)
                return;

            string keyName = key.Name;
            string[] subKeys = key.GetSubKeyNames(), values = key.GetValueNames();

            Parallel.ForEach(values, (val, loopState) =>
            {
                if (!Running)
                    loopState.Stop();

                if (IsSuitable(val))
                    FoundRoots.Add($"{keyName}\\{val}");
            });

            Parallel.ForEach(subKeys, (subkey, loopState) =>
            {
                if (!Running)
                    loopState.Stop();

                SearchValues(key.OpenSubKey(subkey));
            });
        }

        private void SearchValues(RegistryKey key)
        {
            if (!Running)
                return;

            string keyName = key.Name;
            string[] subKeys = key.GetSubKeyNames(), values = key.GetValueNames();

            Parallel.ForEach(values, (val, loopState) =>
            {
                if (!Running)
                    loopState.Stop();

                if (IsSuitable(key.GetValue(val).ToString()))
                    FoundRoots.Add($"{keyName}\\{val}");
            });

            Parallel.ForEach(subKeys, (subkey, loopState) =>
            {
                if (!Running)
                    loopState.Stop();

                SearchValues(key.OpenSubKey(subkey));
            });
        }

        private void SearchRoots(RegistryKey key)
        {
            if (!Running)
                return;

            string keyName = key.Name;
            string[] subKeys = key.GetSubKeyNames();

            Parallel.ForEach(subKeys, (subkey, loopState) =>
            {
                if (!Running)
                    loopState.Stop();

                if (IsSuitable(subkey))
                    FoundRoots.Add($"{keyName}\\{subkey}");

                SearchRoots(key.OpenSubKey(subkey));
            });
        }

        private bool IsSuitable(string str)
        {
            var suitable = IsUnitString ? str.Equals(Target, ComparisonType) : str.Contains(Target, ComparisonType);
            return suitable;
        }
    }
}