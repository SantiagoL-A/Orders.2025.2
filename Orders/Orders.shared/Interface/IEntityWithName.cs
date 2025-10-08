using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.shared.Interface;

public interface IEntityWithName
{
    string Name { get; set; }
}