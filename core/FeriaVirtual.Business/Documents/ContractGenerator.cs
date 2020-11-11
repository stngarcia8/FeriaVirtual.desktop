using System;
using System.IO;
using FeriaVirtual.Domain.Contracts;
using TemplateEngine.Docx;
using WordToPDF;


namespace FeriaVirtual.Business.Documents{

    public class ContractGenerator{

        private const string BasePath = @"E:\feria-virtual-docs";

        private readonly Contract contract;
        private readonly string customerAction;
        private readonly string profileName;
        private readonly string singleProfileName;
        private string fileName;
        private string filePath;
        private string templatePath;

        // Properties
        public string PdfFilePath{ get; private set; }


        // Constructor
        private ContractGenerator(Contract contract, string singleProfileName, string profileName){
            this.contract = contract;
            this.singleProfileName = singleProfileName;
            this.profileName = profileName;
            customerAction = this.singleProfileName.ToLower().Equals("productor")
                ? "la venta de productos frutales"
                : "el transporte de productos";
        }


        public void Generate(){
            foreach (var detail in contract.Details){
                FileOperations(detail);
                ConfigureContract(detail);
            }
        }


        private void FileOperations(ContractDetail detail){
            filePath = BasePath + @"\contratos";
            templatePath = BasePath + @"\\templates";
            VerifiPath();
            fileName =
                $@"{filePath}\contrato_{singleProfileName}_{detail.Customer}_{detail.DateAcepted.Year}-{detail.DateAcepted.Month}-{detail.DateAcepted.Day}.docx";
            VerifyFile();
            VerifyPdfFile();
            CopyTemplate();
        }


        private void VerifiPath(){
            var directory = new DirectoryInfo(filePath);
            if (!directory.Exists) directory.Create();
            filePath = directory.FullName;
        }


        private void VerifyFile(){
            var file = new FileInfo(fileName);
            if (file.Exists) file.Delete();
            PdfFilePath = Path.Combine(filePath, Path.GetFileNameWithoutExtension(fileName) + ".pdf");
        }


        private void VerifyPdfFile(){
            var file = new FileInfo(PdfFilePath);
            if (file.Exists) file.Delete();
        }


        private void CopyTemplate(){
            var templateFile = templatePath + @"\contrato-template.docx";
            var template = new FileInfo(templateFile);
            template.CopyTo(fileName);
        }


        // Named constructor.
        public static ContractGenerator CreateContract(Contract contract, string singleProfileName, string profileName){
            return new ContractGenerator(contract, singleProfileName, profileName);
        }


        private void ConfigureContract(ContractDetail detail){
            detail.DateAcepted = DateTime.Now.Date;
            var valuesToFill = new Content(
                new FieldContent("contract_type", profileName),
                new FieldContent("contract_date", detail.DateAcepted.ToShortDateString()),
                new FieldContent("customer_name", detail.Customer.ToString()),
                new FieldContent("customer_dni", detail.Customer.Dni),
                new FieldContent("customer_address", detail.Customer.ComercialInfo.Address),
                new FieldContent("customer_city", detail.Customer.ComercialInfo.City.CityName),
                new FieldContent("customer_single_profile_name", singleProfileName),
                new FieldContent("customer_action", customerAction),
                new FieldContent("contract_percent", contract.ContractCommission.ToString("N2")),
                new FieldContent("additional_value", detail.AdditionalValue.ToString("N2")),
                new FieldContent("fine_value", detail.FineValue.ToString("N2")),
                new FieldContent("start_date", contract.StartDate.ToShortDateString()),
                new FieldContent("end_date", contract.EndDate.ToShortDateString())
            );
            using (var outputDocument = new TemplateProcessor(fileName).SetRemoveContentControls(true)){
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
            var document = new Word2Pdf{
                InputLocation = fileName,
                OutputLocation = PdfFilePath
            };
            document.Word2PdfCOnversion();
            File.Delete(fileName);
        }

    }

}