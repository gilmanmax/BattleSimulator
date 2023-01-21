using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models.Enumerators;
namespace Game.Models.Classes
{
    /*
     * Represents a living entities affinity to an element.
     */
    public class ElementAffinity
    {
        /// <summary>
        /// Type of affinity (e.g: resistance, weakness)
        /// </summary>
        public AffinityType AffinityType { get; set; }
        /// <summary>
        /// Element in question
        /// </summary>
        public Element Element { get; set; }
        /// <summary>
        /// Represents the strength of the affinity. 
        /// </summary>
        public decimal AffinityStrength { get; set; }

        public ElementAffinity(AffinityType affinityType, Element element, decimal affinityStrength = 0.5m)
        {
            if (affinityStrength <= 0m || affinityStrength >= 0.99m)
            {
                throw new Exception("Cannot set affinity at or below zero or higher than 0.99");
            }
            AffinityType = affinityType;
            Element = element;
            AffinityStrength = affinityStrength;
        }

    }
}
