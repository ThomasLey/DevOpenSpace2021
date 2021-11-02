namespace DiTryouts
{
    public class ZXingGenerator : IBarcodeGenerator
    {
        public ZXingGenerator(IMyLogger logger)
        {
            logger.Log($"(CTOR) {GetType().Name} => #{GetHashCode()} (LOG=#{logger.GetHashCode()})");
        }
    }
}