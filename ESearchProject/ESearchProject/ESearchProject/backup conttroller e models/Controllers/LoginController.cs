using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using AplicacaoComercial.Data;
using AplicacaoComercial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AplicacaoComercial.Controllers
{
    /*
        O método Post receberá requisições HTTP do tipo POST, 
        tendo sido marcado com o atributo AllowAnonymous para 
        assim possibilitar o acesso de usuários não-autenticados;
    As instâncias dos tipos UsersDAO, SigningConfigurations e
     TokenConfigurations foram marcadas com o atributo FromServices no método Post,
      o que indica que as mesmas serão resolvidas via mecanismo de
       injeção de dependências do ASP.NET Core;
    O parâmetro usuario foi marcado com o atributo FromBody, correspondendo às
     credenciais (ID do usuário + chave de acesso) que serão enviadas no corpo 
     de uma requisição. As informações desta referência (usuario) serão então 
     comparadas com o retorno produzido pela instância do tipo UsersDAO, determinando 
     assim a validade do usuário e da chave de acesso em questão;
    Em se tratando de credenciais de um usuário existente claims serão geradas, 
    o período de expiração calculado e um token criado por meio de uma instância do
     tipo JwtSecurityTokenHandler (namespace System.IdentityModel.Tokens.Jwt). 
     Este último elemento é então transformado em uma string por meio do método 
     WriteToken e, finalmente, devolvido como retorno da Action Post (juntamente 
     com outras informações como horário de geração e expiração do token);
    Se o usuário for inválido um objeto então será devolvido, indicando que a autenticação falhou.
     */
     
    [Route("api/login")]
    public class LoginController:Controller{
        //vamos criar uma propriedade de somente leitura para o contexto de banco de dados
        //Essa propriedade não poderá ter seu valor alterado dinamicamente, ou seja
        //nao pode alterar enquanto a aplicacao estiver rodando.
        readonly ACContexto _contexto;
        //vamos criar um construtor para inicializar a classe
        public LoginController(ACContexto contexto){
            _contexto = contexto;
        }

        public ClaimsIdentity Identicacao { get; private set; }

        //permitir o acesso de qualquer pessoa a pagina de login
        [AllowAnonymous]
        [HttpPost]

        public IActionResult Post(
            [FromBody]Usuario usuario, //pegando do usuario
            [FromServices]SigningConfigurations signingConfigurations, //configuracao de login
            [FromServices]TokenConfigurations tokenConfigurations) //config de tokens
        
        {
            Usuario user = _contexto.Usuario
                                    .FirstOrDefault( us => 
                us.NomeUsuario==usuario.NomeUsuario && 
                us.Senha== usuario.Senha);
            if (user !=null){       //se o usuario user for diferente de nulo ele prossegue com o login 
            
                ClaimsIdentity Identity = new ClaimsIdentity(     /*     identidade para o token do usuario que autenticou com sucesso
                                                                1º Primeiro passamos para string id do usuario que vem como int e dizer que esta logado(Aqui usamos o termo "login)
                                                                2º Segundo construir uma estrutura de apresentação de dados o usuario/ como NomeUsuario e Nivel como String.
                                                                     a forma de registro unico do usuario no Token foi identificada como user.Id
                                                                3º Terceiro incluimos o NomeUsuario e o Nivel */
                new GenericIdentity(user.Id.ToString(), "Login"),
                new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim("Nome", user.NomeUsuario),    
                new Claim("Nivel", user.Nivel)
                    });

                Identity.AddClaim(new Claim(ClaimTypes.Role, user.Nivel)); /*Definir a autorizacao do usuario . Quando for cliente */
                            

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                /*Para a montagem do Token foram colocadas as seguintes informaçoes
                Dentre elas temos (Assinaturas RSA, Credenciais do Usuario, Data de criacao e expiração) */
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = Identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                var retorno = new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
                return Ok(retorno);
            }
            else
            {
                var retorno = new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };

                return BadRequest(retorno);
            }
        }
    }
}