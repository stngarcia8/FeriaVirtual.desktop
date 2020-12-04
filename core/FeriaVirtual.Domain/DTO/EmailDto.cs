using System.Collections.Generic;

namespace FeriaVirtual.Domain.Dto {
    public class EmailDto {

        public string EmailTo { get; set; }
        public string UserTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<string> Attachments { get; set; }


        private EmailDto() {
            EmailTo = string.Empty;
            UserTo = string.Empty;
            Subject = string.Empty;
            Body = string.Empty;
            Attachments = new List<string>();
        }


        public static EmailDto CreateModel() {
            return new EmailDto();
        }


        public void AddAttachment(string filePath) {
            Attachments.Add(filePath);
        }


        public void RemoveAttachment(string filePath) {
            Attachments.Remove(filePath);
        }





    }
}
