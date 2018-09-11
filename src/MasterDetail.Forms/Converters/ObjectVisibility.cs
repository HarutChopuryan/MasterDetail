using System.Collections;
using MasterDetail.Core.Extensions;

namespace MasterDetail.Forms.Converters
{
    public static class ObjectVisibility
    {
        public static bool IsObjectVisible(object value)
        {
            if (value is bool b) return b;

            bool isVisible = true;
            switch (value)
            {
                case null:
                    isVisible = false;
                    break;
                case IEnumerable enumerable:
                    isVisible = enumerable.Count() != 0;
                    break;
                default:
                    if (string.IsNullOrEmpty(value.ToString()))
                        isVisible = false;
                    break;
            }

            return isVisible;
        }
    }
}