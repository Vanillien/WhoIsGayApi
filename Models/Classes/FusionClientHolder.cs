using io.fusionauth;

namespace WhoIsGayApi.Models.Classes;

public static class FusionClientHolder
{
    public static FusionAuthClient FusionAuthClient { get; }

    static FusionClientHolder()
    {
        FusionAuthClient = new FusionAuthClient("vOVpqc512arc6uJF4xtpai7soYRTiQNiW8Ks8iRfKcKU4eVxxz3YH66R", "http://http://localhost:9011/");
    }
}
