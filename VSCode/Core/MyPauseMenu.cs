using FortRise;
using HarmonyLib;
using Monocle;
using TowerFall;

namespace TFModFortRiseAccelerate
{
  public class MyPauseMenu : IHookable
  {
    public static void Load(IHarmony harmony)
    {
      harmony.Patch(
          AccessTools.DeclaredMethod(typeof(PauseMenu), "VersusRematch"),
          prefix: new HarmonyMethod(VersusRematch_patch)
      );
    }

    public static void VersusRematch_patch(PauseMenu __instance)
    {
      if (TFModFortRiseAccelerateModule.Settings.accelerate)
        Engine.TimeRate = TFModFortRiseAccelerateModule.Settings.acceleration;
    }
  }
}
