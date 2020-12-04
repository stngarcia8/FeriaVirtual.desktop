// /*******************************************************
// * Author: Daniel García Asathor
// *******************************************************/

namespace FeriaVirtual.Infraestructure.Mailer{

    public interface IMailerSender{

        string Email{ get; set; }
        string UserEmail{ get; set; }
        string Subject{ get; set; }


        void Dispose();


        void SendMail();


        void AddAttach(string filePath);


        void RemoveAttach(string filePath);

    }

}