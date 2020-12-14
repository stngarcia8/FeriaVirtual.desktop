namespace FeriaVirtual.Domain.Dto{

    public class ReportRecipientsDto{

        public string Name{ get; set; }
        public string Email{ get; set; }
        public string Filename{ get; set; }
        public string Subject{ get; set; }
        public string Message{ get; set; }


        public ReportRecipientsDto(){
            Name = string.Empty;
            Email = string.Empty;
            Filename = string.Empty;
            Subject = string.Empty;
            Message = string.Empty;
        }

    }

}