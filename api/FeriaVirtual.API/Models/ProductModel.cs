using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeriaVirtual.API.Models {
    public class ProductModel {

        /// <summary>
        /// Representa el identificador del producto.
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// Corresponde al identificador del productor asociado.
        /// </summary>
        public string ClientID { get; set; }

        /// <summary>
        /// nombre del producto.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Observacion del producto.
        /// </summary>
        public string Observation { get; set; }

        /// <summary>
        /// Valor del producto.
        /// </summary>
        public float ProductValue { get; set; }

        /// <summary>
        /// Cantidad de productos disponibles, representado en kilogramos.
        /// </summary>
        public float ProductQuantity { get; set; }


    }
}