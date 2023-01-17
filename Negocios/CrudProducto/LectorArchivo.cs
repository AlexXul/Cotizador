using ClosedXML.Excel;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Negocios.CrudProducto
{
    public class LectorArchivo
    {
        public IEnumerable<Producto> Leer(string Ruta)
        {
            List<Producto> Productos = new List<Producto>();

            XLWorkbook ArchivoExcel = new XLWorkbook(Ruta);//ruta del libro excel
            var HojaExcel = ArchivoExcel.Worksheet(1);//hojas del libro        

            foreach (IXLRow fila in HojaExcel.Rows())//recorrer las filas
            {
                string c = fila.Cell(5).GetValue<String>();
                if (c.Equals("Precio") || string.IsNullOrEmpty(c)) {
                }
                else
                {
                    Producto p = new Producto
                    {
                        Nombre = fila.Cell(1).GetValue<String>(),
                        CodFab = fila.Cell(2).GetValue<String>(),
                        CodProv = fila.Cell(3).GetValue<String>(),
                        Descripcion = fila.Cell(4).GetValue<String>(),
                        Precio = float.Parse(fila.Cell(5).GetValue<String>().Replace("$", "")),
                        CodigoSat = fila.Cell(6).GetValue<String>()
                    };
                    Productos.Add(p);
                }
            }
            return Productos;
        }
    }
}
