using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extraCell.formula
{
    interface IFunction
    {
        Object run(Object[] args);
    }
}
