using FortRise;
using HarmonyLib;
using Monocle;
using TowerFall;

namespace TFModFortRiseAccelerate
{
  public class MyVersusRoundResults : IHookable
  {
    public static void Load(IHarmony harmony)
    {
      harmony.Patch(
          AccessTools.DeclaredMethod(typeof(VersusRoundResults), nameof(VersusRoundResults.Update)),
          prefix: new HarmonyMethod(Update_patch)
      );
    }

    public static void Update_patch(VersusRoundResults __instance)
    {
      if (TFModFortRiseAccelerateModule.Settings.accelerate)
        Engine.TimeRate = TFModFortRiseAccelerateModule.Settings.acceleration;
    }
  }
}
