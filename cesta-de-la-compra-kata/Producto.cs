using cesta_de_la_compra_kata.Properties;

namespace cesta_de_la_compra_kata_tests;

public class Producto
{
    public static readonly string ProductoNoEncontrado = Resources.ProductoNoEncontrado;
    public string Nombre { get; set; }
    public double Costo { get; set; }
    public double IngresoEsperado { get; set; }
    public int Total { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre)
    {
        Nombre = nombre;
        Costo = ObtenerPrecioProducto(nombre);
        IngresoEsperado = ObtenerIngresoEsperado(nombre);
        Cantidad = 1;
    }

    private static double ObtenerPrecioProducto(string nombreProducto)
    {
        return nombreProducto switch
        {
            "Lechuga" => 1.55D,
            "Tomate" => 0.52D,
            "Pollo" => 1.34D,
            "Pan" => 0.71D,
            "Maíz" => 1.21D,
            _ => throw new ArgumentException(string.Format(ProductoNoEncontrado, nombreProducto))
        };
    }

    private static double ObtenerIngresoEsperado(string nombreProducto)
    {
        return nombreProducto switch
        {
            "Lechuga" => 0.15D,
            "Tomate" => 0.15D,
            "Pollo" => 0.12D,
            "Pan" => 0.12D,
            "Maíz" => 0.12D
        };
    }

    public double ObtenerPrecionUnitario()
    {
        return Math.Ceiling((Costo + (Costo * IngresoEsperado)) * 100) / 100;
    }
}