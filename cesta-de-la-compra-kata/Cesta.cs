using System.Globalization;
using cesta_de_la_compra_kata;

public class Cesta
{
    public int ObtenerCantidadProductos() => Productos.Sum(p => p.ObtenerCantidad());

    public List<Producto> Productos = new();

    public void AgregarProducto(string nombreProducto)
    {
        Producto producto = Productos.Find(producto => producto.Nombre == nombreProducto);
        if (producto != null)
            producto.AumentarCantidad();
        else
            Productos.Add(new Producto(nombreProducto));
    }

    public object ObtenerDetalles()
    {
        string detalles = "--------------------------------------------\r\n" +
                          "| Producto     | Price con IVA  | Cantidad |\r\n" +
                            "| -----------  | -------------- | -------- |\r\n";
        foreach (var producto in Productos)
        {
            detalles +=
                 $"| {producto.Nombre.PadRight(12)} | {(producto.ObtenerPrecioFinal().ToString("0.00", CultureInfo.InvariantCulture) + " €"),-13}  | {producto.ObtenerCantidad().ToString().PadRight(8)} |\r\n";
        }
        detalles+= "|------------------------------------------|\r\n" +
                  "| Promoción:                               |\r\n" +
                  "--------------------------------------------\r\n" +
                  $"| Total productos: {ObtenerCantidadProductos().ToString().PadRight(24)}|\r\n" +
                  $"| Precio total: {(Productos.Sum(p => p.ObtenerPrecioFinal()).ToString("0.00", CultureInfo.InvariantCulture) + " €").PadRight(27)}|";

        return detalles;
    }
}