// https://github.com/MoonGateLabs/i18n-unity-csharp
namespace I18nSupport {
  public class I18n : Mgl.I18n {
    protected static readonly I18n instance = new I18n();

    protected static string[] locales = new string[] {
      "en-US",
      "ko-KR",
    };

    public static I18n Instance {
      get {
        return instance;
      }
    }
  }
}
