namespace Backend_Test_Application.Requests
{
    public class ImageRequest
    {
        public string EffectsJson { get; set; }
        public IFormFile OriginalImage { get; set; }
    }
}
