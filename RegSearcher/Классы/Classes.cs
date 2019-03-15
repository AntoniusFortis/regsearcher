using System;

namespace RegSearcher
{
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
}
