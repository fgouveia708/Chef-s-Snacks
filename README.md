
# Chef's Snacks

![](https://raw.githubusercontent.com/fgouveia708/Chef-s-Snacks/master/Frontend/src/assets/icon.png)

Chef's Snacks é uma aplicação demonstrativa que visa mostrar técnicas de arquitetura, desenvolvimento e distribuição de software utilizando ferramentas como .NET Core, Angular 7, Bootstrap, Docker, Nginx e Jenkins.

- [Chef's Snacks](https://github.com/fgouveia708/Chef-s-Snacks#chefs-snacks)
    - [Introdução](https://github.com/fgouveia708/Chef-s-Snacks#introdu%C3%A7%C3%A3o)
    - [Briefing](https://github.com/fgouveia708/Chef-s-Snacks#briefing)
    - [Requisitos técnicos](https://github.com/fgouveia708/Chef-s-Snacks#requisitos-t%C3%A9cnicos)
    - [Backend](https://github.com/fgouveia708/Chef-s-Snacks#backend)
    - [Frontend](https://github.com/fgouveia708/Chef-s-Snacks#frontend)
    - [Deploy](https://github.com/fgouveia708/Chef-s-Snacks#deploy)
        - [Docker](https://github.com/fgouveia708/Chef-s-Snacks#docker)
        - [Nginx](https://github.com/fgouveia708/Chef-s-Snacks#nginx)
        - [Jenkins](https://github.com/fgouveia708/Chef-s-Snacks#jenkins)

### Introdução

A ideia é criar uma aplicação web para uma startup do ramo de alimentos que precisa gerir seu negócio. A especialidade é a venda de lanches, de modo que alguns lanches são opções de cardápio e outros podem conter ingredientes personalizados.

### Briefing
                
Somos uma startup do ramo de alimentos e precisamos de uma aplicação web para gerir nosso negócio. Nossa especialidade é a venda de lanches, de modo que alguns lanches são opções de cardápio e outros podem conter ingredientes personalizados.

A seguir, apresentamos a lista de ingredientes disponíveis:

| INGREDIENTE      | VALOR |
| --------- | -----:|
| Alface |$0,40|
| Bacon |$2,00|
| Hambúrguer de carne |$3,00|
| Ovo |$0,80|
| Queijo |$1,50|

Segue as opções de cardápio e seus respectivos ingredientes:

| LANCHE      | INGREDIENTES |
| --------- | :-----|
| X-Bacon | Bacon, hambúrguer de carne e queijo |
| X-Burger | Hambúrguer de carne e queijo |
| X-Egg | Ovo, hambúrguer de carne e queijo |
| X-Egg Bacon  | Ovo, bacon, hambúrguer de carne e queijo |

O valor de cada opção do cardápio é dado pela soma dos ingredientes que compõe o lanche. Além destas opções, o cliente pode personalizar seu lanche e escolher os ingredientes que desejar. Nesse caso, o preço do lanche também será calculado pela soma dos ingredientes.

Existe uma exceção à regra para o cálculo de preço, quando o lanche pertencer à uma promoção. A seguir, apresentamos a lista de promoções e suas respectivas regras de negócio:

| PROMOÇÃO | REGRA DE NEGÓCIO |
| --------- | :-----|
| Light | Se o lanche tem alface e não tem bacon, ganha 10% de desconto. |
| Muita carne | A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, o cliente pagará 4. Assim por diante... |
| Muito queijo | A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, o cliente pagará 4. Assim por diante... |


| REGRA      | DESCRIÇÃO |
| --------- | :-----|
| Inflação | Os valores dos ingredientes são alterados com frequência e não gostaríamos que isso influenciasse nos testes automatizados. |

__CRITÉRIOS DE COMPLETUDE__

O projeto deve ser entregue atendendo aos seguintes critérios

- O server-side deve ser desenvolvido em .Net Core ou .Net.
- O client-side deve ser desenvolvido em  Angular.
- Deve possuir cobertura de testes automatizados para os seguintes pontos: Valor dos lanches de cardápio, regra para cálculo de preço e promoções.
Não é necessário se preocupar com a autenticação dos usuários.
- Não é necessário persistir os dados em um banco, pode fazer armazenamento em memória.

__ENTREGÁVEIS__

Você deve entregar um conjunto de artefatos, de acordo com o nível de complexidade que achar melhor. A seguir, os níveis de complexidade e seus respectivos entregáveis:

Fácil:
- Implementação dos requisitos;
- Instruções para executar.

Médio:
- Implementação dos requisitos;
- Relatório de justificativas para escolha do design de código;
- nstruções para executar;

Difícil:
- Implementação dos requisitos;
- Relatório de justificativas para escolha do design de código;
- Os testes automatizados devem ser executados por algum modelo de integração contínua;
- O ambiente de execução da aplicação deve possuir um HTTP Proxying com nginx, redirecimendo as requisições da porta 80 para o server-side;
- Ambiente virtualizado em Docker com scripts para execução.

### Requisitos técnicos
                
- Visual Studio Code;
- .NET Core;
- Angular 7;
- Docker;
- Nginx;
- Jenkins.

### Backend
                
Chef’s Snack possui uma arquitetura de dependência invertida e pouco acoplada, conhecida também como Arquitetura Onion e uma estrutura de solução básica que possa ser usada para construir aplicativos SOLID baseados em Domain-Driven Design (DDD). 

![](https://raw.githubusercontent.com/fgouveia708/Chef-s-Snacks/master/Frontend/src/assets/onion.png)


### Frontend
                
A ideia é criar uma aplicação web para uma startup 

![](https://raw.githubusercontent.com/fgouveia708/Chef-s-Snacks/master/Frontend/src/assets/frontend.png)

### Deploy
                
A ideia é criar uma aplicação web para uma startup 

### Docker

A ideia é criar uma aplicação web para uma startup `docker-compose.yml`

```
version: '3.4'

services:
  proxy:
    image: chefsnacks-nginx
    build:
      context: .
    ports:
      - "3000:80"
    depends_on:
      - chefsnacks01
      - chefsnacks02
      - chefsnacks03
    networks:
      - chefsnacks-network
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
  
  chefsnacks01:
    image: chefsnacks
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "3001:80"
    networks:
      - chefsnacks-network
  
  chefsnacks02:
    image: chefsnacks
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "3002:80"
    networks:
      - chefsnacks-network
  
  chefsnacks03:
    image: chefsnacks
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "3003:80"
    networks:
      - chefsnacks-network

networks: 
    chefsnacks-network:
      driver: bridge
```

### Nginx

A ideia é criar uma aplicação web para uma startup `nginx.config`
```
worker_processes 4;

events { worker_connections 1024; }

http {
        upstream chefsnacks {
        least_conn;
        server chefsnacks01;
        server chefsnacks02;
        server chefsnacks03;
    }

    server {
        listen 80;

        location / {
            proxy_pass http://chefsnacks;
        }
    }
}
```
### Jenkins

A ideia é criar uma aplicação web para uma startup  `JenkinsPipelineScripts.txt`

```
node{ 
    stage('Checkout') {
        git 'https://github.com/fgouveia708/Chef-s-Snacks.git'
    } 
    
    stage('Build'){ 
        bat 'docker-compose -f backend/docker-compose.yml build' 
    } 
    
    stage('Test'){
        dir("backend") {
            dir("app") {
                dir("ChefSnacks.Test") {
                       bat 'dotnet test' 
                }
            }  
        }
    }
    
    stage('Deploy'){
        bat 'docker-compose -f backend/docker-compose.yml down --remove-orphans' 
        dir("backend") {
            bat 'docker-compose up -d' 
            bat 'docker ps -a' 
        }
    }   
}
```
Resultado:

![](https://raw.githubusercontent.com/fgouveia708/Chef-s-Snacks/master/Frontend/src/assets/jenkins-1.png)
