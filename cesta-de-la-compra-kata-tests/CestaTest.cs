using cesta_de_la_compra_kata;
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
        public void Si_ObtieneCosto_Debe_Ser_Costo_Correcto(string nombreProducto, double precioUnitario)
        {
            Cesta cesta = new();

            cesta.AgregarProducto(nombreProducto);

            cesta.Productos[0].ObtenerPrecionUnitario().Should().Be(precioUnitario);
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

        [Fact]
        public void Si_AgregarProducto_Recibe_Producto_Existente_Debe_Aumentar_Cantidad_Producto_Mas_Uno()
        {
            Cesta cesta = new();

            const string nombreProducto = "Lechuga";

            cesta.AgregarProducto(nombreProducto);
            cesta.AgregarProducto(nombreProducto);

            cesta.Productos[0].ObtenerCantidad().Should().Be(2);
            cesta.ObtenerCantidadProductos().Should().Be(2);
        }


        [Fact]
        public void Si_ObtieneDetalles_Debe_Mostrar_Lista_Productos()
        {
            Cesta cesta = new();
            string detallesEsperados= "--------------------------------------------\r\n" +
                                     "| Producto     | Price con IVA  | Cantidad |\r\n" +
                                     "| -----------  | -------------- | -------- |\r\n" +
                                     "| Lechuga      | 2.17 €         | 1        |\r\n" +
                                     "| Tomate       | 0.73 €         | 1        |\r\n" +
                                     "| Pollo        | 1.83 €         | 1        |\r\n" +
                                     "| Pan          | 0.88 €         | 1        |\r\n" +
                                     "| Maíz         | 1.50 €         | 1        |\r\n" +
                                     "|------------------------------------------|\r\n" +
                                     "| Promoción:                               |\r\n" +
                                     "--------------------------------------------\r\n" +
                                     "| Total productos: 5                       |\r\n" +
                                     "| Precio total: 7.11 €                     |";

            cesta.AgregarProducto("Lechuga");
            cesta.AgregarProducto("Tomate");
            cesta.AgregarProducto("Pollo");
            cesta.AgregarProducto("Pan");
            cesta.AgregarProducto("Maíz");

            cesta.ObtenerDetalles().Should().Be(detallesEsperados);
        }


    }
}