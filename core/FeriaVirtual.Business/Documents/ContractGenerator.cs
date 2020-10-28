using System;
using System.Collections.Generic;
using System.IO;
using FeriaVirtual.Domain.Contracts;
using TemplateEngine.Docx;
using WordToPDF;

namespace FeriaVirtual.Business.Documents {

    public class ContractGenerator{

        private Contract contract;
        private readonly string basePath = @"E:\feria-virtual-docs";
        private string filePath;
        private string templatePath;
        private string fileName;
        private string pdfFileName;
        private readonly string singleProfileName;
        private readonly string profileName;
        private readonly string customerAction;

        // Properties
        public string PdfFilePath => pdfFileName;

        // Constructor
        private ContractGenerator(Contract contract,string singleProfileName,string profileName) {
            this.contract = contract;
            this.singleProfileName = singleProfileName;
            this.profileName = profileName;
            customerAction=(this.singleProfileName.ToLower().Equals("productor") ? "la venta de productos frutales" : "el transporte de productos");
        }

        public void Generate() {
            foreach(ContractDetail detail in contract.Details) {
                FileOperations(detail);
                ConfigureContract(detail);
            }
        }

        private void FileOperations(ContractDetail detail) {
            filePath= basePath + @"\contratos";
            templatePath= basePath + @"\\templates";
            VerifiPath();
            fileName= string.Format(@"{0}\contrato_{1}_{2}_{3}-{4}-{5}.docx",filePath,
                singleProfileName,detail.Customer.ToString(),
                detail.DateAcepted.Year,detail.DateAcepted.Month,detail.DateAcepted.Day
            );
            VerifyFile();
            VerifyPdfFile();
            CopyTemplate();
        }

        private void VerifiPath() {
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if(!directory.Exists) {
                directory.Create();
            }
            filePath= directory.FullName;
            directory = null;
        }

        private void VerifyFile() {
            FileInfo file = new FileInfo(fileName);
            if(file.Exists) {
                file.Delete();
            }
            pdfFileName= Path.Combine(filePath,Path.GetFileNameWithoutExtension(fileName) + ".pdf");
            file=null;
        }

        private void VerifyPdfFile() {
            FileInfo file = new FileInfo(pdfFileName);
            if(file.Exists) {
                file.Delete();
            }
            file=null;
        }


        private void CopyTemplate() {
            string templateFile = templatePath + @"\contrato-template.docx";
            FileInfo template = new FileInfo(templateFile);
            template.CopyTo(fileName);
            template= null;
        }

        // Named constructor.
        public static ContractGenerator CreateContract(Contract contract,string singleProfileName,string profileName) {
            return new ContractGenerator(contract,singleProfileName,profileName);
        }

        private void ConfigureContract(ContractDetail detail) {
            detail.DateAcepted= DateTime.Now.Date;
            try {
                Content valuesToFill = new Content(
                    new FieldContent("contract_type",profileName),
                    new FieldContent("contract_date",detail.DateAcepted.ToShortDateString()),
                    new FieldContent("customer_name",detail.Customer.ToString()),
                    new FieldContent("customer_dni",detail.Customer.DNI),
                    new FieldContent("customer_address",detail.Customer.ComercialInfo.Address),
                    new FieldContent("customer_city",detail.Customer.ComercialInfo.City.CityName),
                    new FieldContent("customer_single_profile_name",singleProfileName),
                    new FieldContent("customer_action",customerAction),
                    new FieldContent("contract_percent",contract.ContractCommission.ToString()),
                    new FieldContent("additional_value",detail.AdditionalValue.ToString()),
                    new FieldContent("fine_value",detail.FineValue.ToString()),
                    new FieldContent("start_date",contract.StartDate.ToShortDateString()),
                    new FieldContent("end_date",contract.EndDate.ToShortDateString())
                    );
                using(TemplateProcessor outputDocument = new TemplateProcessor(fileName).SetRemoveContentControls(true)) {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
                Word2Pdf document = new Word2Pdf {
                    InputLocation = fileName,
                    OutputLocation = pdfFileName
                };
                document.Word2PdfCOnversion();
                document = null;
                System.IO.File.Delete(fileName);
            } catch (Exception ex) {
                string xError = ex.Message.ToString();
            }
        }





    }
}
