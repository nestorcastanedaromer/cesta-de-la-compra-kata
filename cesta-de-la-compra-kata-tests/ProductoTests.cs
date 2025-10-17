using cesta_de_la_compra_kata;
using FluentAssertions;

namespace cesta_de_la_compra_kata_tests
{
    public class ProductoTests
    {
        [Fact]
        public void Si_ObtienTotal_Debe_Obtener_Valor_Correcto()
        {
            const string nombreProducto = "Lechuga";

            Producto producto = new(nombreProducto);

            producto.ObtenerTotal().Should().Be(1.79D);
        }

        [Fact]
        public void Si_ObtienPrecioFinal_Debe_Obtener_Valor_Correcto()
        {
            const string nombreProducto = "Lechuga";

            Producto producto = new(nombreProducto);

            producto.ObtenerPrecioFinal().Should().Be(2.17D);
        }
    }
}
