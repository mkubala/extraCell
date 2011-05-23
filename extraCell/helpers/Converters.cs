using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using extraCell.helpers;
using extraCell.domain;

namespace extraCell.helpers
{
    /* konwerter (zawartości) komórki */
    class CellClassConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType.Equals("".GetType());
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType.Equals("".GetType());
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            String result = value.ToString();
            if(!Helpers.mainWindow.getCurrentDoc().extraCellTable.isEditing)
                result = Helpers.mainWindow.getFormula().eval(value.ToString());
            return new Cell(value.ToString(), result);
        }
    }
}
