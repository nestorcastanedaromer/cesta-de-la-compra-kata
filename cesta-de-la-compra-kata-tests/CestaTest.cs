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

        [Theory]
        [InlineData("Lechuga", 1.79D)]
        [InlineData("Tomate", 0.60D)]
        [InlineData("Pollo", 1.51D)]
        [InlineData("Pan", 0.80D)]
        [InlineData("Maíz", 1.36D)]
        public void Si_ObtienePrecio_Debe_Ser_PrecioUnitario_Correcto(string nombreProducto, double precioUnitario)
        {
            Cesta cesta = new();

            cesta.AgregarProducto(nombreProducto);

            cesta.Productos[0].PrecioUnitario.Should().Be(precioUnitario);
        }
    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }

        public Producto(string nombre)
        {
            Nombre = nombre;
            PrecioUnitario = ObtenerPrecioProducto(nombre);
        }

        private static double ObtenerPrecioProducto(string nombreProducto)
        {
            return nombreProducto switch
            {
                "Lechuga" => 1.79D,
                "Tomate" => 0.60D,
                "Pollo" => 1.51D,
                "Pan" => 0.80D,
                "Maíz" => 1.36D
            };
        }
    }


    public class Cesta
    {
        public int ObtenerCantidadProductos() => Productos.Count;

        public List<Producto> Productos = new();

        public void AgregarProducto(string nombreProducto)
        {
            Productos.Add(new Producto(nombreProducto));
        }
    }
}