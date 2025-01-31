using NUnit.Framework;
using UnityEngine;

public class BackgroundsTest
{
    [Test]
    public void ValidatePropertyWorks_BackgroundDefinition_Texture()
    {
        Assert.IsNotNull(BackgroundRegistry.Get("black").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("hall").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("bedroom").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("classroom").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("testroom").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("campus_overview").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("forest").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("front_gate").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("hallway").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("alchemy").texture);
        Assert.IsNotNull(BackgroundRegistry.Get("empty").texture);
    }
}
