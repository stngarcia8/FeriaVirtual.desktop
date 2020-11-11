using System.Collections.Generic;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.API.Models{

    /// <summary>
    ///     Representa una subasta.
    /// </summary>
    public class AuctionModel{

        /// <summary>
        ///     Corresponde al identificador de la subasta.
        /// </summary>
        public string AuctionId{ get; set; }

        /// <summary>
        ///     fecha de la subasta
        /// </summary>
        public string AuctionDate{ get; set; }

        /// <summary>
        ///     Porcentaje asumido por el valor inicial de la subasta.
        /// </summary>
        public float Percent{ get; set; }

        /// <summary>
        ///     Valor inicial de la subasta.
        /// </summary>
        public float Value{ get; set; }

        /// <summary>
        ///     Peso que se transportará.
        /// </summary>
        public float Weight{ get; set; }

        /// <summary>
        ///     Fecha limite de la subasta.
        /// </summary>
        public string LimitDate{ get; set; }

        /// <summary>
        ///     Observación de la subasta.
        /// </summary>
        public string Observation{ get; set; }

        /// <summary>
        ///     Nombre de la compañía que se realizará el transporte de los productos que se subastarán.
        /// </summary>
        public string CompanyName{ get; set; }

        /// <summary>
        ///     Destino del transporte de los productos a subastar.
        /// </summary>
        public string Destination{ get; set; }

        /// <summary>
        ///     Número teléfonico de contacto del cliente al que se transportarán los productos.
        /// </summary>
        public string PhoneNumber{ get; set; }

        /// <summary>
        ///     Estado actual de la subasta 1, abierta, 2 cerrada por tiempo limite cumplido y 3 cerrada por el administrador
        /// </summary>
        public int Status{ get; set; }

        /// <summary>
        ///     Lista de los productos a transportar.
        /// </summary>
        public IList<AuctionProduct> Products{ get; set; }

    }

}