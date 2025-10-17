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
        throw new NotImplementedException();
    }
}