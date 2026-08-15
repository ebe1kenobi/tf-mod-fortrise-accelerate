using FortRise;

namespace TFModFortRiseAccelerate
{
  public class TFModFortRiseAccelerateSettings : ModuleSettings
  {
    public override void Create(ISettingsCreate settings)
    {
      settings.CreateOnOff("Accelerate", accelerate, (x) => accelerate = x);
      settings.CreateNumber("Acceleration", acceleration, (x) => acceleration = x, 1, 20);
      settings.CreateOnOff("Select Random Level Auto", selectRandomLevelAuto, (x) => selectRandomLevelAuto = x);
      settings.CreateOnOff("Accelerate the match result screen", accelerateMatchResultScreen, (x) => accelerateMatchResultScreen = x);
    }

    //[SettingsName("Accelerate")]
    public bool accelerate { get; set; } = false;

    //[SettingsName("Acceleration")]
    //[SettingsNumber(1, 20)]
    public int acceleration { get; set; } = 5;

    //[SettingsName("Select Random Level Auto")]
    public bool selectRandomLevelAuto { get; set; } = false;

    //[SettingsName("Accelerate the match result screen")]
    public bool accelerateMatchResultScreen { get; set; } = false;
  }
}
