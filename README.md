# <p id="start">SpreadsheetReader</p>
### Aplica��o desenvolvida como desafio da empresa Ast�ria.

- <a href="#intro">Introdu��o</a>
- <a href="#desafio">O Desafio</a>
- <a href="#tech">Tecnologias</a>
- <a href="#apli">A Aplica��o</a>
  - <a href="#inicio">Inicio</a>
  - <a href="#rec">Recebendo Arquivos</a>
  - <a href="#manip">Manipula��o de Dados</a>
- <a href="#emp">A Empresa</a>

---
## <p id="#intro">Introdu��o</p>

O SpreadsheetReader, como decidi nomea-lo, tem o objetivo de importar um arquivo em Excel, com uma listagem de pedidos, extrair esses dados, importa-los para o banco de dados para que ent�o esses dados possam ser consumidos e manipulados pelo usu�rio atrav�s de uma interface.

Reposit�rio referente ao Back-End da aplica��o.

## <p id="#desafio">O Desafio</p>

1. Importa��o dos dados no banco de dados.
2. Listagem paginada mostrando os campos das planilhas (soma).
3. Filtros por m�s, c�digo cliente, e categoria.
4. Mostrar as informa��es agrupadas por trimestre (se poss�vel um gr�fico).
## <p id="#tech">Tecnologias</p>
1. ASP.NET Core Web API
2. Entity Framework Core
3. Microsoft SQL Server
4. EPPlus
5. Postman (para testes)

## <p id="#apli">A Aplica��o</p>
### <p id="#inicio">Inicio</p>
A Aplica��o � iniciada com uma interface simples, que solicita ao usu�rio o upload da planilha a ser utilizada para a extra��o dos dados

### <p id="#rec">Recebendo Arquivos</p>
O arquivo � recebido atrav�s de uma requisi��o Http do tipo POST, onde ser� tratado por esta API.
O metodo chamado � respons�vel por receber o arquivo e utilizar a extens�o EPPlus para extrair os dados e ent�o instanciar novos objetos a partir desses dados. Cada objeto ent�o � enviado ao banco de dados atrav�s da conex��o feita pelo Entity Framework Core.

Quando uma requisi��o do tipo Get � feita pelo front-end, esses dados s�o recuperados e enviados para serem renderizados. Para mais informa��es sobre a aplica��o front-end, acessar o link https://github.com/Holiv/SpreadsheetReader-Angular

### <p id="#manip">Manipula��o de dados</p>
Uma vez que a planilha � enviada ao banco de dados, podemos solicitar o carregamento dos dados na pagina.
Foram utilizados componentes e servi�os do Angular para criar uma requisi��o Http do tipo GET e carregar os dados na pagina. 
Atrav�s da utiliza��o de rotas os elementos s�o alterados sem a necessidade de um Reload na p�gina.

## <p id="#carr">A Empresa</p>
Desde 2005 no mercado, a Ast�ria se destaca por ser uma empresa diferenciada, com a capacidade de compreender as exig�ncias e particularidades de cada projeto, e oferecer solu��es exclusivas e inovadoras.

Dirigida por profissionais multidisciplinares e com larga experi�ncia no universo digital, acreditamos que a tecnologia deve servir e auxiliar pessoas a alcan�arem melhores resultados.

Ao longo dos 17 anos de atua��o, a Ast�ria desenvolveu importantes projetos para grandes empresas de diversos segmentos. Os projetos voltados para Trade Marketing ganharam destaque em alguns clientes devido aos excelentes resultados. Passamos ent�o a nos identificar cada vez mais com estes projetos e assim agregar ainda mais valor aos nossos clientes.
#### <a href="#start">Voltar ao Inicio</a>
---