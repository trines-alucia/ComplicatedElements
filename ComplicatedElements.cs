using Brimstone;
using Quintessential;

namespace ComplicatedElements;

public class ComplicatedElements : QuintessentialMod
{
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
        ComplicatedElementsParts.AddPartTypes();
        QApi.AddPuzzlePermission("ComplicatedElements: crystallization", "Glyph of Crystallization", "Complicated Elements");
        Quintessential.Logger.Log("Loading complete, yay!");
    }
}
