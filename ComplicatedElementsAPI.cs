using System.Collections.Generic;
using Quintessential;
using AtomTypes = class_175;

namespace ComplicatedElements;

public static class ComplicatedElementsAPI
{
    public static Dictionary<Pair<AtomType, AtomType>, AtomType> crystalTransmutations = new(); // Input, Reagent, Output

    public static void AddTransmutations()
    {
        crystalTransmutations.Add(new(AtomTypes.field_1678, AtomTypes.field_1679), ComplicatedElementsAtoms.Amethyst);
        crystalTransmutations.Add(new(AtomTypes.field_1678, AtomTypes.field_1676), ComplicatedElementsAtoms.Citrine);
        crystalTransmutations.Add(new(AtomTypes.field_1677, AtomTypes.field_1676), ComplicatedElementsAtoms.Azurine);
    }
}