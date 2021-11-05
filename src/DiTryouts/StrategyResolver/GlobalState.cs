using DiTryouts.Models;

namespace DiTryouts
{
    public class GlobalState
    {
        // ReSharper disable once InconsistentNaming
        public string IBarcodeGenerator { get; set; } = nameof(ZXingGenerator);
    }
}