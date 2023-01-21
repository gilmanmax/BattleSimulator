using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Classes;
namespace Game.Interfaces
{

    /// <summary>
    /// Represents an entity that can be destroyed
    /// </summary>
    public interface IDestroyable : IEntity
    {
        /// <summary>
        /// Elemental Affinities
        /// </summary>
        IEnumerable<ElementAffinity> ElementalAffinities { get; protected set; }
        /// <summary>
        /// Max HP the entity has*/
        /// </summary>
        int MaxHP { get; protected set; }
        /// <summary>
        /// HP of entity. Upon hitting zero, it is destroyed.
        /// </summary>
        int HP { get; protected set; }
    }
}
