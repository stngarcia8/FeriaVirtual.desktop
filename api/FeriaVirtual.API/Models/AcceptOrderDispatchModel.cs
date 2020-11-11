namespace FeriaVirtual.API.Models{

    /// <summary>
    ///     Representa el objeto de respuesta de una orden de despacho.
    /// </summary>
    public class AcceptOrderDispatchModel{

        /// <summary>
        ///     Corresponde al identificador de la orden de despacho.
        /// </summary>
        public string DispatchId{ get; set; }

        /// <summary>
        ///     Corresponde a la observación que realiza el transportista a la orden de despacho.
        /// </summary>
        public string CarrierObservation{ get; set; }

    }

}