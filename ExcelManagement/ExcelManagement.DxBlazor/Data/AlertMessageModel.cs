namespace ExcelManagement.DxBlazor.Data
{
    public class AlertMessageModel
    {
        public string Message { get; set; }
        public Guid Guid { get; }
        public MessageType Type { get; set; }

        public AlertMessageModel(string message, MessageType type)
        {
            Message = message;
            Guid = Guid.NewGuid();
            Type = type;
        }

        public AlertMessageModel(AlertType alertType, string messageArg1 = null!, string messageArg2 = null!, string messageArg3 = null!, string messageArg4 = null!)
        {
            Guid = Guid.NewGuid();
            switch (alertType)
            {
                //---------//
                /* Success */
                //---------//
                case AlertType.OperationSuccess:
                    Message = $"Operation was successfully executed!";
                    Type = MessageType.Success;
                    break;

                //File
                case AlertType.DirectoryFound:
                    Message = $"success";
                    Type = MessageType.Success;
                    break;
                case AlertType.FileFound:
                    Message = $"success";
                    Type = MessageType.Info;
                    break;
                case AlertType.FileAccessable:
                    Message = $"File was successfully accessed!";
                    Type = MessageType.Info;
                    break;
                case AlertType.DownloadSuccess:
                    Message = $"File has been downloaded successfully!";
                    Type = MessageType.Success;
                    break;
                case AlertType.UploadSuccess:
                    Message = $"File has been uploaded sucessfully!";
                    Type = MessageType.Success;
                    break;

                //Excel Book
                case AlertType.NewBookSuccess:
                    Message = $"A new excel document has sucessfully been created!";
                    Type = MessageType.Success;
                    break;
                case AlertType.NewSheetSuccess:
                    Message = $"A new sheet has sucessfully been added!";
                    Type = MessageType.Success;
                    break;

                //Excel Sheet
                case AlertType.NewRowSuccess:
                    Message = $"New row has successfully been added!";
                    Type = MessageType.Success;
                    break;
                case AlertType.EditRowSuccess:
                    Message = $"Row has successfully been edited!";
                    Type = MessageType.Success;
                    break;
                case AlertType.DeleteRowSuccess:
                    Message = $"Row has sucessfully been deleted!";
                    Type = MessageType.Success;
                    break;

                //--------//
                /* Failed */
                //--------//
                case AlertType.OperationFailed:
                    Message = $"Error 418: Failed to execute operation!";
                    Type = MessageType.Success;
                    break;

                //File
                case AlertType.DirectoryNotFound:
                    Message = $"Error 404: Failed to find directory! (Please make sure that the directory exists)";
                    Type = MessageType.Warning;
                    break;
                case AlertType.FileNotFound:
                    Message = $"Error 404: Failed to find file! (Please make sure that the file exists)";
                    Type = MessageType.Warning;
                    break;
                case AlertType.FileInaccessible:
                    Message = $"Error 417: Failed to access file! (Server administrator is currently accessing the file)";
                    Type = MessageType.Warning;
                    break;
                case AlertType.DownloadFailed:
                    Message = $"Error 417: Failed to download file!";
                    Type = MessageType.Danger;
                    break;
                case AlertType.UploadFailed:
                    Message = $"File: {messageArg1} Error: {messageArg2}";
                    Type = MessageType.Danger;
                    break;

                //Excel Book
                case AlertType.NewBookFailed:
                    Message = $"Error 417: Failed to create a new excel Document!";
                    Type = MessageType.Danger;
                    break;
                case AlertType.NewSheetFailed:
                    Message = $"Error 417: Failed to create a new sheet!";
                    Type = MessageType.Danger;
                    break;

                //Excel Sheet
                case AlertType.NewRowFailed:
                    Message = $"Error 417: Failed to create a new row!";
                    Type = MessageType.Danger;
                    break;
                case AlertType.EditRowFailed:
                    Message = $"Error 417: Failed to edit row!";
                    Type = MessageType.Danger;
                    break;
                case AlertType.DeleteRowFailed:
                    Message = $"Error 417: Failed to delete row!";
                    Type = MessageType.Danger;
                    break;
                case AlertType.ExceededMaxFileLimit:
                    Message = $"Error: Attempting to upload {messageArg1} files, but only {messageArg2} file(s) are allowed!";
                    Type = MessageType.Danger;
                    break;

                    //-------//
                    /* Other */
                    //-------//
            }
        }
        public enum AlertType
        {
            /*Sucess*/
            OperationSuccess,
            //File
            DirectoryFound,
            FileFound,
            FileAccessable,
            DownloadSuccess,
            UploadSuccess,
            //Excel Book
            NewBookSuccess,
            NewSheetSuccess,
            //Excel Sheet
            NewRowSuccess,
            EditRowSuccess,
            DeleteRowSuccess,

            /*Failed*/
            OperationFailed,
            //File
            DirectoryNotFound,
            FileNotFound,
            FileInaccessible,
            DownloadFailed,
            UploadFailed,
            ExceededMaxFileLimit,
            //Excel Book
            NewBookFailed,
            NewSheetFailed,
            //Excel Sheet
            NewRowFailed,
            EditRowFailed,
            DeleteRowFailed,

            /*Other*/
        }

        public enum MessageType
        {
            Primary,
            Secondary,
            Success,
            Danger,
            Warning,
            Info,
            Light,
            Dark
        }

    }
}