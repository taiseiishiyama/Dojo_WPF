using System;
using System.Windows.Markup;

namespace Case09.Common
{
    internal class EnumListExtension : MarkupExtension
    {
        private readonly Type _type;

        public EnumListExtension(Type type)
        {
            _type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(_type);
        }
    }
}
