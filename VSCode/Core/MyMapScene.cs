using TowerFall;
using System;
using System.Collections.Generic;
using System.Linq;
using FortRise;
using HarmonyLib;
using Microsoft.Xna.Framework;

namespace TFModFortRiseAccelerate
{
  public class MyMapScene : IHookable
  {
    private static readonly Random rng = new Random();
    private static List<Point> shuffledLevelIds = new List<Point>();
    private static int shuffledLevelIndex = 0;
    private static MapScene lastScene;
    private static bool confirmedForCurrentScene;

    public static void Load(IHarmony harmony)
    {
      harmony.Patch(
          AccessTools.DeclaredMethod(typeof(MapScene), nameof(MapScene.Update)),
          postfix: new HarmonyMethod(Update_patch)
      );
      harmony.Patch(
          AccessTools.DeclaredMethod(typeof(MapScene), "InitButtons"),
          postfix: new HarmonyMethod(InitButtons_patch)
      );
    }

    public static void InitButtons_patch(MapScene __instance, MapButton startSelection)
    {
      __instance.Selection = __instance.Buttons[3];
    }

    public static void Update_patch(MapScene __instance)
    {
      //SaveData.Instance.Options.ReplayMode = Options.ReplayModes.Off; //see Level.PostScreen
      if (__instance.Mode == MainMenu.RollcallModes.Versus && TFModFortRiseAccelerateModule.Settings.selectRandomLevelAuto) {
        if (lastScene != __instance) {
          lastScene = __instance;
          confirmedForCurrentScene = false;
          SelectNextShuffledLevel(__instance);
        }

        if (!confirmedForCurrentScene && __instance.CanAct && !__instance.MatchStarting && !__instance.CanConfirmCounter) {
          confirmedForCurrentScene = true;
          __instance.Selection.Confirmed();
        }
      }
    }

    private static void SelectNextShuffledLevel(MapScene scene)
    {
      List<MapButton> availableLevelButtons = scene.Buttons
        .Where(button => button != null && button.Data != null)
        .ToList();

      if (availableLevelButtons.Count == 0) {
        return;
      }

      List<Point> availableIds = availableLevelButtons
        .Select(button => button.Data.ID)
        .ToList();

      bool orderInvalid = shuffledLevelIds.Count == 0 ||
                          shuffledLevelIds.Count != availableIds.Count ||
                          shuffledLevelIds.Any(id => !availableIds.Contains(id));

      if (orderInvalid || shuffledLevelIndex >= shuffledLevelIds.Count) {
        shuffledLevelIds = new List<Point>(availableIds);
        Shuffle(shuffledLevelIds);
        shuffledLevelIndex = 0;
        LogShuffledLevelIds("reshuffle");
      }

      Point nextId = shuffledLevelIds[shuffledLevelIndex];
      Logger.Info($"Auto level pick index={shuffledLevelIndex} id=({nextId.X},{nextId.Y})");
      shuffledLevelIndex++;

      MapButton nextButton = availableLevelButtons.FirstOrDefault(button => button.Data.ID == nextId);
      if (nextButton != null && scene.Selection != nextButton) {
        scene.SelectLevel(nextButton, true);
        Logger.Info($"Selected level id=({nextId.X},{nextId.Y}) title='{nextButton.Data.Title}' musicFiles='{nextId.X}_{nextId.Y}.wav' or '{nextId.X}.wav'");
      }
    }

    private static void Shuffle<T>(IList<T> list)
    {
      for (int i = list.Count - 1; i > 0; i--) {
        int j = rng.Next(i + 1);
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
      }
    }

    private static void LogShuffledLevelIds(string reason)
    {
      string ids = string.Join(", ", shuffledLevelIds.Select(id => $"({id.X},{id.Y})"));
      Logger.Info($"shuffledLevelIds ({reason}) = [{ids}]");
    }
  }
}
