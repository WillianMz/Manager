# Manager Tickets

Aplicação com o objetivo de gerenciar solicitações de mudanças de software. Softwares desses tipos também são chamados de bug trackers,
issue trackers ou simplesmente, sistema de chamados.


## Requisitos

``` bash
.NET Core;
MySQL
```

## Instalação

``` bash
Selecionar o projeto Manager.API como projeto de inicialização;
No Console do Gerenciador de Pacotes do Visual Studio, setar o projeto padrão: Manager.Infra.Data
Executar os comandos:
	Update-database --verbose
	Comando para gerar a base de dados.(Lembre-se de iniciar o servidor do MySQL)
```


## Executar a aplicação (Ambiente de Desenvolvimento)

Executar a API
```cs
cd Manager
cd Manager.API
dotnet watch run

```


## Imagens
![alt text](https://github.com/WillianMz/Manager/blob/master/Docs/Imagens/Swagger.png)
![alt text](https://github.com/WillianMz/Manager/blob/master/Docs/Imagens/Resposta.png)
![alt text](hhttps://github.com/WillianMz/Manager/blob/master/Docs/Imagens/Schemas.png)
