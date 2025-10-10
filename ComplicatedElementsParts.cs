// Shamelessly stolen from Halving Metallurgy, Misc Glyphs and Unstable Elements
using Quintessential;
using System.Collections.Generic;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;

namespace ComplicatedElements;

using PartTypes = class_191;
using AtomTypes = class_175;


internal static class ComplicatedElementsParts
{
    public static PartType Crystal;

    public static Texture crystalBase = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/crystallization/base");
    public static Texture hole = class_238.field_1989.field_90.field_255.field_293;
    public static Texture bowl = class_238.field_1989.field_90.field_170;

    public static Texture crystalGlow = Brimstone.API.GetTexture("textures/select/alucia/ComplicatedElements/crystallization/glow");
    public static Texture crystalStroke = Brimstone.API.GetTexture("textures/select/alucia/ComplicatedElements/crystallization/stroke");
    public static Texture crystalIcon = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/icons/crystal");
    public static Texture crystalIconHover = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/icons/crystal_hover");

    public static readonly HexIndex crystalInput1 = new(0, 0);
    public static readonly HexIndex crystalInput2 = new(1, 0);

    public static void AddPartTypes()
    {
        Crystal = new()
        {
            field_1528 = "complicated-elements-crystal", // ID
            field_1529 = class_134.method_253("Glyph of Crystallization", string.Empty), // Name
            field_1530 = class_134.method_253("The glyph of Crystallization accepts two atoms and produces a crystal cardinal based on their types. Possible recipies: Fire + Water, Fire + Air, Earth + Air.", string.Empty), // Description
            field_1531 = 40, // Cost
            field_1539 = true, // Is a glyph
            field_1549 = crystalGlow, // Shadow/glow
            field_1550 = crystalStroke, // Stroke/outline
            field_1547 = crystalIcon, // Panel icon
            field_1548 = crystalIconHover, // Hovered panel icon
            field_1540 = new HexIndex[]
            {
                crystalInput1,
                crystalInput2
            },
            field_1551 = Permissions.None,
            CustomPermissionCheck = perms => perms.Contains("ComplicatedElements: crystallization")
        };
        QApi.AddPartTypeToPanel(Crystal, false);

        QApi.AddPartType(Crystal, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 offset = new(42f,48f);
            renderer.method_523(crystalBase, Vector2.Zero, offset, 0f);
            renderer.method_529(bowl, crystalInput1, Vector2.Zero);
            renderer.method_528(hole, crystalInput2, Vector2.Zero);
        });

        QApi.RunAfterCycle((sim, first) =>
        {
            SolutionEditorBase seb = sim.field_3818;
            Dictionary<Part, PartSimState> pss = sim.field_3821;
            List<Part> parts = seb.method_502().field_3919;

            foreach (Part part in parts)
            {
                PartType type = part.method_1159();
                if (type == Crystal) // alucia - me when i steal code from unstable elements
                {
                    if (sim.FindAtomRelative(part, new HexIndex(0, 0)).method_99(out AtomReference gold) //get atom references
                       && sim.FindAtomRelative(part, new(1, 0)).method_99(out AtomReference qs1))
                    {
                        if (ComplicatedElementsAPI.crystalTransmutations.TryGetValue(new(gold.field_2280, qs1.field_2280), out AtomType output)) { //try get value of recipe list
                            if (!qs1.field_2281 && !qs1.field_2282) { // if qs not grabbed and single
                                gold.field_2277.method_1106(output, gold.field_2278); //transform
                                qs1.field_2277.method_1107(qs1.field_2278); //remove
                                seb.field_3937.Add(new class_286(seb, qs1.field_2278, AtomTypes.field_1679)); //animation 1
                                gold.field_2279.field_2276 = new class_168(seb, 0, (enum_132)1, gold.field_2280, class_238.field_1989.field_81.field_614, 30f); //animation 2
                            }
                        }
                    }
                }
            }
        });
    }
}