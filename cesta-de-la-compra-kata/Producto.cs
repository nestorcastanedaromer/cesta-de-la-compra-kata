using cesta_de_la_compra_kata.Properties;

namespace cesta_de_la_compra_kata;

public class Producto
{
    public static readonly string ProductoNoEncontrado = Resources.ProductoNoEncontrado;
    public string Nombre { get; set; }

    private double _ingresoEsperado;
    private double _impuestos;
    private double _costo;
    private int _cantidad;

    public Producto(string nombre)
    {
        Nombre = nombre;
        (_costo, _ingresoEsperado, _impuestos) = ObtenerCostoEIngresoEsperado(nombre);
        _cantidad = 1;
    }

    private static (double, double, double) ObtenerCostoEIngresoEsperado(string nombreProducto) =>
        nombreProducto switch
        {
            "Lechuga" => (1.55D, 0.15D, 0.21D),
            "Tomate" => (0.52D, 0.15D, 0.21D),
            "Pollo" => (1.34D, 0.12D, 0.21D),
            "Pan" => (0.71D, 0.12D, 0.10D),
            "Maíz" => (1.21D, 0.12D, 0.10D),
            _ => throw new ArgumentException(string.Format(ProductoNoEncontrado, nombreProducto))
        };

    public void AumentarCantidad() => _cantidad += 1;
    public int ObtenerCantidad() => _cantidad;
    public double ObtenerPrecionUnitario() => Math.Ceiling((_costo + (_costo * _ingresoEsperado)) * 100) / 100;
    public double ObtenerTotal() => ObtenerPrecionUnitario() * _cantidad;
    public double ObtenerPrecioFinal() => Math.Ceiling((ObtenerTotal() +Math.Round(ObtenerTotal() * _impuestos,4)) * 100) / 100;
}