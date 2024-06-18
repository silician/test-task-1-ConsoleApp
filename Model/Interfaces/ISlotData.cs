using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface ISlotData
    {
        string Name { get; }
        int Id { get; }
        int Count { get; }
    }
} 
