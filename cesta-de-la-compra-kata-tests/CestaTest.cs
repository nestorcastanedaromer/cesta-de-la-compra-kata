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

            cesta.CantidadProducto.Should().Be(1);
        }
    }

    public class Cesta
    {

        public int CantidadProducto { get; set; }

        public void AgregarProducto(string producto)
        {
            CantidadProducto = 1;
        }
    }
}