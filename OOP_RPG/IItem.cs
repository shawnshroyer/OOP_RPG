using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public interface IItem
    {
        int OriginalValue { get; set; }
        int ResellValue { get; set; }
    }
}
