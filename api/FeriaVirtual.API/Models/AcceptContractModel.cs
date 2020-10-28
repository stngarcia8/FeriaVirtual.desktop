namespace FeriaVirtual.API.Models {

    public class RequestContractModel {

        /// <summary>
        /// Corresponde al identificador del perfil del contrato.
        /// </summary>
        public int ProfileID { get; set; }

        /// <summary>
        /// Corresponde al identificador del contrato que será aceptado/rechazado.
        /// </summary>
        public string ContractID { get; set; }

        /// <summary>
        /// corresponde al identificador del cliente que acepta/rechaza el contrato.
        /// </summary>
        public string ClientID { get; set; }

        /// <summary>
        /// Corresponde a las observaciones realizadas por el cliente que acepta/rechaza el
        /// contrato.
        /// </summary>
        public string CustomerObservation { get; set; }
    }
}
