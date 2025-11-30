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
    public static PartType Fusion;
    public static PartType Erosion;

    public static Texture fusionBase = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/fusion/base");
    public static Texture erosionBase = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/erosion/base");
    public static Texture FusionInputTexture = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/fusion/input_ring");
    public static Texture bowl = class_238.field_1989.field_90.field_170;
    public static Texture ErosionBowlTexture = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/erosion/erosion_bowl");

    public static Texture fusionIcon = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/icons/fusion");
    public static Texture fusionIconHover = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/icons/fusion_hover");
    public static Texture erosionIcon = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/icons/erosion");
    public static Texture erosionIconHover = Brimstone.API.GetTexture("textures/parts/alucia/ComplicatedElements/icons/erosion_hover");

    public static readonly HexIndex fusionInput1 = new(0, 0);
    public static readonly HexIndex fusionInput2 = new(1, 0);
    public static readonly HexIndex erosionBowl = new(0, 0);

    public static void AddPartTypes()
    {
        Fusion = new()
        {
            field_1528 = "complicated-elements-fusion", // ID
            field_1529 = class_134.method_253("Glyph of Fusion", string.Empty), // Name
            field_1530 = class_134.method_253("The glyph of Fusion accepts two atoms and produces a crystal atom based on their types. ", string.Empty), // Description
            field_1531 = 20, // Cost
            field_1539 = true, // Is a glyph
            field_1549 = class_238.field_1989.field_97.field_374, // Shadow/glow
            field_1550 = class_238.field_1989.field_97.field_375, // Stroke/outline
            field_1547 = fusionIcon, // Panel icon
            field_1548 = fusionIconHover, // Hovered panel icon
            field_1540 = new HexIndex[]
            {
                fusionInput1,
                fusionInput2
            },
            field_1551 = Permissions.None,
            CustomPermissionCheck = perms => perms.Contains("ComplicatedElements: fusion")
        };
        QApi.AddPartTypeToPanel(Fusion, false);
        QApi.AddPartType(Fusion, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 offset = new(42f, 48f);
            renderer.method_523(fusionBase, Vector2.Zero, offset, 0f);
            renderer.method_529(bowl, fusionInput1, Vector2.Zero);
            renderer.method_529(FusionInputTexture, fusionInput2, Vector2.Zero);
        });
        
        Erosion = new()
        {
            field_1528 = "complicated-elements-erosion", // ID
            field_1529 = class_134.method_253("Glyph of Erosion", string.Empty), // Name
            field_1530 = class_134.method_253("The glyph of Erosion erodes a crystal atom to a Quicklime atom, similar to the Glyph of Calcification. ", string.Empty), // Description
            field_1531 = 20, // Cost
            field_1539 = true, // Is a glyph
            field_1549 = class_238.field_1989.field_97.field_382, // Shadow/glow
            field_1550 = class_238.field_1989.field_97.field_383, // Stroke/outline
            field_1547 = erosionIcon, // Panel icon
            field_1548 = erosionIconHover, // Hovered panel icon
            field_1540 = new HexIndex[]
            {
                erosionBowl
            },
            field_1551 = Permissions.None,
            CustomPermissionCheck = perms => perms.Contains("ComplicatedElements: erosion")
        };
        QApi.AddPartTypeToPanel(Erosion, false);
        QApi.AddPartType(Erosion, static (part, pos, editor, renderer) =>
        {
            PartSimState pss = editor.method_507().method_481(part);
            class_236 uco = editor.method_1989(part, pos);
            float time = editor.method_504();

            Vector2 offset = new(42f, 48f);
            renderer.method_523(erosionBase, Vector2.Zero, offset, 0f);
            renderer.method_529(ErosionBowlTexture, erosionBowl, Vector2.Zero);
        });

        QApi.RunAfterCycle((sim, first) =>
        {
            SolutionEditorBase seb = sim.field_3818;
            Dictionary<Part, PartSimState> pss = sim.field_3821;
            List<Part> parts = seb.method_502().field_3919;

            foreach (Part part in parts)
            {
                PartType type = part.method_1159();
                if (type == Fusion) // alucia - me when i steal code from unstable elements
                {
                    if (sim.FindAtomRelative(part, new HexIndex(0, 0)).method_99(out AtomReference gold) //get atom references
                       && sim.FindAtomRelative(part, new(1, 0)).method_99(out AtomReference qs1))
                    {
                        if (!qs1.field_2281 && !qs1.field_2282) // if qs not grabbed and single
                        {
                            foreach (ComplicatedElementsAPI.CrystallizationRecipe r in ComplicatedElementsAPI.crystalTransmutations) //// thank you Greenfield for helping me with this
                            {
                                if (r.IsMatch(gold.field_2280, qs1.field_2280))
                                {
                                    gold.field_2277.method_1106(r.output, gold.field_2278); //transform
                                    qs1.field_2277.method_1107(qs1.field_2278); //remove
                                    seb.field_3937.Add(new class_286(seb, qs1.field_2278, qs1.field_2280)); //animation 1
                                    gold.field_2279.field_2276 = new class_168(seb, 0, (enum_132)1, gold.field_2280, class_238.field_1989.field_81.field_614, 30f); //animation 2
                                    break;
                                }
                                else if (r.IsMatch(qs1.field_2280, gold.field_2280)) // my attempt at a reverse order check which actually worked
                                {
                                    gold.field_2277.method_1106(r.output, gold.field_2278); //transform
                                    qs1.field_2277.method_1107(qs1.field_2278); //remove
                                    seb.field_3937.Add(new class_286(seb, qs1.field_2278, qs1.field_2280)); //animation 1
                                    gold.field_2279.field_2276 = new class_168(seb, 0, (enum_132)1, gold.field_2280, class_238.field_1989.field_81.field_614, 30f); //animation 2
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (type == Erosion) // ah, shit, here we go again
                {
                    if (sim.FindAtomRelative(part, new HexIndex(0, 0)).method_99(out AtomReference erosionInputAtom))
                    {
                        foreach (ComplicatedElementsAPI.ErosionAtoms r1 in ComplicatedElementsAPI.ErosionAtomsList)
                        {
                            if (r1.IsMatch(erosionInputAtom.field_2280, ComplicatedElementsAtoms.Quicklime))
                            {
                                erosionInputAtom.field_2277.method_1106(r1.output, erosionInputAtom.field_2278); //transform
                                // seb.field_3937.Add(new class_286(seb, qs1.field_2278, qs1.field_2280)); //animation 1
                                erosionInputAtom.field_2279.field_2276 = new class_168(seb, 0, (enum_132)1, erosionInputAtom.field_2280, class_238.field_1989.field_81.field_614, 30f); //animation 2
                                break;
                            }
                        }
                    }
                }
            }
        });
    }
}