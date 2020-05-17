using System;

namespace SyberryTask.Logic.Extensions
{
    public static class EnumExtension
    {
        public static string EnumToString<T>(this T convertingEnumElement)
        {
            return Enum.GetName(typeof(T), convertingEnumElement);
        }
    }
}
