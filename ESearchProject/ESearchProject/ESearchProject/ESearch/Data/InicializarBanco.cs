// using System.Linq;
// using AplicacaoComercial.Models;
// namespace AplicacaoComercial.Data
// {
//     public class InicializarBanco
//     {
//         public static void Iniciar(ACContexto contexto){
//             contexto.Database.EnsureCreated();
//             if(contexto.Cliente.Any()){
//                 return;
//             }
//             var usuario = new Usuario()
//             {
//                 NomeUsuario="pedro", Senha="123", Nivel="Cliente"
//             };
//             contexto.Usuario.Add(usuario);
//             var contato = new Contato(){
//                 Telefone = "11-6659-8899", Celular="11-99689-4458", Email="pedro@terra.com.br"
//             };
//             contexto.Contato.Add(contato);
//             var cliente = new Cliente(){
//                 NomeCliente="Pedro Oliveira", CPF="111.444.777.35", IdUsuario = usuario.Id,IdContato = contato.Id
//             };
//             //evento
//             // contexto.Evento.Add(evento);
//             // var cadevento = new Evento(){
//             //     NomeEvento="Show1", CEP="07179240"
//             // };

//             contexto.Cliente.Add(cliente);
//             var produto = new Produto(){
//                 NomeProduto="Mouse", TipoProduto="Informática", Descricao="Mouse Microsoft", Quantidade=20, Preco=54.20
//             };
//             contexto.Produto.Add(produto);
//             var pedido = new Pedido(){
//                 IdCliente = cliente.Id
//             };
//             contexto.Pedido.Add(pedido);
//             var detalhe = new DetalhePedido(){
//                 IdPedido = pedido.Id, IdProduto = produto.Id,Quantidade = 1
//              };
//             contexto.DetalhePedido.Add(detalhe);
//             contexto.SaveChanges();
//         }
//     }
// }


using System.Linq;
using AplicacaoComercial.Models;
namespace AplicacaoComercial.Data
{
    public class InicializarBanco
    {
        public static void Iniciar(ACContexto contexto){
            contexto.Database.EnsureCreated();
            if(contexto.Cliente.Any()){
                return;
            }
            var usuario = new Usuario()
            {
                NomeCliente="Danilo Pereira", CPF="49699949864", Email="danilopmzxbox@hotmail.com", NomeUsuario="danz", Senha="123", Nivel="Cliente"
            };
            contexto.Usuario.Add(usuario);
            
            // var contato = new Contato(){
            //     Telefone = "11-6659-8899", Celular="11-99689-4458", Email="pedro@terra.com.br"
            // };
            // contexto.Contato.Add(contato);

            // var cliente = new Cliente(){
            //     NomeCliente="Pedro Oliveira", CPF="111.444.777.35", IdUsuario = usuario.Id
            // };
            // contexto.Cliente.Add(cliente);

            // > originallll contato
            // var cliente = new Cliente(){
            //     NomeCliente="Pedro Oliveira", CPF="111.444.777.35", IdUsuario = usuario.Id,IdContato = contato.Id
            // };

            // contexto.Cliente.Add(cliente);

            // var produto = new Produto(){
            //     NomeProduto="Mouse", TipoProduto="Informática", Descricao="Mouse Microsoft", Quantidade=20, Preco=54.20
            // };
            
            
            var markers = new Markers()
            {
                name="Bienal Bonsucesso", address="07179240", rua="Rua Sebastiao Vieira, 81", data="07/01/2019",inicio="14:00",termino="16:00", type="Livros gratuitos para todos alunos do Senac Tatuapé.", preco="gratuíto"
            };
            contexto.Markers.Add(markers);


            // contexto.Produto.Add(produto);
            // var pedido = new Pedido(){
            //     IdCliente = cliente.Id
            // };
            // contexto.Pedido.Add(pedido);
            // var detalhe = new DetalhePedido(){
            //     IdPedido = pedido.Id, IdProduto = produto.Id,Quantidade = 1
            //  };
            // contexto.DetalhePedido.Add(detalhe);
            contexto.SaveChanges();
        }










    }
}