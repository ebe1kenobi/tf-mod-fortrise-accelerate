using FortRise;

namespace TFModFortRisePoto
{
  public class TFModFortRisePotoSettings : ModuleSettings
  {
    [SettingsName("Accelerate")]
    public bool accelerate = false;

    [SettingsName("Acceleration")]
    [SettingsNumber(1, 20)]
    public int acceleration = 15;

    [SettingsName("Select Random Level Auto")]
    public bool selectRandomLevelAuto = false;

    [SettingsName("Accelerate the match result screen")]
    public bool accelerateMatchResultScreen = false;
  }
}
