namespace FeriaVirtual.API.Models{

    /// <summary>
    ///     Representa el detalle de una orden de despacho.
    /// </summary>
    public class OrderDispatchDetailsModel{

        /// <summary>
        ///     Nombre del producto a transportar.
        /// </summary>
        public string Product{ get; set; }

        /// <summary>
        ///     Valor unitario del producto a transportar.
        /// </summary>
        public float UnitValue{ get; set; }

        /// <summary>
        ///     Cantidad de productos a transportar.
        /// </summary>
        public float Quantity{ get; set; }

        /// <summary>
        ///     Valor total del producto a transportar.
        /// </summary>
        public float TotalValue{ get; set; }

    }

}