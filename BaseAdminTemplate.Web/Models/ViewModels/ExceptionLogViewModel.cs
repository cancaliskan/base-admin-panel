namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class ExceptionLogViewModel : BaseViewModel
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Exception { get; set; }
    }
}