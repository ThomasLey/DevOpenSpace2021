namespace DiTryouts
{
    public class QrCoderGenerator : IBarcodeGenerator
    {
        public QrCoderGenerator(IMyLogger logger)
        {
            logger.Log($"(CTOR) {GetType().Name} => #{GetHashCode()} (LOG=#{logger.GetHashCode()})");
        }
    }
}