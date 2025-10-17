namespace cesta_de_la_compra_kata_tests;

public class Cesta
{
    public int ObtenerCantidadProductos() => Productos.Sum(p => p.Cantidad);

    public List<Producto> Productos = new();

    public void AgregarProducto(string nombreProducto)
    {
        if (Productos.Any(producto => producto.Nombre == nombreProducto))
        {
            Producto producto = Productos.Find(producto => producto.Nombre == nombreProducto);
            producto.Cantidad = producto.Cantidad + 1;
        }
        else
            Productos.Add(new Producto(nombreProducto));
    }
}