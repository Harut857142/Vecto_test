using Backend_Test_Application.Entities;
using Backend_Test_Application.Enums;
using Backend_Test_Application.Interfaces;
using SixLabors.ImageSharp.Formats.Png;


namespace Backend_Test_Application.Plugins
{
    public class PluginSample : IImagePlugin
    {
        public MemoryStream ApplyEffect(ExtendedImage image)
        {
            using (var stream = new MemoryStream())
            {
                image.OriginalImage.CopyTo(stream);

                using (var imageStream = Image.Load(stream.ToArray()))
                {
                    foreach (var item in image.Effects)
                    {
                        if (Enum.TryParse(item.EffectType, out EffectEnum e))
                        {
                            switch (e)
                            {
                                case EffectEnum.Size:
                                    imageStream.Mutate(x => x.Resize(new ResizeOptions
                                    {
                                        Size = new Size(item.ParameterValue, item.ParameterValue),
                                        Mode = ResizeMode.Max
                                    }));
                                    break;

                                case EffectEnum.Blur:
                                    imageStream.Mutate(x => x.GaussianBlur(item.ParameterValue));
                                    break;

                                case EffectEnum.GrayScale:
                                    if (item.ParameterValue > 1) item.ParameterValue = 1;
                                    imageStream.Mutate(x => x.Grayscale(item.ParameterValue));
                                    break;
                            }
                        }
                    }

                    var output = new MemoryStream();
                    imageStream.Save(output, new PngEncoder());

                    return output;
                }
            }
        }
    }
}
