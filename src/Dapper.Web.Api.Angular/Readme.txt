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

Docker

-----------
PT - 1

Rodando docker em linha de comando

docker run -i -t ubuntu:16.04 /bin/bash

Entrar no conteiner

docker attach 301f7cfc8766

Verificar o que modificado no conteiner

docker diff 301f7cfc8766

Para matar o conteiner 

CTRL + D

Você pode também utilizar 
docker stop 301f7cfc8766

Para startar 
docker start 301f7cfc8766


Expondo conteiner com a porta

docker run -i -t -p 8080:80 ubuntu:16.04 /bin/bash

Atualizando o ubuntu 

apt-get update

Instalando nginx

apt-get install nginx

Startando o serviço
/etc/init.d/nginx start

Para verificar o serviço startado

ps -ef

Para Verificar a porta que está utilizando
Observação caso de erro instale (sudo apt install net-tools)

netstat -atunp

Teste com nginx

Abra o navegador e digite

http://192.168.99.100:8080/

Commitar imagem ubuntu
docker commit 2ef58c2eae5d acpereira/nginx-ubuntu:1.0

Criar um conteiner baseado no que eu estava
usando 
docker run -i -t -p 6660:80 acpereira/nginx-ubuntu:1.0 /bin/bash

Dentro conteiner para monitorar

digite

tail -f /var/log/nginx/access.log

PT - 2

Rodar comandos através do conteiner

Aqui visualizamos os processos rodando na máquina

docker exec 3b4394318ffd ps -ef

Exemplo até para os serviços docker

docker exec 3b4394318ffd /etc/init.d/nginx stop
docker exec 3b4394318ffd /etc/init.d/nginx start

Consegue visualizar as informações do conteiner docker
docker inspect 3b4394318ffd

Para verificar se a porta está comunicando
curl 127.0.0.1:80

Verificar uso de memória, cpu, analisa o quanto o docker está consumindo na sua máquina 
docker stats 3b4394318ffd

Caso queira remover o conteiner 
docker rm 3b4394318ffd

Caso queira remover o conteiner a força
docker rm -f 3b4394318ffd

Caso queira ver as imagens
docker images

Caso queira remover a imagem
docker rmi 3b4394318ffd

Caso queira remover a imagem a força
docker rmi -f 3b4394318ffd

Caso queira fazer um conteiner conversar com o outro

docker run -it --name web2 --link fervent_ride:web1 acpereira/nginx-ubuntu:1.0

Depois para testar ping web1

Caso o ping não funcione (apt-get install iputils-ping)

PT - 3

Criando Dockerfile

Vai na pasta desejada

Ficaria assim:
acpereira@resource-7115 MINGW64 /usr/share
$ mkdir Dockerfile

acpereira@resource-7115 MINGW64 /usr/share
$ cd Dockerfile/

acpereira@resource-7115 MINGW64 /usr/share/Dockerfile
$ mkdir apache

acpereira@resource-7115 MINGW64 /usr/share/Dockerfile
$ cd apache/

acpereira@resource-7115 MINGW64 /usr/share/Dockerfile/apache

depois crie o arquivo

Vim Dockerfile

e dentro digite

#Nome da Imagem
FROM ubuntu:16.04

#Criador da imagem
MAINTAINER andy2903.alp@gmail.com

#Comando a ser executado
RUN apt-get update && apt-get install -y apache2 && apt-get clean
RUN /etc/init.d/apache start

Para buildar a imagem

No diretório corrente

  docker build .
Colocar nome na imagem  

docker build -t andy2903p/apache:1.0

Usar a imagem criada
docker run -i -t  andy2903p/apache:1.0(51a89bc063e7)  /bin/bash


