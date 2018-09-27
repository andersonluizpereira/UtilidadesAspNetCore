Gerando o banco de dados e as tabelas usando Migrations

Agora  podemos usar o Migration do EF Core para criar o nosso banco de dados.

Abra uma janela do Package Manager Console via menu Tools e digite o comando : add-Migration ModeloInicial

Após a conclusão do comando verifique os arquivos criados na pasta Migrations do projeto e veja se o mapeamento esta correto.

A seguir na janela do Package Manager Console digite o comando : update-database

Ao final desta etapa teremos o banco de dados Alfa.mdf e as tabelas Marcas, Modelos e Acessorios criadas no banco de dados.

Precisamos agora incluir algumas informações nestas tabelas para podermos usá-las no projeto.

Para isso vamos criar uma migração vazia e depois vamos definir os dados que vamos incluir.

Digite o comando na janela Package Manager Console : add-migration SeedDatabase

Agora abra o arquivo SeedDatabase e você verá que temos a classe SeedDatabase contendo os métodos Up e Down vazios.