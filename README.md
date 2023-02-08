# <p id="start">SpreadsheetReader</p>
### Aplicação desenvolvida como desafio da empresa Astéria.

- <a href="#intro">Introdução</a>
- <a href="#desafio">O Desafio</a>
- <a href="#tech">Tecnologias</a>
- <a href="#apli">A Aplicação</a>
  - <a href="#inicio">Inicio</a>
  - <a href="#rec">Recebendo Arquivos</a>
  - <a href="#manip">Manipulação de Dados</a>
- <a href="#emp">A Empresa</a>

---
## <p id="#intro">Introdução</p>

O SpreadsheetReader, como decidi nomea-lo, tem o objetivo de importar um arquivo em Excel, com uma listagem de pedidos, extrair esses dados, importa-los para o banco de dados para que então esses dados possam ser consumidos e manipulados pelo usuário através de uma interface.

Repositório referente ao Back-End da aplicação.

## <p id="#desafio">O Desafio</p>

1. Importação dos dados no banco de dados.
2. Listagem paginada mostrando os campos das planilhas (soma).
3. Filtros por mês, código cliente, e categoria.
4. Mostrar as informações agrupadas por trimestre (se possível um gráfico).
## <p id="#tech">Tecnologias</p>
1. ASP.NET Core Web API
2. Entity Framework Core
3. Microsoft SQL Server
4. EPPlus
5. Postman (para testes)

## <p id="#apli">A Aplicação</p>
### <p id="#inicio">Inicio</p>
A Aplicação é iniciada com uma interface simples, que solicita ao usuário o upload da planilha a ser utilizada para a extração dos dados

### <p id="#rec">Recebendo Arquivos</p>
O arquivo é recebido através de uma requisição Http do tipo POST, onde será tratado por esta API.
O metodo chamado é responsável por receber o arquivo e utilizar a extensão EPPlus para extrair os dados e então instanciar novos objetos a partir desses dados. Cada objeto então é enviado ao banco de dados através da conexção feita pelo Entity Framework Core.

Quando uma requisição do tipo Get é feita pelo front-end, esses dados são recuperados e enviados para serem renderizados. Para mais informações sobre a aplicação front-end, acessar o link https://github.com/Holiv/SpreadsheetReader-Angular

### <p id="#manip">Manipulação de dados</p>
Uma vez que a planilha é enviada ao banco de dados, podemos solicitar o carregamento dos dados na pagina.
Foram utilizados componentes e serviços do Angular para criar uma requisição Http do tipo GET e carregar os dados na pagina. 
Através da utilização de rotas os elementos são alterados sem a necessidade de um Reload na página.

## <p id="#carr">A Empresa</p>
Desde 2005 no mercado, a Astéria se destaca por ser uma empresa diferenciada, com a capacidade de compreender as exigências e particularidades de cada projeto, e oferecer soluções exclusivas e inovadoras.

Dirigida por profissionais multidisciplinares e com larga experiência no universo digital, acreditamos que a tecnologia deve servir e auxiliar pessoas a alcançarem melhores resultados.

Ao longo dos 17 anos de atuação, a Astéria desenvolveu importantes projetos para grandes empresas de diversos segmentos. Os projetos voltados para Trade Marketing ganharam destaque em alguns clientes devido aos excelentes resultados. Passamos então a nos identificar cada vez mais com estes projetos e assim agregar ainda mais valor aos nossos clientes.
#### <a href="#start">Voltar ao Inicio</a>
---