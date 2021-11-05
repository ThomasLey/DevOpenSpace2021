namespace DiTryouts.Models
{
    public class PdfGenerator : IPdfGenerator
    {
        public PdfGenerator(IBarcodeGenerator generator, IMyLogger logger)
        {
            logger.Log($"(CTOR) {GetType().Name} => #{GetHashCode()} (GEN=#{generator.GetHashCode()}) (LOG=#{logger.GetHashCode()})");
        }
    }
}