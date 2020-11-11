namespace FeriaVirtual.API.Models{

    /// <summary>
    ///     Representa la respuesta brindada a un contrato estipulado.
    /// </summary>
    public class RequestContractModel{

        /// <summary>
        ///     Corresponde al identificador del perfil del contrato.
        /// </summary>
        public int ProfileId{ get; set; }

        /// <summary>
        ///     Corresponde al identificador del contrato que será aceptado/rechazado.
        /// </summary>
        public string ContractId{ get; set; }

        /// <summary>
        ///     corresponde al identificador del cliente que acepta/rechaza el contrato.
        /// </summary>
        public string ClientId{ get; set; }

        /// <summary>
        ///     Corresponde a las observaciones realizadas por el cliente que acepta/rechaza el
        ///     contrato.
        /// </summary>
        public string CustomerObservation{ get; set; }

    }

}