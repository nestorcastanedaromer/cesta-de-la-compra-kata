namespace cesta_de_la_compra_kata_tests;

public class Cesta
{
    public int ObtenerCantidadProductos() => Productos.Count;

    public List<Producto> Productos = new();

    public void AgregarProducto(string nombreProducto)
    {
        Productos.Add(new Producto(nombreProducto));
    }
}