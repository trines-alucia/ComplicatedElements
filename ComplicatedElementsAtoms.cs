using Brimstone;
using Quintessential;

namespace ComplicatedElements;

public static class ComplicatedElementsAtoms
{
    public static AtomType Vaprorine, Pyrolite, Aerolith, Mistaline, Ignistal, Terramarine, Quicklime;

    public static void AddAtomTypes()
    {
        Vaprorine = Brimstone.API.CreateNormalAtom(
            ID: 150, 
            modName: "ComplicatedElements",
            name: "Vaprorine",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_symbol",
            pathToDiffuse: "textures/atoms/alucia/ComplicatedElements/Normals/Vaprorine_diffuse"
        );
        Pyrolite = Brimstone.API.CreateNormalAtom(
            ID: 151, 
            modName: "ComplicatedElements",
            name: "Pyrolite",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_symbol",
            pathToDiffuse: "textures/atoms/alucia/ComplicatedElements/Normals/Pyrolite_diffuse"
        );
        Aerolith = Brimstone.API.CreateNormalAtom(
            ID: 152, 
            modName: "ComplicatedElements",
            name: "Aerolith",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_symbol",
            pathToDiffuse: "textures/atoms/alucia/ComplicatedElements/Normals/Aerolith_diffuse"
        );
        Mistaline = Brimstone.API.CreateNormalAtom(
            ID: 153, 
            modName: "ComplicatedElements",
            name: "Mistaline",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_symbol",
            pathToDiffuse: "textures/atoms/alucia/ComplicatedElements/Normals/Mistaline_diffuse"
        );
        Ignistal = Brimstone.API.CreateNormalAtom(
            ID: 154, 
            modName: "ComplicatedElements",
            name: "Ignistal",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_symbol",
            pathToDiffuse: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_diffuse"
        );
        Terramarine = Brimstone.API.CreateNormalAtom(
            ID: 155, 
            modName: "ComplicatedElements",
            name: "Terramarine",
            pathToSymbol: "textures/atoms/alucia/ComplicatedElements/Normals/Ignistal_symbol",
            pathToDiffuse: "textures/atoms/alucia/ComplicatedElements/Normals/Terramarine_diffuse"
        );
        Quicklime = Brimstone.API.CreateNormalAtom(
            ID: 132, 
            modName: "HalvingMetallurgy",
            name: "Quicklime",
            pathToSymbol: "textures/atoms/erikhaag/HalvingMetallurgy/quicklime_symbol",
            pathToDiffuse: "textures/atoms/erikhaag/HalvingMetallurgy/quicklime_diffuse"
        );
        QApi.AddAtomType(Vaprorine);
        QApi.AddAtomType(Pyrolite);
        QApi.AddAtomType(Aerolith);
        QApi.AddAtomType(Mistaline);
        QApi.AddAtomType(Ignistal);
        QApi.AddAtomType(Terramarine);
        if (!ComplicatedElements.HalvingMetallurgyLoaded)
        {
            QApi.AddAtomType(Quicklime);
        }
    }
}