using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monocle;
using MonoMod.Utils;
using TowerFall;
using Microsoft.Xna.Framework;

namespace TFModFortRisePoto
{
  internal class MyVersusMatchResults
  {
    internal static void Load()
    {
      On.TowerFall.VersusMatchResults.ctor += ctor_patch;
    }

    internal static void Unload()
    {
      On.TowerFall.VersusMatchResults.ctor -= ctor_patch;
    }

    public static void ctor_patch(On.TowerFall.VersusMatchResults.orig_ctor orig, global::TowerFall.VersusMatchResults self, global::TowerFall.Session session, global::TowerFall.VersusRoundResults roundResults)
    {
      if (TFModFortRisePotoModule.Settings.accelerate)
        Engine.TimeRate = TFModFortRisePotoModule.Settings.acceleration;
      orig(self, session, roundResults);
      if (TFModFortRisePotoModule.Settings.accelerate && TFModFortRisePotoModule.Settings.accelerateMatchResultScreen)
      {
        session.CurrentLevel.Add(new PauseMenu(session.CurrentLevel, new Vector2(160f, 200f), PauseMenu.MenuType.VersusMatchEnd));
        self.TweenIn();
      }
    }
  }
}
