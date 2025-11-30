using Quintessential;
using System.Collections.Generic;
using AtomTypes = class_175;

namespace ComplicatedElements;

public static class ComplicatedElementsAPI
{
    public struct CrystallizationRecipe // thank you Greenfield for helping me with this
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
    public struct ErosionAtoms
    {
        public ErosionAtoms(AtomType input, AtomType output)
        {
            this.input = input;
            this.output = output;
        }

        public bool IsMatch(AtomType input, AtomType reagent)
        {
            return this.input == input;
        }

        public AtomType input;
        public AtomType output;
    }


    public static List<CrystallizationRecipe> crystalTransmutations = new(); // Input, Reagent, Output
    public static List<ErosionAtoms> ErosionAtomsList = new(); // Input, Output

    public static void AddTransmutations()
    { //76: air, 77: earth, 78: fire, 79: water, 90: quintessence.
        crystalTransmutations.Add(new(AtomTypes.field_1676, AtomTypes.field_1677, ComplicatedElementsAtoms.Aerolith));
        crystalTransmutations.Add(new(AtomTypes.field_1676, AtomTypes.field_1678, ComplicatedElementsAtoms.Ignistal));
        crystalTransmutations.Add(new(AtomTypes.field_1676, AtomTypes.field_1679, ComplicatedElementsAtoms.Mistaline));
        crystalTransmutations.Add(new(AtomTypes.field_1677, AtomTypes.field_1678, ComplicatedElementsAtoms.Pyrolite));
        crystalTransmutations.Add(new(AtomTypes.field_1677, AtomTypes.field_1679, ComplicatedElementsAtoms.Terramarine));
        crystalTransmutations.Add(new(AtomTypes.field_1679, AtomTypes.field_1678, ComplicatedElementsAtoms.Vaprorine));
        crystalTransmutations.Add(new(ComplicatedElementsAtoms.Vaprorine, ComplicatedElementsAtoms.Aerolith, AtomTypes.field_1690));
        crystalTransmutations.Add(new(ComplicatedElementsAtoms.Mistaline, ComplicatedElementsAtoms.Pyrolite, AtomTypes.field_1690));
        crystalTransmutations.Add(new(ComplicatedElementsAtoms.Ignistal, ComplicatedElementsAtoms.Terramarine, AtomTypes.field_1690));
    }
    public static void AddErosionAtoms()
    {
        ErosionAtomsList.Add(new(ComplicatedElementsAtoms.Ignistal, ComplicatedElementsAtoms.Quicklime));
        ErosionAtomsList.Add(new(ComplicatedElementsAtoms.Aerolith, ComplicatedElementsAtoms.Quicklime));
        ErosionAtomsList.Add(new(ComplicatedElementsAtoms.Pyrolite, ComplicatedElementsAtoms.Quicklime));
        ErosionAtomsList.Add(new(ComplicatedElementsAtoms.Terramarine, ComplicatedElementsAtoms.Quicklime));
        ErosionAtomsList.Add(new(ComplicatedElementsAtoms.Mistaline, ComplicatedElementsAtoms.Quicklime));
        ErosionAtomsList.Add(new(ComplicatedElementsAtoms.Vaprorine, ComplicatedElementsAtoms.Quicklime));

    }
}