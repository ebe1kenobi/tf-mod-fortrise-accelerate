using FortRise;
using HarmonyLib;
using Microsoft.Xna.Framework;
using Monocle;
using TowerFall;

namespace TFModFortRiseAccelerate
{
  public class MyVersusMatchResults : IHookable
  {
    public static void Load(IHarmony harmony)
    {
      harmony.Patch(
          AccessTools.DeclaredConstructor(typeof(VersusMatchResults), [
                                                                        typeof(Session),
                                                                        typeof(VersusRoundResults),
                                                                     ]),
          prefix: new HarmonyMethod(ctor_prefix_patch),
          postfix: new HarmonyMethod(ctor_postfix_patch)
      );
    }

    public static void ctor_prefix_patch(VersusMatchResults __instance, Session session, VersusRoundResults roundResults)
    {
      if (TFModFortRiseAccelerateModule.Settings.accelerate)
        Engine.TimeRate = TFModFortRiseAccelerateModule.Settings.acceleration;
    }

    public static void ctor_postfix_patch(VersusMatchResults __instance, Session session, VersusRoundResults roundResults)
    {
      if (TFModFortRiseAccelerateModule.Settings.accelerate && TFModFortRiseAccelerateModule.Settings.accelerateMatchResultScreen)
      {
        session.CurrentLevel.Add(new PauseMenu(session.CurrentLevel, new Vector2(160f, 200f), PauseMenu.MenuType.VersusMatchEnd));
        __instance.TweenIn();
      }
    }
  }
}
