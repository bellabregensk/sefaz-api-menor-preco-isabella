# sefaz-api-menor-preco-isabella
API Processo Seletivo SEFAZ-ES 2021

Meu nome é Isabella Bregensk.

Esse projeto é referente ao processo seletivo SEFAZ-ES 2021.
Foi criada uma API .NET Core 3.1 com conexão ao banco de dados SQLite.

# Intruções para execução do projeto:

- Copiar a pasta DB contida nesse repositório e colar em C:;
- Abrir a Solution SEFAZ.sln no Visual Studio e executar o projeto definindo a SEFAZAPI como projeto de inicialização;
- Executar as rotas:
    Produto: http://localhost:52167/v1/produto/
    Essa rota possui o parâmetro do tipo numérico "codigoGtin". A mesma, tem como objetivo obter todos os produtos contidos no banco de dados com os critérios solicitados nas intruções do processo seletivo.
    
    Importar: http://localhost:52167/v1/importar/
    Essa rota tem como objetivo importar os dados do arquivo .csv disponível no link do processo seletivo para um banco de dados SQLite.

A título de informação, no momento da execução da Solution, a rota "Index" executará como default. A rota Index possui as instruções e informações das rotas citadas acima.



# Informações sobre o processo seletivo:

O objetivo da avaliação é construir uma API (REST/JSON) para consulta e recuperação de produtos, filtrada pelo código GTIN (EAN) e ordenada de forma crescente pelo preço. Você deve utilizar a base de dados de produtos fake disponibilizada ao final da descrição.

Crie uma modelagem de banco de dados para o dataset fornecido utilizando banco de dados sqlite. Elabore uma modelagem que seja a mais adequada para a solução proposta.
Crie um mecanismo para realizar a importação dos dados do arquivo com extensão .csv para o .sqlite de forma dinâmica. Pode ser através de uma rota (GET /v1/importar) ou via Command (Laravel - "php artisan import:db")
Defina uma rota GET /v1/produtos para obter todos os produtos contidos no banco de dados. A rota deve receber como parâmetro um valor GTIN. Caso o acesso a esse endpoint seja sem esse parâmetro, o sistema deve retornar resposta 400 (Bad Request). Caso o produto não exista, retornar 404 (Not Found).
Criar um mecanismo de validação para verificar a existência ou não dos parâmetros obrigatórios da API.
A localização (latitude e longitude) de cada contribuinte, associado a cada produto, está disponível no dataset, respectivamente nas colunas cod_latitude e cod_longitude. Uma consulta por produto (código GTIN) ao endpoint deve resultar em uma listagem contendo o último produto vendido de cada estabelecimento, ordenada de forma crescente pelo preço. Os registros que não possuírem preço ou cujo contribuinte não possua localização devem ser descartados. Retornar, também, na listagem acima a URL do Google Maps contendo o endereço do estabelecimento.

Para participar crie um repositório público (GIT) e envie e-mail para processo-seletivo-dev@sefaz.es.gov.br contendo seu nome completo, currículo em anexo e a URL do repositório.

A tarefa deve ser implementada em PHP com a framework Laravel 5.6+ ou em .NET CORE 3.1 LTS.

Crie arquivo README.md contendo instrução para instalação e execução do seu repositório.

Implementações fora desse contexto não serão pontuadas.
O que será avaliado
Formato da entrega.
Arquivo README.md com instruções para executar sua aplicação.
Execução do roteiro acima e funcionamento da sua aplicação.
Aderência ao contexto informado.
Modelagem e importação dos dados
Rota /v1/produtos
Validação dos parâmetros obrigatórios
Os diferenciais serão critérios de desempate
Diferenciais
Criar um mecanismo que realize um log de cada request, registrando o horário, o GTIN, o status code da requisição e o número de produtos retornados. Decida se o log será registrado em banco de dados ou em arquivo texto.
Escrever testes unitários que garantam o funcionamento esperado da API e cubram todo o código.
Permitir informar a sua latitude e longitude na rota de produtos (parâmetro opcional) para simular sua localização e obter no retorno da API um atributo distância (em KM) de você até o endereço do contribuinte. Este atributo não deve pertencer à modelagem de banco de dados, uma vez que se trata de um atributo calculado em tempo real, de acordo com a localização informada e a localização de cada contribuinte.
