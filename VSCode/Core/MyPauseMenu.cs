using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerFall;
using Monocle;
using MonoMod.Utils;
using Microsoft.Xna.Framework;

namespace TFModFortRisePoto
{
  internal class MyPauseMenu
  {
    internal static void Load()
    {
      On.TowerFall.PauseMenu.VersusRematch += VersusRematch_patch;
    }

    internal static void Unload()
    {
      On.TowerFall.PauseMenu.VersusRematch -= VersusRematch_patch;
    }


    public static void VersusRematch_patch(On.TowerFall.PauseMenu.orig_VersusRematch orig, global::TowerFall.PauseMenu self)
    {
      if (TFModFortRisePotoModule.Settings.accelerate)
        Engine.TimeRate = TFModFortRisePotoModule.Settings.acceleration;
      orig(self);
    }
  }
}
