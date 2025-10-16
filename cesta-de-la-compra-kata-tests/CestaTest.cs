using FluentAssertions;

namespace cesta_de_la_compra_kata_tests
{
    public class CestaTest
    {
        [Fact]
        public void Si_Agrego_1_Producto_A_La_Cesta_Debe_CantidadProducto_Ser_1()
        {
            var cesta = new Cesta();

            cesta.AgregarProducto("Lechuga ");

            cesta.CantidadProducto.Should().Be(1) ;
        }
    }

    public class Cesta
    {
        public object CantidadProducto { get; set; }

        public void AgregarProducto(string lechuga)
        {
            throw new NotImplementedException();
        }
    }
}