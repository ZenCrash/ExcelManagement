namespace ExcelManagement.DxBlazor.Data
{
    public class AlertMessageModel
    {
        public string Message { get; set; }
        public Guid Guid { get; }

        public AlertMessageModel(string message) 
        {
            Message = message;
            Guid = Guid.NewGuid();
        }
    }
}
