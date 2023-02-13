# <img id='start' width='38px' src='https://user-images.githubusercontent.com/97141987/218549906-516b7d3d-b535-4f23-9c5f-3d218005ebcc.png'> SpreadsheetReader 

## ![Vercel](https://vercelbadge.vercel.app/api/holiv/SpreadsheetReader-Angular) [Accessar aplicação](https://spreadsheet-reader.vercel.app/)

<i>Este repositório é referente ao Backend desta aplicação. Para visualizar os dados referente ao Frontend acessar o respectivo repositoriório clicando [aqui](https://github.com/Holiv/SpreadsheetReader-Angular)</i>

### Aplicação desenvolvida como desafio da empresa Astéria.

- <a href="#intro">Introdução</a>
- <a href="#desafio">O Desafio</a>
- <a href="#tech">Tecnologias</a>
- <a href="#apli">A Aplicação</a>
  - <a href="#inicio">Inicio</a>
  - <a href="#rec">Recebendo Arquivos</a>
  - <a href="#manip">Manipulação de Dados</a>
  - <a href='#filtro'>Filtros</a>
- <a href="#emp">A Empresa</a>

---
## <p id="#intro">Introdução</p>

O SpreadsheetReader, como decidi nomea-lo, tem o objetivo de importar um arquivo em Excel, com uma listagem de pedidos, extrair esses dados, importa-los para o banco de dados para que então esses dados possam ser consumidos e manipulados pelo usuário através de uma interface.

![spreadgif](https://user-images.githubusercontent.com/97141987/218546270-14577d20-4550-46dc-92cf-4a943c90714e.gif)

Repositório referente ao Back-End da aplicação.

## <p id="#desafio">O Desafio</p>

1. Importação dos dados no banco de dados. [Utilize essa planilha para testar a aplicação](https://github.com/Holiv/SpreadsheetReader-ASP.NETCoreWebAPI/files/10725461/sheet_dummy_data.xlsx)

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

### <p id="#filtro">Filtros</p>
A Aplicação possui filtragem de dados por Codigo do Cliente, Categoria do Produto, Mês da operação e Trimestre, sendo o trimestre mostrado em forma de gráfico.

Os filtros podem ser selecionados através de lista de opcões pré-carregadas com valores existentes. Por exemplo, se em um determinado mês nenhuma operação ocorreu, esse mês não estará disponível na listagem de filtragem por mês.

O mesmo ocorre para a incluão de novos dados. Se um novo pedido for feito com um novo código de cliente, o devido código será carregado automaticamente como opção de seleção para filtragem do usuário.

Essa funcionalidade é possível através de endpoints desta API que retornam valores distintos para os campos correspondentes. Quando a aplicação é carregada, os endpoints são acessados retornando os valores distintos existentes.

## <p id="#carr">A Empresa</p>
Desde 2005 no mercado, a Astéria se destaca por ser uma empresa diferenciada, com a capacidade de compreender as exigências e particularidades de cada projeto, e oferecer soluções exclusivas e inovadoras.

Dirigida por profissionais multidisciplinares e com larga experiência no universo digital, acreditamos que a tecnologia deve servir e auxiliar pessoas a alcançarem melhores resultados.

Ao longo dos 17 anos de atuação, a Astéria desenvolveu importantes projetos para grandes empresas de diversos segmentos. Os projetos voltados para Trade Marketing ganharam destaque em alguns clientes devido aos excelentes resultados. Passamos então a nos identificar cada vez mais com estes projetos e assim agregar ainda mais valor aos nossos clientes.
#### <a href="#start">Voltar ao Inicio</a>
---
