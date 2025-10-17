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
        [InlineData("Lechuga", 1.55D)]
        [InlineData("Tomate", 0.52D)]
        [InlineData("Pollo", 1.34D)]
        [InlineData("Pan", 0.71D)]
        [InlineData("Maíz", 1.21D)]
        public void Si_ObtieneCosto_Debe_Ser_Costo_Correcto(string nombreProducto, double precioUnitario)
        {
            Cesta cesta = new();

            cesta.AgregarProducto(nombreProducto);

            cesta.Productos[0].Costo.Should().Be(precioUnitario);
        }

        [Theory]
        [InlineData("Lechuga", 0.15D)]
        [InlineData("Tomate", 0.15D)]
        [InlineData("Pollo", 0.12D)]
        [InlineData("Pan", 0.12D)]
        [InlineData("Maíz", 0.12D)]
        public void Si_ObtieneIngresoEsperado_Debe_Ser_IngresoEsperado_Correcto(string nombreProducto, double precioUnitario)
        {
            Cesta cesta = new();

            cesta.AgregarProducto(nombreProducto);

            cesta.Productos[0].IngresoEsperado.Should().Be(precioUnitario);
        }

        [Fact]
        public void Si_ObtenienePrecioUnitario_Debe_Devolver_Valor_Redondeado_Correctamente()
        {
            Cesta cesta = new();

            const double precioUnitarioEsperado = 1.79D;

            cesta.AgregarProducto("Lechuga");

            cesta.Productos[0].ObtenerPrecionUnitario().Should().Be(precioUnitarioEsperado);
        }

        [Fact]
        public void Si_AgregarProducto_Producto_No_Existe_Debe_LanzarExcepcion()
        {
            Cesta cesta = new();
            const string productoInexistente = "Peras";
            
            cesta.Invoking(metodo => metodo.AgregarProducto(productoInexistente))
                .Should().Throw<ArgumentException>()
                .WithMessage(string.Format(Producto.ProductoNoEncontrado,productoInexistente));
        }
    }
}