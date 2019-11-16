
using DarkCrystal.Localization;
using MessagePack;
using MessagePack.Formatters;

namespace DarkCrystal.Serialization
{
    public class LocalizableTextResolver : IFormatterResolver
    {
        public static IFormatterResolver Instance = new LocalizableTextResolver();

        LocalizableTextResolver()
        {
        }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                if (typeof(T) == typeof(LocalizableText))
                {
                    formatter = new LocalizableTextFormatter() as IMessagePackFormatter<T>;
                }
            }
        }
    }
}