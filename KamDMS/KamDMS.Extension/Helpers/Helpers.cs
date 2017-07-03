using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KamDMS.Extension.Helpers
{
    public static class selectListHelper
    {
        public static IEnumerable<SelectListItem> getIntoDropDownState<T>(this List<T> data, string textField, string valueField) where T : class
        {
            var type = typeof(T);

            var textPropertyInfo = type.GetProperty(textField);
            var valuePropertyInfo = type.GetProperty(valueField);

            return data.Select(x => new SelectListItem
            {
                Text = (string)textPropertyInfo.GetValue(x),
                Value = (string)valuePropertyInfo.GetValue(x)
            });
        }
    }
}
