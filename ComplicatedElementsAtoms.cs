using Brimstone;
using Quintessential;

namespace ComplicatedElements;

public static class ComplicatedElementsAtoms
{
    public static AtomType Amethyst, Citrine, Azurine;

    public static void AddAtomTypes()
    {
        Amethyst = Brimstone.API.CreateCardinalAtom(
            ID: 150, 
            modName: "ComplicatedElements",
            name: "Amethyst",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/cardinals/amethyst_symbol",
            pathToBase: "textures/atoms/alucia/ComplicatedElements/cardinals/amethyst_base",
            pathToFog: "textures/atoms/alucia/ComplicatedElements/cardinals/amethyst_fog",
            pathToRim: "textures/atoms/alucia/ComplicatedElements/cardinals/atom_rim",
            pathToShadow: "textures/atoms/alucia/ComplicatedElements/cardinals/amethyst_shadow"
        );
        Citrine = Brimstone.API.CreateCardinalAtom(
            ID: 151, 
            modName: "ComplicatedElements",
            name: "Citrine",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/cardinals/citrine_symbol",
            pathToBase: "textures/atoms/alucia/ComplicatedElements/cardinals/citrine_base",
            pathToFog: "textures/atoms/alucia/ComplicatedElements/cardinals/nam_atom_fog",
            pathToRim: "textures/atoms/alucia/ComplicatedElements/cardinals/atom_rim",
            pathToShadow: "textures/atoms/alucia/ComplicatedElements/cardinals/citrine_shadow"
        );
        Azurine = Brimstone.API.CreateCardinalAtom(
            ID: 152, 
            modName: "ComplicatedElements",
            name: "Azurine",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/cardinals/azurine_symbol",
            pathToBase: "textures/atoms/alucia/ComplicatedElements/cardinals/azurine_base",
            pathToFog: "textures/atoms/alucia/ComplicatedElements/cardinals/nam_atom_fog",
            pathToRim: "textures/atoms/alucia/ComplicatedElements/cardinals/atom_rim",
            pathToShadow: "textures/atoms/alucia/ComplicatedElements/cardinals/azurine_shadow"
        );
        QApi.AddAtomType(Amethyst);
        QApi.AddAtomType(Citrine);
        QApi.AddAtomType(Azurine);
    }
}