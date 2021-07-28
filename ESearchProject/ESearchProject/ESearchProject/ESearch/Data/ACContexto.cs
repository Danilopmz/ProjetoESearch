using AplicacaoComercial.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoComercial.Data
{
    public class ACContexto:DbContext
    {
        /*Estamos criando um construtor para a classe que assumirá o papel de contexto */
        public ACContexto(DbContextOptions<ACContexto> options):base(options)
        {}
        /*
        Abaixo você tem a criação dos DbSet. Esses elementos são representação
        das tabelas de forma lógica, ou seja, armazenam os dados antes de irem para 
        as tabelas
        */

        
        public DbSet<Usuario> Usuario{get;set;}
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Markers> Markers { get; set; }
        public DbSet<DetalhePedido> DetalhePedido{ get; set; }
        // public DbSet<Markers> Markers { get; set; }
        

        /*
O método abaixo cria efetivamente as tabelas no banco de dados
de acordo com o modelo desenvolvido e apontando o nome das tabelas com
o comando ToTable
*/
        protected override void OnModelCreating(ModelBuilder mb){
            mb.Entity<Usuario>().ToTable("Usuario");
            mb.Entity<Markers>().ToTable("Markers");
            // mb.Entity<Markers>().ToTable("Markers");
            mb.Entity<Contato>().ToTable("Contato");
            mb.Entity<Cliente>().ToTable("Cliente");
            // mb.Entity<Cliente>().ToTable("Cliente").HasKey(cli => cli.Id);
            // mb.Entity<Cliente>().ToTable("Cliente").HasOne<Usuario>(us => us.Usuario).WithOne(cli => cli.Cliente).HasForeignKey<Cliente>(cl => cl.IdUsuario);
            // mb.Entity<Cliente>().ToTable("Cliente").HasOne<Contato>(ct => ct.Contato).WithOne(cli => cli.Cliente).HasForeignKey<Cliente>(clx => clx.IdContato);
            // mb.Entity<Cliente>().ToTable("Cliente").HasOne<Evento>(ev => ev.Evento).WithOne(cli => cli.Cliente).HasForeignKey<Cliente>(cl => cl.IdEvento);


            // mb.Entity<Funcionario>().ToTable("Funcionario").HasOne<Usuario>(us => us.Usuario).WithOne(fu => fu.Funcionario).HasForeignKey<Funcionario>(fu => fu.IdUsuario);
            // mb.Entity<Funcionario>().ToTable("Funcionario").HasOne<Contato>(ct => ct.Contato).WithOne(fu => fu.Funcionario).HasForeignKey<Funcionario>(cl => cl.IdContato);
            
            // mb.Entity<Produto>().ToTable("Produto");
            // mb.Entity<Pedido>().ToTable("Pedido").HasOne<Cliente>(cl => cl.Cliente).WithMany(p=>p.Pedido).HasForeignKey(cl=>cl.IdCliente);



            // mb.Entity<DetalhePedido>().ToTable("DetalhePedido").HasOne<Pedido>(pd => pd.Pedido).WithMany(p=>p.DetalhePedido).HasForeignKey(pd=>pd.IdPedido);
            // mb.Entity<DetalhePedido>().ToTable("DetalhePedido").HasOne<Produto>(pt => pt.Produto).WithMany(p=>p.DetalhePedido).HasForeignKey(pt=>pt.IdProduto);
        }
    }
}