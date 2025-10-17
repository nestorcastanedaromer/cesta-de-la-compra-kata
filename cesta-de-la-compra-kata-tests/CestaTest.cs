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

            const double precioUnitario = 1.79d;

            cesta.AgregarProducto("Lechuga");

            cesta.Productos[0].Precio.Should().Be(precioUnitario);
        }

        [Fact]
        public void Si_Agrego_2_Producto_Diferentes_A_La_Cesta_Debe_El_Segundo_Producto_Mostrar_Precio_Del_Producto_Correctamente()
        {
            Cesta cesta = new();

            const double precioUnitarioSegundoProducto = 0.6D;

            cesta.AgregarProducto("Lechuga");
            cesta.AgregarProducto("Tomate");

            cesta.Productos[1].Precio.Should().Be(precioUnitarioSegundoProducto);
        }

        [Theory]
        [InlineData("Lechuga", 1.79D)]
        [InlineData("Tomate", 0.60D)]
        [InlineData("Pollo", 1.51D)]
        [InlineData("Pan", 0.80D)]
        [InlineData("Maíz", 1.36D)]
        public void Si_ObtienePrecio_Debe_Ser_Precio_Correcto(string producto, double precio)
        {
            Cesta cesta = new();

            cesta.AgregarProducto(producto);

            cesta.Productos[0].Precio.Should().Be(precio);
        }

    }

    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public Producto(string nombre)
        {
            Nombre = nombre;
            Precio = ObtenerPrecioProducto(nombre);
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

        public void AgregarProducto(string producto)
        {
            Productos.Add(new Producto(producto));
        }
    }
}