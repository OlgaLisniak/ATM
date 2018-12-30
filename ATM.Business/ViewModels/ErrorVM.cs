namespace ATM.Business.ViewModels
{
    public class ErrorVM
    {
        public string Message { get; set; }

        public ErrorVM(string message)
        {
            Message = message;
        }
    }

}
