using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    /// <summary>
    /// Represents an Entity
    /// </summary>
    public interface IEntity
    {
        /*All entities must have names */
        string Name { get; }

    }
}
