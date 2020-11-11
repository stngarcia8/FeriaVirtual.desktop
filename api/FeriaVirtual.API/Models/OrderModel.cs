using System.Collections.Generic;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.API.Models{

    /// <summary>
    ///     Clase que representa una orden de compra.
    /// </summary>
    public class OrderModel{

        /// <summary>
        ///     corresponde al identificador de la orden de compra.
        /// </summary>
        public string OrderId{ get; set; }

        /// <summary>
        ///     Corresponde al identificador del cliente que realiza la orden de compra.
        /// </summary>
        public string ClientId{ get; set; }

        /// <summary>
        ///     Identificador de la condición de pago de la orden de compra.
        /// </summary>
        public int ConditionId{ get; set; }

        /// <summary>
        ///     Descripción de la condición de pago asociada a la orden de compra.
        /// </summary>
        public string ConditionDescription{ get; set; }

        /// <summary>
        ///     Descuento solicitado para la orden de compra.
        /// </summary>
        public float OrderDiscount{ get; set; }

        /// <summary>
        ///     Observación de la orden de compra.
        /// </summary>
        public string Observation{ get; set; }

        /// <summary>
        ///     Detalle de la orden de compra.
        /// </summary>
        public IList<OrderDetail> OrderDetail{ get; set; }

    }

}