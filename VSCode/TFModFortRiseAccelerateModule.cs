//compatible 8 joueur life/handicap/respawn X

using System;
using System.Diagnostics;
using System.IO;
using FortRise;
using Microsoft.Extensions.Logging;

//CHAR_A_DIE -> orange aie
//    *         ouille
namespace TFModFortRiseAccelerate
{
  public class TFModFortRiseAccelerateModule : Mod
  {
    public static TFModFortRiseAccelerateModule Instance;

    internal Type[] Hookables = [
        typeof(MyVersusRoundResults),
        typeof(MyPauseMenu),
        typeof(MyVersusMatchResults),
        typeof(MyMapScene),
    ];

    public static TFModFortRiseAccelerateSettings Settings => Instance.GetSettings<TFModFortRiseAccelerateSettings>()!;

    public TFModFortRiseAccelerateModule(IModContent content, IModuleContext context, ILogger logger) : base(content, context, logger)
    {
      if (!Debugger.IsAttached)
      {
        //Debugger.Launch(); // Proposera d’attacher Visual Studio
      }
      Instance = this;

      // FortRise 5 vit hors du repertoire de TowerFall : on ecrit les logs dans
      // l'espace de sauvegarde du mod, pas dans un chemin relatif au jeu.
      TFModFortRiseAccelerate.Logger.Init(
          Path.Combine(ModIO.GetRootPath(), "Saves", Meta.Name));

      foreach (var hookable in Hookables)
      {
        hookable.GetMethod(nameof(IHookable.Load))!.Invoke(null, [context.Harmony]);
      }
    }

    public override ModuleSettings CreateSettings()
    {
      return new TFModFortRiseAccelerateSettings();
    }
  }
}
