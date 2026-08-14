namespace AppsByTAP.BlazorFluentUI.Components.Forms
{
    public class ValidationResult<T>
    {
        public T Result { get; set; }
        public string ValidationErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
