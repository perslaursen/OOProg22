using RolePlayDemoAug24.Models.Base;
using RolePlayDemoAug24.Models.Damage;

namespace RolePlayDemoAug24.Models
{
    /// <summary>
    /// Represents a set of Armor, where the set can only contain one piece 
    /// of Armor for each Armor Type (i.e. body part).
    /// </summary>
    public class ArmorSet
    {
        private Dictionary<ArmorType, Armor> _armor;
        private DamageResistance? _damageResistance;

        /// <summary>
        /// Returns the aggregated DamageResistance for the entire Amorset.
        /// For efficiency, the value is cached once it is calculated, 
        /// and is only recalculated when the Armorset is updated.
        /// </summary>
        public DamageResistance DamageResistance 
        {
            get 
            { 
                _damageResistance ??= CalcDamageResistance();
                return _damageResistance;
            }
        }

        public ArmorSet(List<Armor>? armorList = null)
        {
            _armor = new Dictionary<ArmorType, Armor>();

            SetArmor(armorList);
        }

        /// <summary>
        /// Updates the Armor corresponding to the Armor Type
        /// of the given Armor.
        /// </summary>
        public void SetArmor(Armor armor)
        {
            _armor[armor.ArmorType] = armor;
            _damageResistance = null;
        }

        /// <summary>
        /// Updates the Armorset to the given List of Armor.
        /// </summary>
        public void SetArmor(List<Armor>? armorList)
        {
            if (armorList != null)
            {
                _armor.Clear();

                foreach (Armor armor in armorList)
                {
                    _armor[armor.ArmorType] = armor;
                }
            }

            _damageResistance = null;
        }

        /// <summary>
        /// Calculates the Damage Resistance resulting from the entire Armor set.
        /// </summary>
        private DamageResistance CalcDamageResistance()
        {
            return new DamageResistance(CalcDamageResistance(DamageType.Fire), CalcDamageResistance(DamageType.Frost),
                                        CalcDamageResistance(DamageType.Necrotic), CalcDamageResistance(DamageType.Physical));
        }

        /// <summary>
        /// Calculates the Damage Resistance for the given Damage type.
        /// (NB: This calculation is somewhat complex).
        /// </summary>
        private double CalcDamageResistance(DamageType damageType)
        {
            // The calculation assumes that damage resistance is "multiplicative".
            // Example: Suppose two pieces of Armor have 50 % and 60 % resistance to Fire, respectively.
            // If resistance was additive, the total resistance would be 50 % + 60 % = 110 %.
            // This definition can thus easily result in resistances over 100 %.
            // With multiplicative resistance, we instead get something like this: 
            //  - First Armor lets (100 - 50) = 50 % of fire damage pass through.
            //  - Second Armor lets (100 - 60) = 40 % of the 50 % of fire damage pass through, i.e. 20 %
            //  - The total resistance becomes (100 - 20) = 80 %
            // Calculating this with fractions becomes:
            //    1.0 - ((1.0 - 0.5) * (1.0 - 0.6)) = 1.0 - (0.5 * 0.4) = 1.0 - 0.2 = 0.8 (= 80 %)
            // Even though this definition might not reflect how the real world works, it does make
            // the issue of how to pick Armor more challenging.

            double passthroughFraction = 1.0;

            foreach (Armor armor in _armor.Values)
            {
                passthroughFraction = passthroughFraction * (1.0 - armor.DamageResistance.GetFraction(damageType));
            }

            return (1.0 - passthroughFraction) * 100.0;
        }
    }
}
