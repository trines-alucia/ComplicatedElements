using Quintessential;
using System.Collections.Generic;
using AtomTypes = class_175;

namespace ComplicatedElements;

public static class ComplicatedElementsAPI
{
    public struct CrystallizationRecipe // thanks to ErikHaag for helping me with this
    {
        public CrystallizationRecipe(AtomType input, AtomType reagent, AtomType output)
        {
            this.input = input;
            this.reagent = reagent;
            this.output = output;
        }

        public bool IsMatch(AtomType input, AtomType reagent)
        {
            return this.input == input && this.reagent == reagent;
        }

        public AtomType input;
        public AtomType reagent;
        public AtomType output;
    }


    public static List<CrystallizationRecipe> crystalTransmutations = new(); // Input, Reagent, Output

    public static void AddTransmutations()
    {
        crystalTransmutations.Add(new(AtomTypes.field_1678, AtomTypes.field_1679, ComplicatedElementsAtoms.Amethyst));
        crystalTransmutations.Add(new(AtomTypes.field_1678, AtomTypes.field_1676, ComplicatedElementsAtoms.Citrine));
        crystalTransmutations.Add(new(AtomTypes.field_1677, AtomTypes.field_1676, ComplicatedElementsAtoms.Azurine));
    }
}