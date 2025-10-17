using FluentAssertions;

namespace cesta_de_la_compra_kata_tests
{
    public class CestaTest
    {
        [Fact]
        public void Si_Agrego_1_Producto_A_La_Cesta_Debe_CantidadProducto_Ser_1()
        {
            Cesta cesta = new();

            cesta.AgregarProducto("Lechuga");

            cesta.ObtenerCantidadProductos().Should().Be(1);
        }

        [Fact]
        public void Si_Agrego_1_Producto_A_La_Cesta_Debe_Poder_Ver_El_Producto_Agregado()
        {
            Cesta cesta = new();

            const string productoEsperado = "Lechuga";

            cesta.AgregarProducto("Lechuga");

            cesta.Productos[0].Nombre.Should().Be(productoEsperado);
        }

        [Fact]
        public void Si_Agrego_1_Producto_A_La_Cesta_Debe_El_Producto_Mostrar_Precio_Del_Producto_Agregado()
        {
            Cesta cesta = new();

            const double precioUnitario= 1.79d;

            cesta.AgregarProducto("Lechuga");

            cesta.Productos[0].Precio.Should().Be(precioUnitario);
        }

    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre)
        {
            Nombre = nombre;
        }
    }

    public class Cesta
    {
        public int ObtenerCantidadProductos() => Productos.Count;

        public List<Producto> Productos = new();

        public void AgregarProducto(string producto)
        {
            Productos.Add(new Producto(producto));
        }
    }
}