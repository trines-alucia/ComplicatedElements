using Brimstone;
using Quintessential;

namespace ComplicatedElements;

public class ComplicatedElements : QuintessentialMod
{
    public static readonly bool HalvingMetallurgyLoaded = Brimstone.API.IsModLoaded("HalvingMetallurgy");
    public override void PostLoad()
    {
        //ignore
    }
    public override void Load()
    {
        Quintessential.Logger.Log("ComplicatedElements: Registered");
    }
    public override void Unload()
    {
        Quintessential.Logger.Log("ComplicatedElements: Unloaded");
    }

    public override void LoadPuzzleContent()
    {
        Quintessential.Logger.Log("ComplicatedElements: Loading!");
        ComplicatedElementsAtoms.AddAtomTypes();
        ComplicatedElementsAPI.AddTransmutations();
        ComplicatedElementsAPI.AddErosionAtoms();
        ComplicatedElementsParts.AddPartTypes();
        QApi.AddPuzzlePermission("ComplicatedElements: fusing", "Glyph of Fusing", "Complicated Elements");
        QApi.AddPuzzlePermission("ComplicatedElements: erosion", "Glyph of Erosion", "Complicated Elements");
        Quintessential.Logger.Log("Loading complete, yay!");
    }
}
