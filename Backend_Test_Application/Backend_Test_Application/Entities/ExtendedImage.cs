namespace Backend_Test_Application.Entities
{
    public class ExtendedImage
    {
        public IFormFile OriginalImage { get; set; }
        public List<ImageEffect> Effects { get; set; }
    }
}
