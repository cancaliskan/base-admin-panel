namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class ExceptionLog : BaseEntity
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Exception { get; set; }
    }
}