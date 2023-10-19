using Backend_Test_Application.Entities;

namespace Backend_Test_Application.Interfaces
{
    public interface IImagePlugin
    {
        MemoryStream ApplyEffect(ExtendedImage image);
    }
}
