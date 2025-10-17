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

    public object ObtenerDetalles() => CrearEncabezado() + CrearDetalleDeProductos() + CrearTotales();

    private static string CrearEncabezado() =>
        "--------------------------------------------\r\n" +
        "| Producto     | Price con IVA  | Cantidad |\r\n" +
        "| -----------  | -------------- | -------- |\r\n";

    private string CrearDetalleDeProductos()
    {
        string detalles = String.Empty;

        foreach (var producto in Productos)
            detalles +=
                $"| {producto.Nombre,-12} " +
                $"| {producto.ObtenerPrecioFinal().ToString("0.00", CultureInfo.InvariantCulture) + " €",-13}  " +
                $"| {producto.ObtenerCantidad().ToString(),-8} |\r\n";

        return detalles;
    }

    private string CrearTotales() =>
        "|------------------------------------------|\r\n" +
        "| Promoción:                               |\r\n" +
        "--------------------------------------------\r\n" +
        $"| Total productos: {ObtenerCantidadProductos().ToString(),-24}|\r\n" +
        $"| Precio total: {(Productos.Sum(p => p.ObtenerPrecioFinal())
            .ToString("0.00", CultureInfo.InvariantCulture) + " €"),-27}|";

}