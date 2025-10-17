using cesta_de_la_compra_kata.Properties;

namespace cesta_de_la_compra_kata;

public class Producto
{
    public static readonly string ProductoNoEncontrado = Resources.ProductoNoEncontrado;
    public string Nombre { get; set; }

    private double _costo = 0D;
    private double _ingresoEsperado = 0D;
    private int _cantidad = 0;
    private double _impuestos = 0;

    public Producto(string nombre)
    {
        Nombre = nombre;
        (_costo, _ingresoEsperado, _impuestos) = ObtenerCostoEIngresoEsperado(nombre);
        _cantidad = 1;
    }

    private static (double, double,double) ObtenerCostoEIngresoEsperado(string nombreProducto) =>
        nombreProducto switch
        {
            "Lechuga" => (1.55D, 0.15D, 0.21D),
            "Tomate" => (0.52D, 0.15D, 0.21D),
            "Pollo" => (1.34D, 0.12D, 0.21D),
            "Pan" => (0.71D, 0.12D, 0.1D),
            "Maíz" => (1.21D, 0.12D, 0.1D),
            _ => throw new ArgumentException(string.Format(ProductoNoEncontrado, nombreProducto))
        };

    public double ObtenerPrecionUnitario() => Math.Ceiling((_costo + (_costo * _ingresoEsperado)) * 100) / 100;
    public double ObtenerTotal() => ObtenerPrecionUnitario() * _cantidad;
    public int ObtenerCantidad() => _cantidad;
    public void AumentarCantidad() => _cantidad += 1;
    public double PrecioFinal() => Math.Ceiling((ObtenerTotal() + (ObtenerTotal() * _impuestos))*100)/100;
}