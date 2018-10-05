using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace PradApp_Master___Utilizer
{
    public static class Searcher
    {
        /// <summary>Перечисление всех доступных типов поиска</summary>
        public enum SearchModes
        {
            Variables,
            Roots,
            Values
        }
        /// <summary>Текущий режим поиска</summary>
        public static SearchModes CurrentSearchMode = SearchModes.Roots;

        /// <summary>Целая строка или составная часть строки</summary>
        public static bool IsUnitString;

        /// <summary>
        ///  Чувствительность к регистру
        /// </summary>
        public static StringComparison ComparisonType = StringComparison.OrdinalIgnoreCase;

        /// <summary>Коллекция путей реестра, где осуществляется поиск</summary>
        public static List<Hive> HivesList { get; private set; }

        public static void AddHive(RegistryKey registryKey, bool selected = false)
        {
            if (HivesList == null)
                HivesList = new List<Hive>();

            HivesList.Add(new Hive
            {
                RegKey = registryKey,
                IsSelected = selected
            });
        }
    }

    public static class Consts
    {
        public const string Hkcr = "HKEY_CLASSES_ROOT";
        public const string Hkcu = "HKEY_CURRENT_USER";
        public const string Hkcc = "HKEY_CURRENT_CONFIG";
        public const string Hklm = "HKEY_LOCAL_MACHINE";
        public const string Hku = "HKEY_USERS";
    }

    public static class StringExtensions
    {
        /// <summary>Проверяет входит ли данная строка или её части в другую строку</summary>
        /// <param name="str">Строка, у которой проверяется вхождение</param>
        /// <param name="substring">Строка, проверяемая на вхождение в первую строку</param>
        /// <param name="comp">Тип проверки вхождения</param>
        /// <returns>Результат проверки вхождения второй строки в первую</returns>
        public static bool Contains(this string str, string substring, StringComparison comp)
        {
            return str.IndexOf(substring, comp) > -1;
        }
    }

    /// <summary>Структура, представляющая элемент коллекции путей реестра
    /// </summary>
    public struct Hive
    {
        /// <summary>
        /// Отдельный ключ реестра
        /// </summary>
        public RegistryKey RegKey;
        /// <summary>Флаг, обозначающий, выбран ли путь для поиска</summary>
        public bool IsSelected;
    }
}
