using RimWorld;
using System.Linq;
using Verse;

namespace RCP_Core
{
    [StaticConstructorOnStartup]
    public class Initialize
    {
        private const string ModName = "MineralScannerAllOres";

        static Initialize()
        {
            var preciousLump = DefDatabase<SitePartDef>.GetNamed(GenStepDefOf.PreciousLump.ToString());
            var genStep = preciousLump.ExtraGenSteps.First(egs => egs.genStep is GenStep_PreciousLump).genStep as GenStep_PreciousLump;
            
            var minableOres = DefDatabase<ThingDef>
                .AllDefsListForReading
                .Where(def => def.building != null && def.building.isResourceRock && def.building.mineableScatterCommonality > 0 && !genStep.mineables.Contains(def));

            genStep.mineables.AddRange(minableOres);
        }
    }
}