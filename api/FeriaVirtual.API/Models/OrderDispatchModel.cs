using System.Collections.Generic;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.API.Models{

    /// <summary>
    ///     Representa una orden de despacho.
    /// </summary>
    public class OrderDispatchModel{

        /// <summary>
        ///     Corresponde al identificador de la orden de despacho.
        /// </summary>
        public string DispatchId{ get; set; }

        /// <summary>
        ///     Identificador del cliente que se enviará la orden de despacho.
        /// </summary>
        public string ClientId{ get; set; }

        /// <summary>
        ///     Fecha de despacho de los productos.
        /// </summary>
        public string DispatchDate{ get; set; }

        /// <summary>
        ///     Valor del despacho.
        /// </summary>
        public float DispatchValue{ get; set; }

        /// <summary>
        ///     Peso de los productos a despachar.
        /// </summary>
        public float DispatchWeight{ get; set; }

        /// <summary>
        ///     Observación de la orden de despacho.
        /// </summary>
        public string Observation{ get; set; }

        /// <summary>
        ///     Nombre de la empresa a la que serán transportados los productos.
        /// </summary>
        public string CompanyName{ get; set; }

        /// <summary>
        ///     Destino del despacho.
        /// </summary>
        public string Destination{ get; set; }

        /// <summary>
        ///     Teléfono de contacto del cliente que recibirá los productos despachados.
        /// </summary>
        public string PhoneNumber{ get; set; }

        /// <summary>
        ///     Estado de la orden de despacho.
        /// </summary>
        public int Status{ get; set; }

        /// <summary>
        ///     Detalle de la orden de despacho.
        /// </summary>
        public IList<OrderDispatchDetail> Products{ get; set; }


        /// <summary>
        ///     representa una orden de despacho.
        /// </summary>
        public OrderDispatchModel(){
            DispatchId = string.Empty;
            ClientId = string.Empty;
            DispatchDate = string.Empty;
            DispatchValue = 0;
            DispatchWeight = 0;
            Observation = string.Empty;
            CompanyName = string.Empty;
            Destination = string.Empty;
            PhoneNumber = string.Empty;
            Status = 0;
            Products = new List<OrderDispatchDetail>();
        }

    }

}